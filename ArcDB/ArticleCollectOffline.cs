using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using System.IO;
using System.Diagnostics;
using System.Threading;


namespace ArticleCollect
{
    class ArticleCollectOffline
    {
        #region Fields
        private string _listPath;                                                      //列表页本地路径
        private int _listStartPageNumber;                                     //列表页起始页面编号
        private int _listStopPageNumber;                                     //列表页起始页面编号
        private string _xpathArcurlNode;                                      //列表页文章URL Xpath表达式
        private string _xpathTitleNode;                                        //文章页文章标题 Xpath表达式
        private string _xpathContentNode;                                  //文章页文章内容 Xpath表达式
        private string _arcSubpageSymbol;                                  //文章页分页所使用的分页表达式， 默认是"_"
        private int _arcSubpageStartNum;                                   //文章页分页默认的起始编号，使用webdup离线下载的内容默认都是起始为2，海报的在线URL中默认的起始为1，后续在线采集的时候需要传入对应参数。
        private List<string> _subNodeParams;                            //文章内容中需要清理的 子节点Xpath表达式集合
        private List<string> _regexParams;                                  //文章内容中需要清理的 正则表达式集合
        private ArticleCollectCore _collectOffline;                        //类型为 ArticleCollectCore的对象，所有采集处理工作都是通过此核心类来完成
        private List<string> _correctArticlePages;                       //能正确获取 _xpathTitleNode 和 _xpathContentNode 表达式内容的文章URL集合
        private List<string> _wrongArticlePages;                        //不能正确获取 _xpathTitleNode 和 _xpathContentNode 表达式内容的文章URL集合
        private List<string> _listPages;                                        //所有列表页URL的结合
        private List<Dictionary<string, string>> _articles;          //采集完成后，所有文章内容的集合。包括：文章标题：“title”，文章本地路径：“url”，文章内容：“content”
        private bool _isRecordError;                                             //是否开启错误记录
        private CancellationTokenSource _cancelToken;             //用来获取取消事件的对象


        #endregion

        #region Constructors



        public ArticleCollectOffline(string listPath,int startPageNumber, int stopPageNumber,string xpathArcurlNode, string xpathTitleNode, string xpathContentNode, List<string> subNodeParams=null, List<string> regexParams=null, string arcSubpageSymbol = "_", int arcSubpageStartNum = 2)
        {
            _listPath = listPath;
            _listStartPageNumber = startPageNumber;
            _listStopPageNumber = stopPageNumber;
            _xpathArcurlNode = xpathArcurlNode;
            _xpathTitleNode = xpathTitleNode;
            _xpathContentNode = xpathContentNode;
            _subNodeParams = subNodeParams;
            _regexParams = regexParams;
            _arcSubpageSymbol = arcSubpageSymbol;
            _arcSubpageStartNum = arcSubpageStartNum;
            _collectOffline = new ArticleCollectCore(true);
        }

        #endregion

        #region Properties

        public string ListPath
        {
            get { return _listPath; }
        }

        public int ListStartPageNumber  //列表页起始页面编号
        {
            get { return _listStartPageNumber; }
        }

        public int ListStopPageNumber  //列表页结束页面编号
        {
            get { return _listStopPageNumber; }
        }

        public string XpathArcurlNode
        {
            get { return _xpathArcurlNode;}
        }

        public string XpathTitleNode
        {
            get { return _xpathTitleNode; }
        }

        public string XpathContentNode
        {
            get { return _xpathContentNode; }
        }
        public string ArcSubpageSymbol
        {
            get { return _arcSubpageSymbol; }
        }
        public int ArcSubpageStartNum
        {
            get { return _arcSubpageStartNum; }
        }

        public List<string> SubNodeParams
        {
            get { return _subNodeParams; }
        }

        public List<string> RegexParams
        {
            get { return _regexParams; }
        }

        public bool IsRecordError
        {
            get { return _isRecordError; }
            set
            {
                _isRecordError = value;
                _collectOffline.IsRecordError = value;
            }
        }
        public CancellationTokenSource CancelToken
        {
            get { return _cancelToken; }
            set
            {
                _cancelToken = value;
                _collectOffline.CancelToken = value;
            }
        }
        public List<Exception> CoException
        {
            get { return _collectOffline.CoException; }
        }
        public Exception CancelException
        {
            get { return _collectOffline.CancelException; }
        }

        public List<string> CorrectArticlePages
        {
            get { return _correctArticlePages; }
        }

        public List<string> WrongArticlePages
        {
            get { return _wrongArticlePages; }
        }

        public List<string> ListPages
        {
            get { return _listPages; }
            set { _listPages = value; }
        }

        public ArticleCollectCore CollectOffline
        {
            get { return _collectOffline; }
        }

        public List<Dictionary<string, string>> Articles
        {
            get { return _articles;  }
        }
        public int CurrentProcessedArticles
        {
            get { return _collectOffline.CurrentProcessedArticles; }
        }
        public int CurrentProcessedListPages
        {
            get { return _collectOffline.CurrentProcessedListPages; }
        }
        public int CurrentGetArticlePages
        {
            get { return _collectOffline.CurrentGetArticlePages; }
        }


        #endregion

        #region Public Methods

        public void AddListPages(List<string> moreListPages)
        {
            if (_listPages==null)
            {
                _listPages = moreListPages;
            }
            else
            {
                foreach (string item in moreListPages)
                {
                    _listPages.Add(item);
                }
            }
        }

        //通过指定的列表页路径和页码的起始范围，获取所有的列表页
        public void ProcessListPages()
        {
            List<string>tempListPages = _collectOffline.GetListPagesOffline(_listPath,_listStartPageNumber,_listStopPageNumber);
            if (_listPages==null)
            {
                _listPages = tempListPages;
            }
            else
            {
                AddListPages(tempListPages);
            }
        }

        //获取所有文章集合，返回结果中包括能正确匹配内容和不能匹配的两组list
        public void ProcessArticlePages()
        {
            Dictionary<string, List<string>> dicListArticles = _collectOffline.GetArticlePagesOffline(_listPages,_xpathArcurlNode,_xpathTitleNode,_xpathContentNode);
            _correctArticlePages = dicListArticles["correct"];
            _wrongArticlePages = dicListArticles["wrong"];
        }


        //给定指定的文章页集合，采集文章内容

        public void ProcessCollectArticles()
        {
            //创建用来返回最终文章的List
            _articles = _collectOffline.CoArticlesOffline(_correctArticlePages, _xpathArcurlNode, _xpathTitleNode, _xpathContentNode, _subNodeParams, _regexParams,_arcSubpageSymbol,_arcSubpageStartNum);
        }

        #endregion

        #region Private Methods

        #endregion



    }
}
