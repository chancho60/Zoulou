using System.Linq;
using Zoulou.GData.Interfaces;
using Zoulou.GData.Linq.Impl;

namespace Zoulou.GData.Linq {
    public static class ITableExtensions {
        public static IQueryable<T> AsQueryable<T>(this ITable<T> t) {
            return new Query<T>(new GDataDBQueryProvider<T>(t));
        }
    }
}