namespace MarsRoverExpedition.modules.common.Model
{
    public static class RepCode
    {
        public const int Ok = 0;
        public const int Fail1 = -1;
    
    }
    public static class RepMsg
    {
        public const string Ok = "ok";
        public const string Fail = "fail";
    }
    /// <summary>
    /// 基础响应格式, 应该统一应用于service层的返回值
    /// </summary>
    public class CommonResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        
        public static CommonResponse<T> Success(T data = default, string message = RepMsg.Ok, int code = RepCode.Ok)
        {
            return new CommonResponse<T> {Data = data, Message = message, Code = code};
        }
        public static CommonResponse<T> Fail(string message = RepMsg.Fail, int code = RepCode.Fail1, T data = default)
        {
            return new CommonResponse<T> {Data = data, Message = message, Code = code};
        }
    }
    /// <summary>
    /// 基础响应格式, 应该统一应用于service层的返回值
    /// </summary>
    public class CommonPaginationResponse<T>
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public int PageId { get; set; }
        public int OnePageCount { get; set; }
        
        public long TotalCount { get; set; }
        
        public static CommonPaginationResponse<T> Success(
            T data = default, 
            int pageId = 0,
            int onePageCount = 0,
            long totalCount = 0,
            string message = RepMsg.Ok, 
            int code = RepCode.Ok)
        {
            return new CommonPaginationResponse<T>
            {
                Data = data, 
                Message = message,
                Code = code, 
                PageId= pageId, 
                OnePageCount = onePageCount,
                TotalCount = totalCount,
            };
        }
        public static CommonPaginationResponse<T> Fail(
            string message = RepMsg.Fail, 
            int code = RepCode.Fail1, 
            T data = default)
        {
            return new CommonPaginationResponse<T>
            {
                Data = data, 
                Message = message,
                Code = code,
            };
        }
    }
}