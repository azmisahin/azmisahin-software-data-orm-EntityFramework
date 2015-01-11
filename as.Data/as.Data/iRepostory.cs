using System;
using System.Linq;
using System.Linq.Expressions;

namespace @as.Data
{
    /// <summary>
    /// Repostory Interface
    /// </summary>
    public interface iRepostory<T> where T : class
    {
        /// <summary>
        /// All Content Get
        /// </summary>
        IQueryable<T> All { get; }

        /// <summary>
        /// All Content With predicate Include
        /// </summary>
        /// <param name="includeProperties"></param>
        /// <returns></returns>
        IQueryable<T> AllIncliding(params Expression<Func<T, object>>[] includeProperties);

        /// <summary>
        /// Get Predicate with search
        /// </summary>
        /// <param name="predicate">.Where(x=> x.id = ?)</param>
        /// <returns></returns>
        IQueryable<T> Search(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Model Insert
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Insert(T model);

        /// <summary>
        /// Model Update
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Update(T model);

        /// <summary>
        /// Delete Model
        /// </summary>
        /// <param name="predicate">.Where(x=> x.id = ? )</param>
        /// <returns></returns>
        bool Delete(Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Context Save
        /// </summary>
        /// <returns></returns>
        bool Save();

        /// <summary>
        /// SuperFinalize
        /// </summary>
        void Dispose();

    }
}
