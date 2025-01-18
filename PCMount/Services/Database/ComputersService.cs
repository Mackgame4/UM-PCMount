namespace PCMount.Services.Database;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PCMount.Data;
using PCMount.Data.Models;

public class ComputersService(ApplicationDbContext dbContext) : IDbContextAcessor<Computer> {
    private readonly ApplicationDbContext _dbContext = dbContext;
    private static readonly SemaphoreSlim semaphore = new(1, int.MaxValue);

    public async Task<Computer[]> GetArrayAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Computers.AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<List<Computer>> GetListAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Computers.AsNoTracking().ToListAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Computer?> DeleteAsync(int id) {
        await semaphore.WaitAsync();
        try {
            var computer = await _dbContext.Computers.FindAsync(id);
            if (computer == null) {
                return null;
            }
            _dbContext.Computers.Remove(computer);
            await _dbContext.SaveChangesAsync();
            return computer;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Computer?> UpdateAsync(int id, Computer item) {
        await semaphore.WaitAsync();
        try {
            var computer = await _dbContext.Computers.FindAsync(id);
            if (computer == null) {
                return null;
            }
            _dbContext.Entry(computer).CurrentValues.SetValues(item);
            await _dbContext.SaveChangesAsync();
            return computer;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Computer?> CreateAsync(Computer item) {
        await semaphore.WaitAsync();
        try {
            var computer = await _dbContext.Computers.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return computer.Entity;
        } finally {
            semaphore.Release();
        }
    }

    public bool Any(Expression<Func<Computer, bool>> predicate) {
        return _dbContext.Computers.Any(predicate);
    }

    public async Task<Computer?> FindAsync(int id) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Computers.FindAsync(id);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Computer?> FindOneAsync(Expression<Func<Computer, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Computers.FirstOrDefaultAsync(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Computer[]> FindAllAsync(Expression<Func<Computer, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Computers.Where(predicate).ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }
}