namespace LibraryManagementSystem.Infrastructure.Message
{
	// keyword 'in' can be used to mark T as contravariant, which allows us to substitute any sub-type of T
	// 'in' can only be used in input position.

	// keyword 'out' can be used to mark T as covariant, which means we can pass in any type which is more derived than 'T' as the type argument,
	// 'out' can be used in output position only
	public interface ISystemMessageList<in T> where T: class
	{
		void AddMessage(T message);
		void AddErrorMessage(string message);
		void AddInfoMessage(string message);
		void AddSuccessMessage(string message);
		void AddWarningMessage(string message);
	}
}
