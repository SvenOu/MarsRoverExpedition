namespace MarsRoverExpedition.modules.common.Model
{
    public class PaginationParam
    {
        /// <summary>
        /// 可选
        /// 默认 1
        /// </summary>

        private int _pageId = 1;
        public virtual int PageId
        {
            get
            {
                if (_pageId <= 0)
                    return 1;
                else 
                    return _pageId;
            }
            set
            {
                if (value <= 0) {
                    _pageId = 1;
                }
            }
        }

        /// <summary>
        /// 可选
        /// 默认 5
        /// </summary>
        private int _onePageCount = 5;
        public virtual int OnePageCount
        {
            get
            {
                if (_onePageCount <= 0)
                    return 5;
                else 
                    return _onePageCount;
            }
            set { if (value <= 0) _onePageCount = 5; }
        }
    }
}