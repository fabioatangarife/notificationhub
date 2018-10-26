using Microsoft.Azure.NotificationHubs;

namespace AndroidPush
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        /// <summary>
        /// Get the Azure notificatio hub to management
        /// </summary>
        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://mdenet-hub-namespace.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=XHqQQ+O2E+tXdKZk5pKzdMtqlHhpA5j52YYMQy3Hlb8=",
                                                                            "mdenet-notification-hub", true);
        }
    }
}