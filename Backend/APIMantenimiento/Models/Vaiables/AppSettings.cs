using static APIMantenimiento.Models.Resources.AppSettings;
namespace APIMantenimiento.Models.Vaiables
{
    public static class AppSettings
    {
        public static string CONTENT_TYPE { get { return CONTENT_TYPE_KEY; } }
        public static string SECURITY_KEY_ID { get { return SECURITY_KEY_ID; } }
        public static string APP_SALT { get { return APP_SALT; } }
    }
}
