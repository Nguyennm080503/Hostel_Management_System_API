﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dao
{
    public class BaseDAO<T> where T : class
    {
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            IEnumerable<T> list;
            try
            {
                var _context = new HostelManagementContext();
                DbSet<T> _dbSet = _context.Set<T>();
                list = await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }

        public async Task<bool> CreateAsync(T entity)
        {
            try
            {
                var _context = new HostelManagementContext();
                DbSet<T> _dbSet = _context.Set<T>();
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                var _context = new HostelManagementContext();
                DbSet<T> _dbSet = _context.Set<T>();
                var tracker = _context.Attach(entity);
                tracker.State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task RemoveAsync(T entity)
        {
            try
            {
                var _context = new HostelManagementContext();
                DbSet<T> _dbSet = _context.Set<T>();
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
