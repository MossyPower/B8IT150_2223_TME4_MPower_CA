// Blender Up (2022) ASP.NET Core 6 .NET 6 Project - Shopping Cart. Available at: https:
// www.youtube.com/watch?v=sX3g6hQZ8Lw&t=2705s&ab_channel=BlenderUp 

using Newtonsoft.Json;

namespace FarmApp.Infrastructure
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);
            return sessionData == null ? default(T) : JsonConvert.DeserializeObject<T>(sessionData);
        }
    }
}