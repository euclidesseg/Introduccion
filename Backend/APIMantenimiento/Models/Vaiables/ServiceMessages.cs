using static APIMantenimiento.Models.Resources.ServiceMessages;
namespace APIMantenimiento.Models.Vaiables
{
    public static class ServiceMessages
    {
        public static string FORBIDDEN { get { return RESPONSE_FORBIDDEN_KEY; } }
        public static string ERROR { get { return RESPONSE_ERROR; } }
        public static string FORBIDDEN_MESSAGE { get { return FORBIDDEN_MESSAGE_KEY; } }
        public static string OK { get { return RESPONSE_OK; } }
        public static string UNAUTHORIZED { get { return RESPONSE_UNAUTHORIZED; } }
    }
}
