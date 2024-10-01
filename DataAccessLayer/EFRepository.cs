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
        private readonly DbSet<T> _dbSet;

        /// <summary>
        /// Инициализирует новый экземпляр класса EFRepository.
        /// </summary>
        /// <param name="context">Контекст базы данных Entity Framework.</param>
        public EFRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        /// <summary>
        /// Получает все сущности из базы данных.
        /// </summary>
        /// <returns>Коллекция всех сущностей типа T.</returns>
        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        /// <summary>
        /// Получает сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность с указанным идентификатором или null, если сущность не найдена.</returns>
        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        /// <summary>
        /// Создает новую сущность в базе данных.
        /// </summary>
        /// <param name="entity">Сущность для создания.</param>
        public void Create(T entity)
        {
            _dbSet.Add(entity);
            Save();
        }

        /// <summary>
        /// Обновляет существующую сущность в базе данных.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            Save();
        }

        /// <summary>
        /// Удаляет сущность из базы данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                Save();
            }
        }

        /// <summary>
        /// Сохраняет все изменения в базе данных.
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
