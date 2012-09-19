using System;
using System.Linq.Expressions;
using FubuMVC.Core.Registration.Conventions;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Registration.Routes;

namespace Tests
{
    public static class Extensions
    {
        public static IRouteDefinition CreateRoute<T>(this IUrlPolicy policy, Expression<Func<T, object>> action)
        {
            var actionCall = new ActionCall(typeof(T), typeof(T).GetMethod(((MethodCallExpression)action.Body).Method.Name));
            return policy.Build(actionCall);
        }
    }
}