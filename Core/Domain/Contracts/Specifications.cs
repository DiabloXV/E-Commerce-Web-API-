using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public abstract class Specifications <T> where T : class
    {
        protected Specifications(Expression<Func<T, bool>>? criteria)
        {
            Criteria = criteria;
        }

        public Expression<Func<T, bool>>? Criteria { get; } //where

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public List<Expression<Func<T, object>>> IncludeExpressions { get;} = new(); //Include

        protected void AddInclude(Expression<Func<T, object>> expression) => IncludeExpressions.Add(expression);

        protected void SetOrderyBy(Expression<Func<T, object>> expression) => OrderBy = expression;

        protected void SetOrderByDescending(Expression<Func<T, object>> expression) => OrderByDescending = expression;

    }
}
