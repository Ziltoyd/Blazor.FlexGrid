using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Blazor.FlexGrid.DataSet.Options
{
    public class SearchOptions : ISearchOptions
    {
        public string Keyword { get; set; }
        public IList<PropertyInfo> SearchableProperties { get; set; }

        public Type ItemType { get; set; }

        public LambdaExpression SearchLambda
        {
            get
            {
                var param = Expression.Parameter(ItemType);
                Expression combinedLambdaBody = null;

                foreach (var property in SearchableProperties)
                {
                   
                    var lambdaStringified = DataSetExtensions.StringifiedPropertyOrField(param, property.Name, string.Empty);
                    var containsMethod = typeof(string).GetMethods().First(m => m.GetParameters().Count() == 1
                                                        && m.GetParameters()[0].ParameterType == typeof(string));
                    var callExpr = Expression.Call(lambdaStringified.Body, containsMethod, Expression.Constant(Keyword, typeof(string)));
                    

                    if (combinedLambdaBody == null)
                        combinedLambdaBody = callExpr;
                    else
                        combinedLambdaBody = Expression.Or(combinedLambdaBody, callExpr);

                }

                return Expression.Lambda(combinedLambdaBody, param);

            }
        }

        public IQueryable<T> QuickSearchFilter<T>(IQueryable<T> queryable)
        {
            return queryable.Where((Expression<Func<T, bool>>)SearchLambda);

        }
    }
}
