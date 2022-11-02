using HR.LeaveManagement.MVC.Contracts;
using System;

namespace HR.LeaveManagement.MVC.Services.Base
{
    public class BaseHttpService
    {
        protected  IClient _client;
        protected readonly ILocalStorageService _localStorage;

        public BaseHttpService(IClient client, ILocalStorageService localStorage)
        {
            _client = client;
            _localStorage = localStorage;
        }

        protected Response<Guid> ConvertApiExceptions<Guid>(ApiException ex)
        {
            if(ex.StatusCode == 400)
            {
                return new Response<Guid>() { Message = "Validation Errors hasd occured.", ValidationErrors = ex.Response };
            } else if(ex.StatusCode == 404)
            {
                return new Response<Guid>() { Message = "The requested item could not be find" };
            }
            else
            {
                return new Response<Guid>() { Message = "Something went wrong, Please try again",  };
            }
        }

        protected void AddBearerToken()
        {
            if (_localStorage.Exists("token"))
                _client.HttpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _localStorage.GetStorageValue<string>("token"));
        }
    }
}
