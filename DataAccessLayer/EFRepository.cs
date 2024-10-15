using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer
{
    /// <summary>
    /// Реализация репозитория с использованием Entity Framework Core.
    /// </summary>
    /// <typeparam name="T">Тип сущности, наследующийся от Student и реализующий IDomainObject.</typeparam>
    public class EFRepository<T> : IRepository<T> where T : Student, IDomainObject, new()
    {
        private readonly DbContext _context;


        /// <summary>
        /// Инициализирует новый экземпляр класса EFRepository.
        /// </summary>
        /// <param name="context">Контекст базы данных Entity Framework.</param>
        public EFRepository(DbContext context)
        {
            context.Set<T>();
        }

        
        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        
        public T Get(int id)
        {
            return _context.Set<T>().Find(id);
        }

        
        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            Save();
        }

        
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        
        public void Delete(int id)
        {
            
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                Save();
            }
        }

        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Освобождает ресурсы, используемые репозиторием.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Освобождает неуправляемые (а при необходимости и управляемые) ресурсы.
        /// </summary>
        /// <param name="disposing">Значение true для освобождения управляемых и неуправляемых ресурсов; значение false для освобождения только неуправляемых ресурсов.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
    }
}
