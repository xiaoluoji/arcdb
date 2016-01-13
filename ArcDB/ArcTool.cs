using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcDB
{
    class ArcTool
    {
        public static string GetDescription(string article,int descriptionLength)
        {
            char[] splitChars = { '!', '.', '?', '！', '。', '？' };
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
    }
}
