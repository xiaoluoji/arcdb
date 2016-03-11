using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ImageMagick;


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

        #region 使用imageMagic扩展库生成缩略图
        public static bool MakeThumb(string sourcePath, string dstPath, int width, int height, string mode)
        {
            // FullPath is the new file's path.
            ImageMagick.MagickImage img = new ImageMagick.MagickImage(sourcePath);
            if (img.Height != height || img.Width != width)
            {
                int new_width = width;
                int new_height = height;
                ImageMagick.Gravity dstGravity = new ImageMagick.Gravity(); //设置目标截取的位置
                dstGravity = Gravity.Center;  //默认截取位置是从中间截取
                decimal result_ratio = (decimal)height / (decimal)width;   //目标
                decimal current_ratio = (decimal)img.Height / (decimal)img.Width;

                switch (mode)
                {
                    case "HW":      //指定高宽缩放（可能变形）
                        break;
                    case "W":       //指定宽，高按比例
                        new_height = img.Height * width / img.Width;
                        dstGravity = Gravity.North;
                        break;
                    case "H":       //指定高，宽按比例
                        new_width = img.Width * height / img.Height;
                        break;
                    case "Cut":         //指定高宽裁减（不变形）    
                        Boolean preserve_width = false;
                        if (current_ratio > result_ratio)
                        {
                            preserve_width = true;
                        }
                        if (preserve_width)
                        {
                            dstGravity = Gravity.North;
                            new_width = width;
                            new_height = (int)Math.Round((decimal)(current_ratio * new_width));
                        }
                        else
                        {
                            dstGravity = Gravity.Center;
                            new_height = height;
                            new_width = (int)Math.Round((decimal)(new_height / current_ratio));
                        }
                        break;
                    default:
                        break;
                }
                String newGeomStr = new_width.ToString() + "x" + new_height.ToString() + "!";
                ImageMagick.MagickGeometry intermediate_geo = new ImageMagick.MagickGeometry(newGeomStr);
                //img.Resize(intermediate_geo);
                img.Thumbnail(intermediate_geo);
                img.Crop(width, height, dstGravity);
            }
            try
            {
                img.Quality = 95;
                img.Sharpen();
                img.Write(dstPath);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region 按指定模式生成缩略图
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param>    
        public static bool MakeThumbOld(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            if (originalImagePath=="")
            {
                return false;
            }
            System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

            int towidth = width;
            int toheight = height;

            int x = 0;
            int y = 0;
            int ow = originalImage.Width;
            int oh = originalImage.Height;

            switch (mode)
            {
                case "HW":  //指定高宽缩放（可能变形）                
                    break;
                case "W":   //指定宽，高按比例                    
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H":   //指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut": //指定高宽裁减（不变形）                
                    if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        //y = (originalImage.Height - oh) / 2;
                        y = 0;
                    }
                    break;
                default:
                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight), new System.Drawing.Rectangle(x, y, ow, oh), System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                return true;
            }
            catch (System.Exception e)
            {
                //throw e;
                return false;
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }
        #endregion

        //根据图片生成图片略图，缩放后空白地方用白色背景填充
        public static bool GenThumbFillWithWhite(Image imageFrom, string pathImageTo, int width, int height)
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
