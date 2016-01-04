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
        private long _cid;                                                                              //采集规则ID
        private string _typeName;                                                                //采集所属分类
        private long _typeID;                                                                        //采集所属分类ID
        private string _sourceSite;                                                                //采集来源网址
        private string _listPath;                                                                     //列表页本地路径
        private int _listStartPageNumber;                                                    //列表页起始页面编号
        private int _listStopPageNumber;                                                    //列表页起始页面编号
        private string _xpathArcurlNode;                                                     //列表页文章URL Xpath表达式
        private string _xpathTitleNode;                                                         //文章页文章标题 Xpath表达式
        private string _xpathContentNode;                                                  //文章页文章内容 Xpath表达式
        private string _arcSubpageSymbol;                                                  //文章页分页所使用的分页表达式， 默认是"_"
        private int _arcSubpageStartNum;                                                   //文章页分页默认的起始编号，使用webdup离线下载的内容默认都是起始为2，海报的在线URL中默认的起始为1，后续在线采集的时候需要传入对应参数。
        private List<string> _subNodeParams;                                            //文章内容中需要清理的 子节点Xpath表达式集合
        private List<string> _regexParams;                                                 //文章内容中需要清理的 正则表达式集合
        private ArticleCollectCore _collectOffline;                                       //类型为 ArticleCollectCore的对象，所有采集处理工作都是通过此核心类来完成
        private List<Dictionary<string, string>> _correctArticlePages;     //能正确获取 _xpathTitleNode 和 _xpathContentNode 表达式内容的文章URL和标题集合
        private List<Dictionary<string, string>> _wrongArticlePages;      //不能正确获取 _xpathTitleNode 和 _xpathContentNode 表达式内容的文章URL和标题集合
        private List<string> _listPages;                                                        //所有列表页URL的结合
        private List<Dictionary<string, string>> _articles;                         //采集完成后，所有文章内容的集合。包括：文章标题：“title”，文章本地路径：“url”，文章内容：“content”
        private bool _isRecordError;                                                            //是否开启错误记录
        private CancellationTokenSource _cancelToken;                           //用来获取取消事件的对象
        private string _coState = "";                                                           //保存当前采集状态
        private int _savedArticleNums=0;                                                //保存当前已经储存到数据库的采集文章数


        #endregion

        #region Constructors



        public ArticleCollectOffline(long cid,string listPath,int startPageNumber, int stopPageNumber,string xpathArcurlNode, string xpathTitleNode, string xpathContentNode, List<string> subNodeParams=null, List<string> regexParams=null, string arcSubpageSymbol = "_", int arcSubpageStartNum = 2)
        {
            _cid = cid;
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
        //返回采集规则ID
        public long Cid
        {
            get { return _cid; }
        }
        //返回采集文章保存分类
        public string TypeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }
        //返回采集文章保存分类ID
        public long TypeID
        {
            get { return _typeID; }
            set { _typeID = value; }
        }
        //返回采集来源网址
        public string SourceSite
        {
            get { return _sourceSite; }
            set { _sourceSite = value; }
        }
        //返回列表页路径
        public string ListPath
        {
            get { return _listPath; }
        }
        //返回列表页起始页面编号
        public int ListStartPageNumber  
        {
            get { return _listStartPageNumber; }
        }
        //返回列表页结束页面编号
        public int ListStopPageNumber  
        {
            get { return _listStopPageNumber; }
        }
        //返回列表页中文章URL匹配Xpath规则
        public string XpathArcurlNode
        {
            get { return _xpathArcurlNode;}
        }
        //返回标题匹配Xpath规则
        public string XpathTitleNode
        {
            get { return _xpathTitleNode; }
        }
        //返回内容匹配Xpath 规则
        public string XpathContentNode
        {
            get { return _xpathContentNode; }
        }
        //返回内容分页中的分页符
        public string ArcSubpageSymbol
        {
            get { return _arcSubpageSymbol; }
        }
        //返回内容分页起始编号
        public int ArcSubpageStartNum
        {
            get { return _arcSubpageStartNum; }
        }
        //返回去除指定子节点XPATH规则集合
        public List<string> SubNodeParams
        {
            get { return _subNodeParams; }
        }
        //返回去除指定内容正则集合
        public List<string> RegexParams
        {
            get { return _regexParams; }
        }
        //获取或修改是否保存错误异常
        public bool IsRecordError
        {
            get { return _isRecordError; }
            set
            {
                _isRecordError = value;
                _collectOffline.IsRecordError = value;
            }
        }
        //获取或修改取消令牌
        public CancellationTokenSource CancelToken
        {
            get { return _cancelToken; }
            set
            {
                _cancelToken = value;
                _collectOffline.CancelToken = value;
            }
        }
        //返回采集错误异常集合
        public List<Exception> CoException
        {
            get { return _collectOffline.CoException; }
        }
        //返回取消异常
        public Exception CancelException
        {
            get { return _collectOffline.CancelException; }
        }
        //返回正确匹配文章URL集合，一般修改是在采集前判断数据库中是否有重复采集记录，需要剔除重复采集记录
        public List<Dictionary<string, string>> CorrectArticlePages
        {
            get { return _correctArticlePages; }
            set { _correctArticlePages = value; }

        }
        //返回错误匹配文章URL集合
        public List<Dictionary<string, string>> WrongArticlePages
        {
            get { return _wrongArticlePages; }
        }
        //返回或修改匹配列表页集合
        public List<string> ListPages
        {
            get { return _listPages; }
        }
        //返回核心采集对象
        public ArticleCollectCore CollectOffline
        {
            get { return _collectOffline; }
        }
        //返回采集完成文章的集合，每一个集合中包含：文章标题：“title”，文章本地路径：“url”，文章内容：“content”
        public List<Dictionary<string, string>> Articles
        {
            get { return _articles;  }
        }
        //当前采集的文章数
        public int CurrentProcessedArticles
        {
            get { return _collectOffline.CurrentProcessedArticles; }
        }
        //当前获取列表页数
        public int CurrentProcessedListPages
        {
            get { return _collectOffline.CurrentProcessedListPages; }
        }
        //当前获取的文章URL数
        public int CurrentGetArticlePages
        {
            get { return _collectOffline.CurrentGetArticlePages; }
        }
        //返回当前已经储存到数据库的采集文章数
        public  int CurrentSavedArticles
        {
            get { return _savedArticleNums; }
            set { _savedArticleNums = value; }
        }
        //去除数据库已采集记录后剩下需要采集的文章数量, 通过统计 _correctArticlePages集合来计算
        public int CurrentNeedConums
        {
            get
            {
                if (_correctArticlePages == null)
                    return 0;
                else
                    return _correctArticlePages.Count();
            }
        }

        //当前采集状态
        public string CoState
        {
            get { return _coState; }
            set { _coState = value; }
        }



        #endregion

        #region Public Methods
        //增加手工指定的列表页
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
            _coState = "获取列表页";
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
            _coState = "获取文章页";
            Dictionary<string, List<Dictionary<string, string>>> dicListArticles = _collectOffline.GetArticlePagesOffline(_listPages,_xpathArcurlNode,_xpathTitleNode,_xpathContentNode);
            _correctArticlePages = dicListArticles["correct"];
            _wrongArticlePages = dicListArticles["wrong"];
        }


        //给定指定的文章页集合，采集文章内容

        public void ProcessCollectArticles()
        {
            _coState = "采集文章";
            //创建用来返回最终文章的List
            List<string> articleUrls = new List<string>();
            foreach (Dictionary<string,string> item in _correctArticlePages)
            {
                articleUrls.Add(item["arcpath"]);
            }
            _articles = _collectOffline.CoArticlesOffline(articleUrls, _xpathArcurlNode, _xpathTitleNode, _xpathContentNode, _subNodeParams, _regexParams,_arcSubpageSymbol,_arcSubpageStartNum);
            //_coState = "采集结束";
        }

        #endregion

        #region Private Methods

        #endregion



    }
}
