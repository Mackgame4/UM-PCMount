namespace PCMount.Services.Database;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PCMount.Data;
using PCMount.Data.Models;

public class OrdersService : IDbContextAcessor<Order> {
    private readonly ApplicationDbContext _dbContext;
    private static readonly SemaphoreSlim semaphore = new(1, 1); // Semaphore to ensure single access to DbContext

    public OrdersService() {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        _ = optionsBuilder.UseSqlServer(DbContextConfig.ConnectionString);
        _dbContext = new ApplicationDbContext(optionsBuilder.Options);
    }

    public async Task<Order[]> GetArrayAsync() {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            return await _dbContext.Orders.AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release(); // Release the lock
        }
    }

    public async Task<List<Order>> GetListAsync() {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            return await _dbContext.Orders.AsNoTracking().ToListAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Order?> DeleteAsync(int id) {
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

    public async Task<Order?> UpdateAsync(int id, Order item) {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            var order = await _dbContext.Orders.FindAsync(id);
            if (order == null) {
                return null;
            }
            _dbContext.Entry(order).CurrentValues.SetValues(item);
            await _dbContext.SaveChangesAsync();
            return order;
        } finally {
            semaphore.Release(); // Release the lock
        }
    }

    public async Task<Order?> CreateAsync(Order item) {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            var order = await _dbContext.Orders.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return order.Entity;
        } finally {
            semaphore.Release();
        }
    }

    public bool Any(Expression<Func<Order, bool>> predicate) {
        return _dbContext.Orders.AsNoTracking().Any(predicate);
    }

    public async Task<Order?> FindAsync(int id) {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            return await _dbContext.Orders.FindAsync(id);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Order?> FindOneAsync(Expression<Func<Order, bool>> predicate) {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            return await _dbContext.Orders.AsNoTracking().FirstOrDefaultAsync(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Order[]> FindAllAsync(Expression<Func<Order, bool>> predicate) {
        await semaphore.WaitAsync(); // Wait for the lock to be available
        try {
            return await _dbContext.Orders.Where(predicate).AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }
}