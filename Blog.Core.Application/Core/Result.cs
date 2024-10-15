
using Blog.Core.Application.Utls.Enums;

namespace Blog.Core.Application.Core
{
	/// <summary>
	/// Represent the result of an operation that does not return data
	/// </summary>
	public class Result
	{
		/// <summary>
		/// Base constructure for the result
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorType"></param>
		/// <param name="isSuccess"></param>
        public Result(string message, ErrorTypess errorType, bool isSuccess)
        {
            Message = message;
			ErrorType = errorType.ToString();
			IsSuccess = isSuccess;
        }
		/// <summary>
		/// Initialize a result set to failure
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorTypess"></param>
        public Result(string message, ErrorTypess errorTypess)
        {
            Message = message;
			ErrorType = errorTypess.ToString();
			IsSuccess = false;
        }
		/// <summary>
		/// Initialize a result set to success
		/// </summary>
		/// <param name="message"></param>
        public Result(string message)
        {
			Message = message;
			ErrorType = ErrorTypess.None.ToString();
			IsSuccess = true;
        }

        public bool IsSuccess { get; }
		public string ErrorType { get; }
		public string Message { get; }

		/// <summary>
		/// Return's a result for a successfull operation
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static Result Success(string message = "Operation was completed successfully") => new(message);
		/// <summary>
		/// Return's a result for a failed operation
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorTypess"></param>
		/// <returns></returns>
		public static Result Failure(ErrorTypess errorTypess, string message = "Error while doing the operation") => new(message, errorTypess);
	}



	/// <summary>
	/// Represent's the result of a operation that return's data 
	/// </summary>
	/// <typeparam name="TData"></typeparam>
	public class Result<TData> 
		where TData : class
	{
		/// <summary>
		/// Base constructure for the result class
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorTypess"></param>
		/// <param name="isSuccess"></param>
		/// <param name="data"></param>
        public Result(string message, ErrorTypess errorTypess, bool isSuccess , TData data)
        {
            Message= message;
			ErrorType = errorTypess.ToString();
			IsSuccess = isSuccess;
			Data = data;
        }
		/// <summary>
		/// Constructure for casting a Result to a Result<Data>
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorType"></param>
		/// <param name="isSuccess"></param>
        Result(string message, string errorType, bool isSuccess)
        {
			Message = message;
			ErrorType = errorType;
			IsSuccess = isSuccess;
			Data = default;
        }
		/// <summary>
		/// Initialize a result for a successfull operation
		/// </summary>
		/// <param name="message"></param>
		/// <param name="data"></param>
        public Result(string message, TData data)
        {
			Message = message;
			Data = data;
			IsSuccess = true;
			ErrorType = ErrorTypess.None.ToString();
        }
		/// <summary>
		/// Initialize a result for a failed operation
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorTypess"></param>
        public Result(string message, ErrorTypess errorTypess)
        {
			Message = message;
			ErrorType = errorTypess.ToString();
			IsSuccess = false;
			Data = default;
        }

        public bool IsSuccess { get;  }
		public string? ErrorType { get;  }
		public string Message { get;  } = string.Empty;
		public TData? Data { get;  }

		/// <summary>
		/// Return's a result set to a success state
		/// </summary>
		/// <param name="message"></param>
		/// <param name="data"></param>
		/// <returns></returns>
		public static Result<TData> Success(TData data, string message = "Operation was completed successfully") => new(message, data);

		/// <summary>
		/// Return's a result set to a failure state
		/// </summary>
		/// <param name="message"></param>
		/// <param name="errorTypess"></param>
		/// <returns></returns>
		public static Result<TData> Failure(ErrorTypess errorTypess , string message = "Error while doing the operation") => new(message, errorTypess);

		public static implicit operator Result<TData>(TData data) => new("Operation was completed succesfullty", data);

		public static implicit operator Result<TData>(Result result) => new(result.Message, result.ErrorType, result.IsSuccess);
		

	}
}
