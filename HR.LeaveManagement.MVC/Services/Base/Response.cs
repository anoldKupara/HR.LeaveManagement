﻿namespace HR.LeaveManagement.MVC.Services.Base
{
    public class Response <T>
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public string ValidationErrors { get; set; }
        public T Data { get; set; }
    }
}
