namespace Get_HttpContext_ASP.NET_Core
{
    using Microsoft.AspNetCore.Http;

    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetLoginUserName()
        {
            return _httpContextAccessor.HttpContext.User.Identity.Name;
        }
    }
}
