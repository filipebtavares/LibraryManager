namespace LibraryManager.Api.Presentation.Model
{
    public class ResultViewModel
    {
        public bool IsSucess { get; private set; }
        public string Message { get; private set; }

        public ResultViewModel(bool isSucess = true, string message = "")
        {
            IsSucess = isSucess;
            Message = message;
        }

        public static ResultViewModel Success()
            => new ResultViewModel();

        public static ResultViewModel Error(string message)
            => new ResultViewModel(false, message);

    }

    public class ResultViewModel<T> : ResultViewModel
    {
        public T? Data { get; private set; }

        public ResultViewModel(T? data, bool isSucess = true, string message = "") : base(isSucess, message)
        {
            Data = data;
        }

      
        public static ResultViewModel<T> Success(T? data)
            => new ResultViewModel<T>(data);

        public static ResultViewModel<T> Error(string message)
            => new ResultViewModel<T>(default, false, message);
    }
}
