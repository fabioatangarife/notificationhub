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
            Hub = NotificationHubClient.CreateClientFromConnectionString("",
                                                                            "mdenet-notification-hub", true);
        }
    }
}
