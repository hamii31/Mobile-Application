namespace PetAdoptionMobileApplication.Common.DTOs
{
	public record APIResponse(bool IsSuccess, string? Message = null)
	{
		public static APIResponse Success() => new(true, null); // if success, return true with no message
		public static APIResponse Fail(string? message) => new(false, message); // if failed, return false for IsSuccess and a corresponding error message
	}

	public record APIResponse<TData>(bool IsSuccess, TData Data, string? Message)
	{
		public static APIResponse<TData> Success(TData data) => new(true, data, null); // same, but return Tdata as well
		public static APIResponse<TData> Fail(string? message) => new(false, default!, message); // return default data (preferably empty collection) and error message
	}
}
