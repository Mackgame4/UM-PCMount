namespace PCMount.Services;

using PCMount.Data.Models;

public class OrdersService {
    private readonly List<String> _orders = [];

    public OrdersService()
    {
        //var User1 = new User(){ UserName = "admin", Password = "admin", Id = 1, Role = "Admin" };
        //_userAccounts.Add(User1);
    }

    /*public async Task<int> AddUserAccountAsync(User userAccount)
    {
        userAccount.Id = _userAccounts.Count + 1;
        _userAccounts.Add(userAccount);
        return await Task.FromResult(userAccount.Id);
    }*/
}