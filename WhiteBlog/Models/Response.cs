namespace WhiteBlog.Models
{
    public class Response<T>
    {
        public int status { set; get; }
        public int errorCode { set; get; }
        public string errorMsg { set; get; }
        public T resultBody { set; get; }
    }
}