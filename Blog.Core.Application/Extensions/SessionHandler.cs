using Microsoft.AspNetCore.Http;


namespace Blog.Core.Application.Extensions
{
    public static class SessionHandler
    {
        public static void Set<TValue>(this IHttpContextAccessor httpContext, string key, TValue value)
        {
            string valueToBeSave = System.Text.Json.JsonSerializer.Serialize(value);
            httpContext.HttpContext.Session.SetString(key, valueToBeSave);
        }
        public static TValue Get<TValue>(this IHttpContextAccessor httpContext, string key)
        {
            string valueInSession = httpContext.HttpContext.Session.GetString(key);
            TValue DeserializedValue = System.Text.Json.JsonSerializer.Deserialize<TValue>(valueInSession);

            return DeserializedValue == null ? default : DeserializedValue;
        }
    }
}
