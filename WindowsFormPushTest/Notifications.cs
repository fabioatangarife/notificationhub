using Microsoft.Azure.NotificationHubs;

namespace WindowsFormPushTest
{
    public class Notifications
    {
        public static Notifications Instance = new Notifications();

        public NotificationHubClient Hub { get; set; }

        /// <summary>
        /// Get the azure notification hub
        /// </summary>
        private Notifications()
        {
            Hub = NotificationHubClient.CreateClientFromConnectionString("Endpoint=sb://mdenet-hub-namespace.servicebus.windows.net/;SharedAccessKeyName=DefaultFullSharedAccessSignature;SharedAccessKey=XHqQQ+O2E+tXdKZk5pKzdMtqlHhpA5j52YYMQy3Hlb8=",
                                                                            "mdenet-notification-hub", true);
        }
    }
}
