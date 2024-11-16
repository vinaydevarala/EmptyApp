
using System.Text.RegularExpressions;

namespace EmptyApp.CustomConstraints
{
    public class MyRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (!values.ContainsKey(routeKey)) return false;
            Regex regex = new Regex("^1|2|3$");
            string? Val = values[routeKey].ToString();
            if (regex.IsMatch(Val))
            {
                return true;
            }
            return false;
        }
    }
}
