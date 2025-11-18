using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagement.Data
{
    public class BaseRepository<T> where T : class
    {
        protected readonly HotelDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(HotelDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                _context.SaveChanges();
            }
        }

        public int InsertAndReturnId(T entity, string idFieldName = "Id")
        {
            _dbSet.Add(entity);
            _context.SaveChanges();

            // Lấy giá trị của thuộc tính "Id" nếu có
            var idProperty = entity.GetType().GetProperty(idFieldName);
            if (idProperty != null)
            {
                return (int)idProperty.GetValue(entity);
            }

            return 0; // nếu entity không có Id hoặc không phải int
        }
    }
}
