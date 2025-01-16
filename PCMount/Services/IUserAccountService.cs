namespace PCMount.Services;

using PCMount.Data.Models;

public interface IUserAccountService {
    Task<User?> GetUserAccountAsync(string username);

    Task<IEnumerable<User>> GetAccountsAsync();

    Task<int> AddUserAccountAsync(User userAccount);

    Task<bool> UpdateUserAccountAsync(User userAccount);

    Task<bool> DeleteUserAccountAsync(User userAccount);
}