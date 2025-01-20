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

    public async Task<List<Part>> GetPartsForOrderAsync(Order order)
    {
        await semaphore.WaitAsync(); 
        try
        {
            var parts = new List<Part>();

            if (order.MotherboardId.HasValue)
            {
                var motherboard = await _dbContext.Componentes.FindAsync(order.MotherboardId);
                if (motherboard != null) parts.Add(motherboard);
            }

            if (order.ProcessorId.HasValue)
            {
                var processor = await _dbContext.Componentes.FindAsync(order.ProcessorId);
                if (processor != null) parts.Add(processor);
            }

            if (order.MemoryId.HasValue)
            {
                var memory = await _dbContext.Componentes.FindAsync(order.MemoryId);
                if (memory != null) parts.Add(memory);
            }

            if (order.StorageId.HasValue)
            {
                var storage = await _dbContext.Componentes.FindAsync(order.StorageId);
                if (storage != null) parts.Add(storage);
            }

            if (order.GraphicsCardId.HasValue)
            {
                var graphicsCard = await _dbContext.Componentes.FindAsync(order.GraphicsCardId);
                if (graphicsCard != null) parts.Add(graphicsCard);
            }

            if (order.PowerSupplyId.HasValue)
            {
                var powerSupply = await _dbContext.Componentes.FindAsync(order.PowerSupplyId);
                if (powerSupply != null) parts.Add(powerSupply);
            }

            if (order.CaseId.HasValue)
            {
                var pcCase = await _dbContext.Componentes.FindAsync(order.CaseId);
                if (pcCase != null) parts.Add(pcCase);
            }

            return parts.Where(p => p != null).ToList(); 
        }
        finally
        {
            semaphore.Release(); 
        }
    }

}