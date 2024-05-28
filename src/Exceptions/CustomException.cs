namespace CodeCrafters_backend_teamwork.src.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public CustomException(int status, string message)
        {
            StatusCode = status;
            Message = message;
        }


        static public CustomException NotFound(string message)
        {
            return new CustomException(404, message);
        }
        static public CustomException Forbidden(string message)
        {
            return new CustomException(401, message);
        }        
    }
}