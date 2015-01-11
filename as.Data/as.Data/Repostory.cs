using System;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;

namespace @as.Data
{
    /// <summary>
    /// Generic Repostory
    /// </summary>
    public class Repostory<T> : iRepostory<T> where T : class
    {
        #region Field
        private IObjectContextAdapter _context;
        private IObjectSet<T> _object;
        #endregion

        #region Ctor
        /// <summary>
        /// Generic Repostory Initalize
        /// </summary>
        public Repostory()
        {
            if (_context == null)
            {
                _context = DataContext.Initalize;
                _object = _context.ObjectContext.CreateObjectSet<T>();
            }
            else
            {
                //_context == DataContext.Initalize; //Context Re Initalize [ Cache , oth ]
            }
        }

        /// <summary>
        /// Context Based Initallize
        /// </summary>
        public Repostory(DataContext context)
        {
            _context = context;
            _object = _context.ObjectContext.CreateObjectSet<T>();
        }
        #endregion
        
        #region Propery
        /// <summary>
        /// All
        /// </summary>
        public IQueryable<T> All
        {
            get { return _object; }
        }

        /// <summary>
        /// All Incliding
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        public IQueryable<T> AllIncliding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _object;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<T> Search(Expression<Func<T, bool>> predicate)
        {
            return _object.Where(predicate);
        }
        
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(T model)
        {
            bool result = false;
            try
            {
                _object.AddObject(model);
                result = true;
            }
            catch (Exception ex)
            {
                var e = ex;
                System.Diagnostics.Trace.Write("Insert Model Err");
                result = false;
            }
            try
            {
                Save();
                result = true;
            }
            catch (System.Data.Entity.Core.UpdateException ex)
            {
                var e = ex;
                System.Diagnostics.Trace.Write("Transact Sql Err For Insert Save");
                result = false;
            }
            catch (InvalidOperationException ex)
            {
                var e = ex;
                System.Diagnostics.Trace.Write("No Update For Insert Save");
                result = false;
            }
            catch (Exception ex)
            {
                var e = ex;
                System.Diagnostics.Trace.Write("Other Insert Error");
                result = false;
            }
            return result;
        }
        
        /// <summary>
        /// Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(T model)
        {
            var result = false;
            try
            {
                _object.Attach(model);
                _context.ObjectContext.ObjectStateManager.ChangeObjectState(model, EntityState.Modified);
                Save();
                result = true;
            }
            catch (InvalidOperationException ex)
            {
                var e = ex;
                System.Diagnostics.Trace.Write("No Update");
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> predicate)
        {
            bool result = false;
            try
            {
                T entity = _object.FirstOrDefault(predicate);
                _object.DeleteObject(entity: entity);
                result = true;
            }
            catch (Exception ex)
            {
                var e = ex;
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            bool result = false;
            try
            {
                _context.ObjectContext.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {
                var e = ex;
                System.Diagnostics.Trace.Write("Repostroy Save Err");
                result = false;
            }
            return result;
        }
        
        /// <summary>
        /// Super Finalize
        /// </summary>
        public void Dispose()
        {
            if (_context != null) _context.ObjectContext.Dispose();
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
