namespace PCMount.Services;

using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PCMount.Data;
using PCMount.Data.Models;

public class UsersService(ApplicationDbContext dbContext) : IDbContextAcessor<User> {
    private readonly ApplicationDbContext _dbContext = dbContext;
    private static readonly SemaphoreSlim semaphore = new(1, int.MaxValue);

    public async Task<User[]> GetArrayAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Users.AsNoTracking().ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<List<User>> GetListAsync() {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        } finally {
            semaphore.Release();
        }
    }

    public async Task<User?> DeleteAsync(int id) {
        await semaphore.WaitAsync();
        try {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) {
                return null;
            }
            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return user;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<User?> UpdateAsync(int id, User item) {
        await semaphore.WaitAsync();
        try {
            var user = await _dbContext.Users.FindAsync(id);
            if (user == null) {
                return null;
            }
            _dbContext.Entry(user).CurrentValues.SetValues(item);
            await _dbContext.SaveChangesAsync();
            return user;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<User?> CreateAsync(User item) {
        await semaphore.WaitAsync();
        try {
            var user = await _dbContext.Users.AddAsync(item);
            await _dbContext.SaveChangesAsync();
            return user.Entity;
        } finally {
            semaphore.Release();
        }
    }

    public async Task<User?> FindAsync(int id) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Users.FindAsync(id);
        } finally {
            semaphore.Release();
        }
    }

    public async Task<User?> FindOneAsync(Expression<Func<User, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Users.FirstOrDefaultAsync(predicate);
        } finally {
            semaphore.Release();
        }
    }

    public bool Any(Expression<Func<User, bool>> predicate) {
        return _dbContext.Users.AsNoTracking().Any(predicate);
    }

    public async Task<User[]> FindAllAsync(Expression<Func<User, bool>> predicate) {
        await semaphore.WaitAsync();
        try {
            return await _dbContext.Users.Where(predicate).ToArrayAsync();
        } finally {
            semaphore.Release();
        }
    }
}