using System.Linq;
using System.Linq.Expressions;
using Zoulou.GData.Interfaces;

namespace Zoulou.GData.Linq.Impl {
    public class GDataDBQueryProvider<T> : QueryProvider {
        private readonly ITable<T> table;

        public GDataDBQueryProvider(ITable<T> table) {
            this.table = table;
        }

        public override Models.Query GetQuery(Expression expression) {
            expression = Evaluator.PartialEval(expression);
            return new QueryTranslator().Translate(expression);
        }

        public override object Execute(Expression expression) {
            return table.Find(GetQuery(expression)).Select(r => r.Element);
        }
    }
}