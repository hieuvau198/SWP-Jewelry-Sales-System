using RazorTest.Models;
using RazorTest.Utilities;

namespace RazorTest.Pages.Shared
{
    public class _VerifyAuth
    {
        public static bool VerifyAuth(HttpContext httpContext, string role)
        {
            bool result = false;
            bool isAuthenticated = httpContext.Session.GetObject<bool>("_AuthState");
            User user = httpContext.Session.GetObject<User>("_UserObject");
            if (isAuthenticated && user != null)
            {
                if (user.Role == role)
                {
                    result = true;
                }
            }
            return result;
        }
    }
}
