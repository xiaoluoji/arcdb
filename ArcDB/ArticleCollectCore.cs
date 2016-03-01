using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Threading;



namespace ArticleCollect
{
    class ArticleCollectCore
    {
        #region Fields

        private List<Exception> _coException;           //获取所有处理过程中的异常
        private Exception _cancelException;              //获取处理过程中取消事件的异常
        private int _currentProcessedArticles;           //当前采集文章数量
        private int _currentProcessedListPages;        //当前获得列表页数
        private int _currentGetArticlePages;             //当前获得文章URL数量


        #endregion

        // public props
        public bool IsRecordError;
        public CancellationTokenSource CancelToken = new CancellationTokenSource();


        #region Constructors

        public ArticleCollectCore()
        {
            _coException = new List<Exception>() ;
            IsRecordError = true;
        }

        public ArticleCollectCore(bool isRecordError)
        {
            _coException = new List<Exception>();
            this.IsRecordError = isRecordError;
        }

        #endregion


        #region Properties
        public List<Exception> CoException
        {
            get { return _coException; }
        }
        public Exception CancelException
        {
            get { return _cancelException; }
        }
        public int CurrentProcessedArticles
        {
            get { return _currentProcessedArticles; }
        }
        public int CurrentProcessedListPages
        {
            get { return _currentProcessedListPages; }
        }
        public int CurrentGetArticlePages
        {
            get { return _currentGetArticlePages; }
        }


        #endregion


        #region Public Methods
        //去除内容中的指定子节点的内容
        public string RemoveSubNode(string htmlContent, List<string> subNodeParams)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            string afterRemove = htmlContent;
            try
            {
                //可能有多个需要清理的子节点，子节点保存在 subNodeParams中，通过遍历来去除
                foreach (string subNodeXpath in subNodeParams)
                {
                    doc.LoadHtml(afterRemove);
                    //HtmlAgilityPack.HtmlNode subNode = doc.DocumentNode.SelectSingleNode("//*[@id='PagerHolder']");
                    HtmlAgilityPack.HtmlNode subNode = doc.DocumentNode.SelectSingleNode(subNodeXpath);

                    //*[@id="PagerHolder"]
                    //此处选择采用字符串替换的方法去除子节点的内容，而不是采用从Xpath中去除指点节点
                    //考虑的是文章内容中可能出现部分文字内容不属于任何节点，如果考虑用HtmlAgilityPack类中去除节点的方法，
                    //那么去除后的内容中将不包括不属于任何节点的文字内容！ （此情况虽然出现概率很小，不过采用字符串替换万无一失）
                    if (subNode is HtmlAgilityPack.HtmlNode)
                    {
                        afterRemove = afterRemove.Replace(subNode.InnerHtml, "");
                    }
                }
                return afterRemove;
            }
            catch (Exception ex)
            {
                if (IsRecordError)
                {
                    ex.Data.Add("subNodeParams", subNodeParams);
                    _coException.Add(ex);
                }
                return afterRemove;
            }
        }

        //对内容页面中的内容做清理，只保留文字基本信息，以及图片，去除所有样式
        public string ClearArticleContent(string content, List<string> regexParams = null)
        {
            string afterClear = content;
            //首先判断有没有需要通过正则清理的内容，正则可能有多条规则，循环遍历来清理
            if (regexParams != null)
            {
                foreach (string regexPattern in regexParams)
                {
                    Regex regReplace = new Regex(regexPattern);
                    if (regReplace.IsMatch(afterClear))
                    {
                        afterClear = regReplace.Replace(afterClear, "");
                    }
                }
            }

            //清理DIV 信息   备选正则：<div("[^"]*"|'[^']*'|[^'">])*>
            Regex regDiv = new Regex(@"<div[^>]+>");
            if (regDiv.IsMatch(afterClear))
            {
                afterClear = regDiv.Replace(afterClear, @"<div>");
            }
            if (afterClear.Contains(@"<div></div>"))
            {
                afterClear = afterClear.Replace(@"<div></div>", "");
            }

            //清理图片信息，使用XPATH
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.LoadHtml(content);
                HtmlAgilityPack.HtmlNodeCollection imageNodes = doc.DocumentNode.SelectNodes("//img");
                if (imageNodes is HtmlAgilityPack.HtmlNodeCollection)
                {
                    foreach (HtmlAgilityPack.HtmlNode imgNode in imageNodes)
                    {
                        string imgUrl = imgNode.Attributes["src"].Value;
                        string replacement = "<img src=\"" + imgUrl + "\">";
                        afterClear = afterClear.Replace(imgNode.OuterHtml, replacement);
                    }
                }
            }
            catch (Exception ex)
            {
                if (IsRecordError)
                {
                    ex.Data.Add("regexParams", regexParams);
                    _coException.Add(ex);
                }
            }
            //清理额外的样式信息
            Regex regAtag = new Regex(@"</?a[^>]*>");
            if (regAtag.IsMatch(afterClear))
            {
                afterClear = regAtag.Replace(afterClear, "");
            }
            Regex regStyle = new Regex("style=\"[^\"]*\"");
            if (regStyle.IsMatch(afterClear))
            {
                afterClear = regStyle.Replace(afterClear, "");
            }
            Regex regClass = new Regex("class=\"[^\"]*\"");
            if (regClass.IsMatch(afterClear))
            {
                afterClear = regClass.Replace(afterClear, "");
            }
            Regex regStrong = new Regex(@"</?strong[^>]*>");
            if (regStrong.IsMatch(afterClear))
            {
                afterClear = regStrong.Replace(afterClear, "");
            }
            Regex regDivClear = new Regex("</?div>");
            if (regDivClear.IsMatch(afterClear))
            {
                afterClear = regDivClear.Replace(afterClear, "");
            }
            afterClear = "<div>" + afterClear;
            afterClear = afterClear + "</div>";
            return afterClear;
        }

        //离线下载用方法
        #region Collect Offline Methods

        //因为离线下载的文章页分页结构为 xxx.xxx.com/test.html; xxx.xxx.com/test_2.html; xxx.xxx.com/test_3.html,
        //所以此处获取分页采用逐步试探的方法，而不用去获取分页区块中的分页信息，
        //在线采集的方式则需要去获取分页快的内容，通过HtmlAgilityPack类结合Xpath去处理
        public List<string> GetArcSubpagesOffline(string arcPath,string arcSubpageSymbol="_",int arcSubpageStartNum=2)
        {
            List<string> arcPages = new List<string>();
            int subPageNumber = arcSubpageStartNum-1;
            string preFileName = Path.GetFileNameWithoutExtension(arcPath);
            string fileExtention = Path.GetExtension(arcPath);
            string dirPath = Path.GetDirectoryName(arcPath);
            while (File.Exists(arcPath))
            {
                arcPages.Add(arcPath);
                subPageNumber = subPageNumber + 1;
                arcPath = dirPath + @"\" + preFileName + arcSubpageSymbol + subPageNumber.ToString() + fileExtention;
            }
            return arcPages;
        }

        //将当前路径下的相对路径转换成绝对路径，如果相对路径是URL结构的，那么将正斜杠替换为反斜杠，及替换成本地路径
        public string GetFullPathOffline(string currentPath, string relPath)
        {
            //查找文件相对于列表路径中 ../出现的次数
            string dirPath = Path.GetDirectoryName(currentPath);
            Regex reg = new Regex(@"\.\./");
            MatchCollection relPathCo = reg.Matches(relPath);
            int count = relPathCo.Count;
            //根据 ../出现的次数去除列表路径中最后的目录，每次去除一个目录
            for (int i = 0; i < count; i++)
            {
                Regex regEndPath = new Regex(@"\\([^\\])*$");
                dirPath = regEndPath.Replace(dirPath, "");
            }
            //将URL路径中的正斜杠 / 替换为文件路径中的反斜杠 （这里要注意相对路径中三种情况，  ../ 不出现， 出现一次， 出现多次
            Regex regRel = new Regex(@"(\.\./)+");
            string relFilePath = regRel.Replace(relPath, "");
            relFilePath = relFilePath.Replace("/", @"\");
            //tboxOutput.AppendText(string.Format("文件名： {0} \n", arcName));
            return dirPath + @"\" + relFilePath;
        }

        //将内容中的图片相对连接全部都转换成绝对路径
        public string ConvImgRelPathOffline(string content, string articlePath)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                doc.LoadHtml(content);
                HtmlAgilityPack.HtmlNodeCollection imageNodes = doc.DocumentNode.SelectNodes("//img");
                foreach (HtmlAgilityPack.HtmlNode imgNode in imageNodes)
                {
                    string imgRelPath = imgNode.Attributes["src"].Value;
                    string imgFullPath = GetFullPathOffline(articlePath, imgRelPath);
                    if (File.Exists(imgFullPath))
                    {
                        content = content.Replace(imgRelPath, imgFullPath);
                    }
                    else
                    {
                        content = content.Replace(imgNode.OuterHtml, "");
                    }
                }
                return content;
            }
            catch (Exception ex)
            {
                if (IsRecordError)
                {
                    ex.Data.Add("articlePath", articlePath);
                    _coException.Add(ex);
                }
                return content;
            }
        }

        //通过指定的文章页路径，获取文章的所有内容
        public Dictionary<string, string> GetArticleContentOffline(string articlePath, string xpathTitleNode, string xpathContentNode, List<string> subNodeParams = null, List<string> regexParams = null, string arcSubpageSymbol = "_", int arcSubpageStartNum = 2)
        {
            Dictionary<string, string> article = new Dictionary<string, string>();
            string arcTitle = "";
            string arcContent = "";
            List<string> articlePages = new List<string>();
            articlePages = GetArcSubpagesOffline(articlePath, arcSubpageSymbol,arcSubpageStartNum);

            HtmlAgilityPack.HtmlDocument arcDoc = new HtmlAgilityPack.HtmlDocument();
            //tboxOutputSingle.AppendText("文档分页连接： \n");
            foreach (string arcPage in articlePages)
            {
                //tboxOutputSingle.AppendText(string.Format("当前页面：{0} \n", arcPage));
                try
                {
                    arcDoc.Load(arcPage, true);
                    if (arcTitle == "")
                    {
                        //HtmlAgilityPack.HtmlNode arcTitleNode = arcDoc.DocumentNode.SelectSingleNode("//div[@class='mian_left']//div[@class='article_title']/h1");
                        HtmlAgilityPack.HtmlNode arcTitleNode = arcDoc.DocumentNode.SelectSingleNode(xpathTitleNode);
                        arcTitle = arcTitleNode.InnerText;
                    }
                    //HtmlAgilityPack.HtmlNode pageContentNode = arcDoc.DocumentNode.SelectSingleNode("//div[@class='mian_left']//div[@class='pre']");
                    HtmlAgilityPack.HtmlNode pageContentNode = arcDoc.DocumentNode.SelectSingleNode(xpathContentNode);
                    string pageContent = pageContentNode.InnerHtml;
                    if (subNodeParams != null)
                    {
                        pageContent = RemoveSubNode(pageContent, subNodeParams);     //清除页面内容当中指定的节点
                    }
                    pageContent = ClearArticleContent(pageContent, regexParams);  //去除页面中的DIV样式
                    arcContent = arcContent + pageContent;
                }
                catch (Exception ex)
                {
                    if (IsRecordError)
                    {
                        ex.Data.Add("articlePath", articlePath);
                        ex.Data.Add("xpathTitleNode", xpathTitleNode);
                        ex.Data.Add("xpathContentNode", xpathContentNode);
                        _coException.Add(ex);
                    }
                }
            }
            arcContent = ConvImgRelPathOffline(arcContent, articlePath);
            article.Add("title", arcTitle);
            article.Add("url", articlePath);
            article.Add("content", arcContent);
            return article;
            //tboxOutput.AppendText(string.Format("文章标题：{0} \n", arcTitle));
            //tboxOutput.AppendText(string.Format("文章内容：\n {0} \n", arcContent));
        } // end of getArticleConetent();


        //通过指定的列表页路径和页码的起始范围，获取所有的列表页
        private object listPagesAddLock = new object();
        public List<string> GetListPagesOffline(string listPath, int startPageNumber, int stopPageNumber)
        {
            _currentProcessedListPages = 0;
            List<string> listPages = new List<string>();
            Regex regPage = new Regex(@"\(\*\)");
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = CancelToken.Token;
            try
            {
                Parallel.For(startPageNumber, stopPageNumber, po, pageNum =>
                {
                    po.CancellationToken.ThrowIfCancellationRequested();
                    string pageUrl = regPage.Replace(listPath, pageNum.ToString());
                    if (File.Exists(pageUrl))
                    {
                        lock (listPagesAddLock)
                        {
                            listPages.Add(pageUrl);
                            _currentProcessedListPages = listPages.Count;
                        }
                    }
                });
            }
            catch (OperationCanceledException exCancel)
            {
                _cancelException = exCancel;
                _cancelException.Data.Add("CurrentProcessedListPages", _currentProcessedListPages);
                int totalListPages = stopPageNumber - startPageNumber + 1;
                _cancelException.Data.Add("TotalListPages", totalListPages);

            }
            return listPages;
        }

        //检查匹配文章标题和内容的Xpath标签是否能正确匹配到内容
        public bool CheckArticleOffline(string articlePath, string xpathTitleNode, string xpathContentNode,ref string arcTitle)
        {
            arcTitle = "";
            string arcContent = "";
            HtmlAgilityPack.HtmlDocument arcDoc = new HtmlAgilityPack.HtmlDocument();
            try
            {
                arcDoc.Load(articlePath, true);
                HtmlAgilityPack.HtmlNode arcTitleNode = arcDoc.DocumentNode.SelectSingleNode(xpathTitleNode);
                if (arcTitleNode is HtmlAgilityPack.HtmlNode)
                {
                    arcTitle = arcTitleNode.InnerText;
                }
                HtmlAgilityPack.HtmlNode pageContentNode = arcDoc.DocumentNode.SelectSingleNode(xpathContentNode);
                if (pageContentNode is HtmlAgilityPack.HtmlNode)
                {
                    arcContent = pageContentNode.InnerHtml;
                }
                if (arcTitle != "" && arcContent != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (IsRecordError)
                {
                    ex.Data.Add("articlePath", articlePath);
                    ex.Data.Add("xpathTitleNode", xpathTitleNode);
                    ex.Data.Add("xpathContentNode", xpathContentNode);
                    _coException.Add(ex);
                }
                return false;
            }
        }
        //获取所有文章URL集合，返回结果中包括能正确匹配内容和不能匹配的两组list
        private object correctAddLock=new object();
        private object wrongAddLock=new object();
        private object exceptionAddLock=new object();
        public Dictionary<string, List<Dictionary<string, string>>> GetArticlePagesOffline(List<string> listPages, string xpathArcurlNode, string xpathTitleNode, string xpathContentNode)
        {
            _currentProcessedListPages = 0;
            _currentGetArticlePages = 0;
            Dictionary<string, List<Dictionary<string, string>>> dicArticles = new Dictionary<string, List<Dictionary<string, string>>>();
            List<Dictionary<string, string>> correctListArticles = new List<Dictionary<string, string>>();
            List<Dictionary<string, string>> wrongListArticles = new List<Dictionary<string, string>>();

            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = CancelToken.Token;
            try
            {
                Parallel.ForEach(listPages, po, listSinglePage =>
                {
                    po.CancellationToken.ThrowIfCancellationRequested();
                    HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
                    try
                    {
                        doc.Load(listSinglePage, true);
                        HtmlAgilityPack.HtmlNodeCollection arcHrefs = doc.DocumentNode.SelectNodes(xpathArcurlNode);
                        foreach (HtmlAgilityPack.HtmlNode item in arcHrefs)
                        {
                            string arcUrl = item.Attributes["href"].Value;
                            string arcPath = GetFullPathOffline(listSinglePage, arcUrl);
                            if (File.Exists(arcPath))
                            {
                                string arcTitle = "";
                                if (CheckArticleOffline(arcPath, xpathTitleNode, xpathContentNode,ref arcTitle))
                                    lock (correctAddLock)
                                    {
                                        Dictionary<string, string> oneArticleInfo = new Dictionary<string, string>();
                                        oneArticleInfo["arcpath"] = arcPath;
                                        oneArticleInfo["arctitle"] = arcTitle;
                                        correctListArticles.Add(oneArticleInfo);
                                        _currentGetArticlePages = correctListArticles.Count();
                                    }
                                else
                                    lock (wrongAddLock)
                                    {
                                        Dictionary<string, string> oneArticleInfo = new Dictionary<string, string>();
                                        oneArticleInfo["arcpath"] = arcPath;
                                        oneArticleInfo["arctitle"] = arcTitle;
                                        wrongListArticles.Add(oneArticleInfo);
                                    }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        if (IsRecordError)
                        {
                            ex.Data.Add("listurl", listSinglePage);
                            ex.Data.Add("xpathArcurlNode", xpathArcurlNode);
                            lock (exceptionAddLock)
                            {
                                _coException.Add(ex);
                            }
                        }
                    }
                    Interlocked.Add(ref _currentProcessedListPages, 1); //将当前处理列表页面数+1，因为是多线程，所以用原子锁方式相加
                });
            }
            catch (OperationCanceledException exCancel)
            {
                _cancelException = exCancel;
                _cancelException.Data.Add("CurrentProcessedListPages", _currentProcessedListPages);
                _cancelException.Data.Add("TotalListPages", listPages.Count());
                _cancelException.Data.Add("CurrentGetArticlePages", _currentGetArticlePages);
            }

            dicArticles.Add("correct", correctListArticles);
            dicArticles.Add("wrong", wrongListArticles);
            return dicArticles;     //返回所有能正确采集和不能正确采集的文章URL集合
        }

        //private object coParallelLock = new object(); //多线程采集中的线程锁
        //给定指定的文章页集合，采集文章内容
        private object articleAddLock=new object();
        public List<Dictionary<string, string>> CoArticlesOffline(List<string> articlePages, string xpathArcurlNode, string xpathTitleNode, string xpathContentNode, List<string> subNodeParams = null, List<string> regexParams = null, string arcSubpageSymbol = "_", int arcSubpageStartNum = 2)
        {
            //创建用来返回最终文章的List
            _currentProcessedArticles = 0;
            List<Dictionary<string, string>> articleList = new List<Dictionary<string, string>>();
            ParallelOptions po = new ParallelOptions();
            po.CancellationToken = CancelToken.Token;
            try
            {
                if (articlePages!=null)
                {
                    Parallel.ForEach(articlePages, po, articlePath =>
                    {
                        po.CancellationToken.ThrowIfCancellationRequested();
                        Dictionary<string, string> article;
                        article = GetArticleContentOffline(articlePath, xpathTitleNode, xpathContentNode, subNodeParams, regexParams, arcSubpageSymbol, arcSubpageStartNum);
                        lock (articleAddLock)
                        {
                            articleList.Add(article);
                            _currentProcessedArticles = articleList.Count();
                        }
                    });
                }

            }
            catch (OperationCanceledException exCancel)
            {
                _cancelException = exCancel;
                _cancelException.Data.Add("CurrentProcessedArticles", _currentProcessedArticles);
                _cancelException.Data.Add("TotalArticles", articlePages.Count);
            }
            return articleList;   //返回所有采集文章集合
        }

        #endregion  Collect Offline Methods

        #endregion  Public Methods
    }
}
