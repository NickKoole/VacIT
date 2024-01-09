using Microsoft.EntityFrameworkCore;
using VacIT.Models;
using System.Collections.Generic;
using System.Linq;

namespace VacIT.Cruds
{
    public class Crud<TEntity> where TEntity : class
    {
        private readonly VacITContext _context;

        public Crud(VacITContext context)
        {
            _context = context;
        }

        public void Create(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                var selectedEntity = _context.Set<TEntity>().Find(id);

                if (selectedEntity != null)
                {
                    _context.Set<TEntity>().Remove(selectedEntity);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }

        public TEntity? Read(int id)
        {
            try
            {
                var selectedEntity = _context.Set<TEntity>().Find(id);
                return selectedEntity;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<TEntity>? ReadAll()
        {
            try
            {
                var entities = _context.Set<TEntity>().ToList();
                return entities;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public List<TEntity>? ReadAllById(int foreignKeyId, Func<TEntity, int> foreignKeySelector)
        {
            try
            {
                var entities = _context.Set<TEntity>()
                    .Where(entity => foreignKeySelector(entity) == foreignKeyId)
                    .ToList();
                return entities;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
                return null;
            }
        }

        public void Update(TEntity entity)
        {
            try
            {
                _context.Set<TEntity>().Update(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
        }
    }
}
