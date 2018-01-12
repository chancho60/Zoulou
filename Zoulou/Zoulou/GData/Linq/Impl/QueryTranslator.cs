using System;
using System.Linq.Expressions;

namespace Zoulou.GData.Linq.Impl {
    public class QueryTranslator : ExpressionVisitor {
        private readonly Models.Query q = new Models.Query();

        public Models.Query Translate(Expression e) {
            Visit(e);
            return q;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m) {
            Visit(m.Arguments[0]);
            switch(m.Method.Name) {
                case "Where":
                    q.StructuredQuery = new WhereTranslator().Translate(m);
                    break;
                case "OrderBy":
                case "OrderByDescending":
                    q.Order = new OrderTranslator().Translate(m);
                    break;
                case "Take":
                    q.Count = (int)((ConstantExpression)m.Arguments[1]).Value;
                    break;
                case "Skip":
                    q.Start = (int)((ConstantExpression)m.Arguments[1]).Value + 1;
                    break;
                default:
                    throw new NotSupportedException(string.Format("Method {0} not supported", m.Method.Name));
            }
            return m;
        }
    }
}