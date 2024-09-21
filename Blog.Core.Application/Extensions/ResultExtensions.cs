using Blog.Core.Application.Core;
using Blog.Core.Application.Utls.Enums;


namespace Blog.Core.Application.Extensions
{
	 public static class ResultExtensions
	{
		/// <summary>
		/// Return's a result base on the error type use to represent the error thrown in an operation or process 
		/// </summary>
		/// <param name="errors"></param>
		/// <param name="errorMessage"></param>
		/// <returns></returns>
		public static Result Because(this ErrorTypess errors, string errorMessage) => Result.Failure(errorMessage, errors);



	}
}
    