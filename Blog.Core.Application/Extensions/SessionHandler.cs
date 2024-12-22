using Microsoft.AspNetCore.Http;


namespace Blog.Core.Application.Extensions
{
    public static class SessionHandler
    {
        public static void Set<TValue>(this ISession session, string key, TValue value)
        {
            string valueToBeSave = System.Text.Json.JsonSerializer.Serialize(value);
            session.SetString(key, valueToBeSave);
        }
        public static TValue Get<TValue>(this ISession session, string key)
        {
            string valueInSession = session.GetString(key);
            TValue DeserializedValue = System.Text.Json.JsonSerializer.Deserialize<TValue>(valueInSession);

            return DeserializedValue == null ? default : DeserializedValue;
        }
    }
}
