namespace PCMount.Services;

using Microsoft.EntityFrameworkCore;
using PCMount.Data;
using PCMount.Data.Models;

public class OrdersService(ApplicationDbContext dbContext)
{
    private readonly ApplicationDbContext _dbContext = dbContext;
    private static readonly SemaphoreSlim semaphore = new(1, int.MaxValue); // Semaphore to ensure single access to DbContext

    public async Task<Order[]> GetOrdersAsync() {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            return await _dbContext.Orders.AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release(); // Release the lock
        }
    }

    public async Task<Order?> DeleteOrderAsync(int id) {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null) {
                return null;
            }
            _dbContext.Orders.Remove(order);
            await _dbContext.SaveChangesAsync();
            return order;
        } finally {
            semaphore.Release(); // Release the lock
        }
    }
}