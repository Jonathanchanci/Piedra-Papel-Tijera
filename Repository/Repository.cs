using Microsoft.EntityFrameworkCore;
using Piedra_Papel_Tijera.Interface;
using Piedra_Papel_Tijera.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Piedra_Papel_Tijera.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly GamePPTContext _context = new();
        public async Task<T> Create(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var batalla = await _context.Set<T>().FindAsync(id);
            if (batalla == null)
                return false;

            _context.Remove(batalla);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Getlist()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<bool> Update(T entiry)
        {
            _context.Entry(entiry).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> UpdateRange(IEnumerable<T> entitys)
        {
            _context.UpdateRange(entitys);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return false;
            }
            return true;
        }
    }
}
