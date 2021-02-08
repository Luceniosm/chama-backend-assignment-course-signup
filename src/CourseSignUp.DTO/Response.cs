namespace CourseSignUp.DTO
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Error { get; set; }
        public T Data { get; set; }

        public Response(bool success, string error, T data)
        {
            Success = success;
            Error = error;
            Data = data;
        }
    }
}
