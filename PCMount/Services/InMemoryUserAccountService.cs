namespace PCMount.Services;

using PCMount.Data.Models;

public class InMemoryUserAccountService : IUserAccountService {
    private readonly List<User> _userAccounts = [];

    public InMemoryUserAccountService()
    {
        var User1 = new User(){
            UserName = "admin",
            Password = "admin",
            Id = 1,
            Role = "Admin"
        };
        _userAccounts.Add(User1);
    }

    public async Task<int> AddUserAccountAsync(User userAccount)
    {
        userAccount.Id = _userAccounts.Count + 1;
        _userAccounts.Add(userAccount);
        return await Task.FromResult(userAccount.Id);
    }

    public Task<bool> DeleteUserAccountAsync(User userAccount)
    {
        return Task.FromResult(_userAccounts.Remove(userAccount));
    }

    public async Task<IEnumerable<User>> GetAccountsAsync()
    {
        await Task.CompletedTask;
        return _userAccounts;
    }

    public async Task<User?> GetUserAccountAsync(string username)
    {
        User? account = _userAccounts.FirstOrDefault(a => a.UserName == username);
        return await Task.FromResult(account );
    }

    public Task<bool> UpdateUserAccountAsync(User userAccount)
    {
        var existingAccount = _userAccounts.FirstOrDefault(a => a.Id == userAccount.Id);
        if (existingAccount != null)
        {
            existingAccount.UserName = userAccount.UserName;
            existingAccount.Password = userAccount.Password;
            return Task.FromResult(true);
        }

        return Task.FromResult(false);
    }
}