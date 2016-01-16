using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace ArcDB
{
    class ArcTool
    {
        //根据文章内容获取文章概要
        public static string GetDescription(string article,int descriptionLength)
        {
            char[] splitChars = { '!', '.', '?','~', '！', '。', '？'};
            string[] sentenceArr = article.Split(splitChars);
            string description = "";
            string nextSentence = "";
            //遍历句子分隔符分出来的句子字符串组，如果当前概要的长度小于需要截取的长度，则将当前遍历的句子添加到描述
            foreach (string sentence in sentenceArr)
            {
                string temp = description + sentence;
                if (temp.Length < descriptionLength || description=="")
                {
                    description = description + sentence;
                }
                else
                {
                    nextSentence = sentence;
                    break;
                }
            }
            //确定所截取文章概要后面标点符号的位置
            int spliterIndex = 0;
            if (nextSentence != "")
            {
                spliterIndex = article.IndexOf(nextSentence) - 1;
            }
            else
            {
                spliterIndex = article.Length - 1;
            }
            if (spliterIndex!=-1)
            {
                description = description + article.Substring(spliterIndex, 1);
            }
            else
            {
                description = description + "。";
            }
            return description;
        }

        //根据图片生成图片略图，缩放后空白地方用白色背景填充
        public static bool GenThumbnail(Image imageFrom, string pathImageTo, int width, int height)
        {

            if (imageFrom == null)
            {
                return false;
            }
            // 源图宽度及高度 
            int imageFromWidth = imageFrom.Width;
            int imageFromHeight = imageFrom.Height;
            // 生成的缩略图实际宽度及高度 
            int bitmapWidth = width;
            int bitmapHeight = height;
            // 生成的缩略图在上述"画布"上的位置 
            int X = 0;
            int Y = 0;
            // 根据源图及欲生成的缩略图尺寸,计算缩略图的实际尺寸及其在"画布"上的位置 
            if (bitmapHeight * imageFromWidth > bitmapWidth * imageFromHeight)
            {
                bitmapHeight = imageFromHeight * width / imageFromWidth;
                Y = (height - bitmapHeight) / 2;
            }
            else
            {
                bitmapWidth = imageFromWidth * height / imageFromHeight;
                X = (width - bitmapWidth) / 2;
            }
            // 创建画布 
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            // 用白色清空 
            g.Clear(Color.White);
            // 指定高质量的双三次插值法。执行预筛选以确保高质量的收缩。此模式可产生质量最高的转换图像。 
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // 指定高质量、低速度呈现。 
            g.SmoothingMode = SmoothingMode.HighQuality;
            // 在指定位置并且按指定大小绘制指定的 Image 的指定部分。 
            g.DrawImage(imageFrom, new Rectangle(X, Y, bitmapWidth, bitmapHeight), new Rectangle(0, 0, imageFromWidth, imageFromHeight), GraphicsUnit.Pixel);
            try
            {
                //经测试 .jpg 格式缩略图大小与质量等最优 
                bmp.Save(pathImageTo, ImageFormat.Jpeg);
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                //显示释放资源 

                bmp.Dispose();
                g.Dispose();
            }
        }
    }
}
