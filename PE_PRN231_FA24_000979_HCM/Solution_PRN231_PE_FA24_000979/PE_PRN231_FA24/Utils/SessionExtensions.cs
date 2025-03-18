using System.Text.Json;

namespace PE_PRN231_FA24_NguyenThuongHuyen_SE161803_FE.Utils
{
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            var json = JsonSerializer.Serialize(value);
            session.SetString(key, json);
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var json = session.GetString(key);
            return json == null ? default : JsonSerializer.Deserialize<T>(json);
        }
    }
}
