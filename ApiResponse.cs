namespace http_api_minimal_student{
    class ApiResponse<T>{
        public ApiResponse(int code, string message, T? data){
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        public int Code {get; set;}
        public string Message {get; set;}
        public T? Data {get; set;}
    }
}