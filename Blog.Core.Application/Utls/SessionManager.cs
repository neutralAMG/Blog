using Blog.Core.Application.Extensions;
using Blog.Core.Application.Features.Users.Account.Dto;
using Blog.Core.Domain.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace Blog.Core.Application.Utls
{
    public class SessionManager
    {
        private readonly ISession _session;
        private readonly SessionKeys _sessionKeys;
        public SessionManager(IHttpContextAccessor httpContext, IOptions<SessionKeys> sessionKeys)
        {
            _sessionKeys = sessionKeys.Value;
            _session = httpContext.HttpContext.Session;
        }

        public void SetItemToSession<Value>(Value value, string key) => _session.Set<Value>(key, value);
        public Value? GetItemFromSession<Value>(string key) => _session.Get<Value>(key);
        public bool IsTheRequestedItemInSession(string key) => _session.Get(key) != default;


        public void SetUserToSession(AuthenticationResponce value) => _session.Set<AuthenticationResponce>(_sessionKeys.UserKey, value);
        public AuthenticationResponce? GetUserFromSession() => _session.Get<AuthenticationResponce>(_sessionKeys.UserKey);
        public bool IsTheUserInSession() => _session.Get<AuthenticationResponce>(_sessionKeys.UserKey) != null;
    }
}
