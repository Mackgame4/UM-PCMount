namespace PCMount.Services.Database;

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PCMount.Data;
using PCMount.Data.Models;

public class InventarioService(ApplicationDbContext dbContext) : IDbContextAcessor<Inventario> {
    private readonly ApplicationDbContext _dbContext = dbContext;
    private static readonly SemaphoreSlim semaphore = new(1, int.MaxValue);

    public async Task<Inventario[]> GetArrayAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Inventario.AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<List<Inventario>> GetListAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Inventario.AsNoTracking().ToListAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Inventario?> DeleteAsync(int id) {
        await semaphore.WaitAsync();
        try {
            var inventario = await _dbContext.Inventario.FindAsync(id);
            if (inventario == null) {
                return null;
            }
            _dbContext.Inventario.Remove(inventario);
            await _dbContext.SaveChangesAsync();
            return inventario;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Inventario?> UpdateAsync(int id, Inventario item) {
        await semaphore.WaitAsync();
        try {
            var inventario = await _dbContext.Inventario.FindAsync(id);
            if (inventario == null) {
                return null;
            }
            _dbContext.Entry(inventario).CurrentValues.SetValues(item);
            await _dbContext.SaveChangesAsync();
            return inventario;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Inventario?> CreateAsync(Inventario item) {
        await semaphore.WaitAsync();
        try {
            var inventario = await _dbContext.Inventario.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return inventario.Entity;
        } finally {
            semaphore.Release();
        }
    }

    public bool Any(Expression<Func<Inventario, bool>> predicate) {
        semaphore.Wait();
        try {
            return _dbContext.Inventario.Any(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Inventario?> FindAsync(int id) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Inventario.FindAsync(id);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Inventario?> FindOneAsync(Expression<Func<Inventario, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Inventario.FirstOrDefaultAsync(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Inventario[]> FindAllAsync(Expression<Func<Inventario, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Inventario.Where(predicate).AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }
}