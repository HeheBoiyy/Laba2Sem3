using Dapper;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public class DapperRepository<T> : IRepository<T> where T : Student, IDomainObject, new()
    {
        private static string connectionString = "Host=localhost;Port=5432;Database=students;Username=postgres;Password=David800;";
        private NpgsqlConnection db = new NpgsqlConnection(connectionString);

        /// <summary>
        /// Создает новую запись в базе данных на основе переданного объекта.
        /// </summary>
        /// <param name="t">Объект для создания в базе данных.</param>
        public void Create(T t)
        {
            string sqlQuery = "INSERT INTO Students (Name, \"Group\", Speciality) " +
                      "VALUES (@Name, @Group, @Speciality) RETURNING Id";

            int id = db.ExecuteScalar<int>(sqlQuery, new
            {
                Name = t.Name,
                Group = t.Group,
                Speciality = t.Speciality
            });

            t.Id = id;
        }

        /// <summary>
        /// Возвращает все записи из таблицы Students.
        /// </summary>
        /// <returns>Коллекция всех объектов типа T из базы данных.</returns>
        public IEnumerable<T> GetAll()
        {
            return db.Query<T>("SELECT * FROM Students");
        }

        /// <summary>
        /// Возвращает запись из базы данных по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор искомой записи.</param>
        /// <returns>Объект типа T, соответствующий указанному идентификатору, или null, если запись не найдена.</returns>
        public T Get(int id)
        {
            return db.QueryFirstOrDefault<T>("SELECT * FROM Students WHERE Id = @Id", new { Id = id });
        }

        /// <summary>
        /// Обновляет существующую запись в базе данных.
        /// </summary>
        /// <param name="entity">Объект с обновленными данными.</param>
        public void Update(T entity)
        {
            string sqlQuery = "UPDATE Students SET Name = @Name, \"Group\" = @Group, Speciality = @Speciality WHERE Id = @Id";
            db.Execute(sqlQuery, entity);
        }

        /// <summary>
        /// Удаляет запись из базы данных по указанному идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор записи для удаления.</param>
        public void Delete(int id)
        {
            db.Execute("DELETE FROM Students WHERE Id = @Id", new { Id = id });
        }

        /// <summary>
        /// Сохраняет изменения в базе данных. В текущей реализации с Dapper этот метод не выполняет никаких действий.
        /// </summary>
        public void Save()
        {
            // В случае с Dapper, Save() метод не требуется, так как изменения сохраняются сразу
            // Этот метод оставлен пустым для совместимости с интерфейсом
        }

        /// <summary>
        /// Освобождает ресурсы, используемые объектом DapperRepository.
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
                db?.Dispose();
            }
        }
        public void ExecuteSQL(string sql)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                connection.Execute(sql);
            }
        }
    }
}