using Microsoft.AspNetCore.Identity;

namespace JobsAds.API.Presentation.Models
{
    public class ResultViewModel
    {
     
        public bool  IsSuccess { get; set; }
        public string   Message { get; set; }


        public ResultViewModel(bool isSuccess = true, string message = "")
        {
            IsSuccess = isSuccess;
            Message = message;
        }

        public static ResultViewModel Success()
            => new ResultViewModel();

        public static ResultViewModel Erro(string message)
            => new ResultViewModel(false, message);
    }



    public class ResultViewModel<T> : ResultViewModel
    {
        public T? Data { get; set; }

        public ResultViewModel(T? data, bool isSuccess = true, string message = "")
            : base(isSuccess, message)
        {
            Data = data;
        }

        public static ResultViewModel<T> Success(T? data)
            => new ResultViewModel<T>(data);

        public static ResultViewModel<T> Error(string message)
            => new ResultViewModel<T>(default, false, message);
    }
}
