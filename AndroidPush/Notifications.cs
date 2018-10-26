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
            Hub = NotificationHubClient.CreateClientFromConnectionString("",
                                                                            "mdenet-notification-hub", true);
        }
    }
}