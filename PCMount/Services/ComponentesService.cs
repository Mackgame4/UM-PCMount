namespace PCMount.Services;

using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PCMount.Data;
using PCMount.Data.Models;

public class ComponentesService(ApplicationDbContext dbContext) : IDbContextAcessor<Part> {
    private readonly ApplicationDbContext _dbContext = dbContext;
    private static readonly SemaphoreSlim semaphore = new(1, int.MaxValue);

    public async Task<Part[]> GetArrayAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Componentes.AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }
    
    public async Task<List<Part>> GetListAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Componentes.AsNoTracking().ToListAsync();
        } finally {
            semaphore.Release();
        }
    }
    
    public async Task<Part?> DeleteAsync(int id) {
        await semaphore.WaitAsync();
        try {
            var part = await _dbContext.Componentes.FindAsync(id);
            if (part == null) {
                return null;
            }
            _dbContext.Componentes.Remove(part);
            await _dbContext.SaveChangesAsync();
            return part;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Part?> UpdateAsync(int id, Part item) {
        await semaphore.WaitAsync();
        try {
            var part = await _dbContext.Componentes.FindAsync(id);
            if (part == null) {
                return null;
            }
            _dbContext.Entry(part).CurrentValues.SetValues(item);
            await _dbContext.SaveChangesAsync();
            return part;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Part?> CreateAsync(Part item) {
        await semaphore.WaitAsync();
        try {
            var part = await _dbContext.Componentes.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return part.Entity;
        } finally {
            semaphore.Release();
        }
    }

    public bool Any(Expression<Func<Part, bool>> predicate) {
        semaphore.Wait();
        try {
            return _dbContext.Componentes.Any(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Part?> FindAsync(int id) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Componentes.FindAsync(id);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Part?> FindOneAsync(Expression<Func<Part, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Componentes.FirstOrDefaultAsync(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<Part[]> FindAllAsync(Expression<Func<Part, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Componentes.Where(predicate).ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }
}