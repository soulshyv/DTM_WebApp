using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DTM.Core
{
    public abstract class RepositoryBase<TContext, T, TKey>
        where TContext : DbContext
        where T : class, new()
        where TKey : IEquatable<TKey>
    {
        protected RepositoryBase(TContext co, Func<TContext, DbSet<T>> tableDbSet, Expression<Func<T, TKey>> tableKeySelector)
        {
            Connection = co;
            TableSet = tableDbSet;
            TableKeySelector = tableKeySelector;
        }
        // ReSharper disable once MemberCanBePrivate.Global
        protected TContext Connection { get; }

        protected Func<TContext, DbSet<T>> TableSet { get; set; }
        protected Expression<Func<T, TKey>> TableKeySelector { get; set; }
        
        public abstract Task<T> GetById(TKey id, bool noTracking = false, CancellationToken ctk = default(CancellationToken));

        public virtual async Task<IEnumerable<T>> GetValues(CancellationToken ctk = default(CancellationToken))
        {
            return await TableSet(Connection).ToArrayAsync(ctk);
        }

        public virtual async Task<T> Insert(T item, CancellationToken ctk = default(CancellationToken))
        {
            await TableSet(Connection).AddAsync(item, ctk);

            await Connection.SaveChangesAsync(ctk);

            return item;
        }

        public virtual async Task<T> Update(T item, CancellationToken ctk = default(CancellationToken))
        {
            TableSet(Connection).Update(item);

            await Connection.SaveChangesAsync(ctk);

            return item;
        }

        public virtual async Task<bool> Delete(T item, CancellationToken ctk = default(CancellationToken))
        {
            TableSet(Connection).Remove(item);

            var res = await Connection.SaveChangesAsync(ctk);

            return res > 0;
        }

        public virtual async Task<bool> DeleteById(TKey id, CancellationToken ctk = default(CancellationToken))
        {
            var item = await GetById(id, false, ctk);

            TableSet(Connection).Remove(item);

            var res = await Connection.SaveChangesAsync(ctk);
            return res > 0;
        }
    }
}
