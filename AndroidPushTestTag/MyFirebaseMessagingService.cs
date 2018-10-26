using Android.App;
using Android.Content;
using Android.Util;
using AndroidPushTest;
using Firebase.Messaging;

namespace AndroidPushTestTag
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class MyFirebaseMessagingService : FirebaseMessagingService
    {
        const string TAG = "MyFirebaseMsgService";

        /// <summary>
        /// Local Notification Channel
        /// </summary>
        NotificationChannel _channel;
        NotificationChannel Channel
        {
            get
            {
                if (_channel == null)
                    _channel = CreateChannel();
                return _channel;
            }
        }

        /// <summary>
        /// Local notification manager
        /// </summary>
        NotificationManager _notificationManager;
        NotificationManager NotificationManager
        {
            get
            {
                if (_notificationManager == null)
                    _notificationManager = CreateNotificationManager();

                return _notificationManager;
            }
        }
        /// <summary>
        /// Show the notification when message is received
        /// </summary>
        /// <param name="message"></param>
        public override void OnMessageReceived(RemoteMessage message)
        {
            Log.Debug(TAG, "From: " + message.From);
            if (message.GetNotification() != null)
            {
                //These is how most messages will be received
                Log.Debug(TAG, "Notification Message Body: " + message.GetNotification().Body);
                SendNotification(message.GetNotification().Body, "");
            }
            else
            {
                //Only used for debugging payloads sent from the Azure portal
                SendNotification(message.Data["message"], message.Data["origin"]);

            }

        }

        /// <summary>
        /// Show the notification in the device screen
        /// </summary>
        /// <param name="messageBody"></param>
        /// <param name="origin"></param>
        void SendNotification(string messageBody, string origin)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            var notificationBuilder = new Notification.Builder(this, Channel.Id)
                        .SetContentTitle("From: " + origin)
                        .SetSmallIcon(Resource.Drawable.gapi)
                        .SetBadgeIconType(NotificationBadgeIconType.Large)
                        .SetContentText(messageBody)
                        .SetAutoCancel(true)
                        .SetContentIntent(pendingIntent);

            NotificationManager.Notify(0, notificationBuilder.Build());
        }

        /// <summary>
        /// Create a topic to show the notification
        /// </summary>
        /// <returns></returns>
        NotificationChannel CreateChannel()
        {
            string channelIdOne = "com.my.fcm.test.app.mdenetchannel";
            string nameOne = "Notification Hub";
            string descriptionOne = "Notification Hub Test";
            NotificationImportance importanceOne = Android.App.NotificationImportance.High;

            NotificationChannel channelOne = new NotificationChannel(channelIdOne, nameOne, importanceOne)
            {
                Description = descriptionOne
            };
            channelOne.EnableLights(true);
            channelOne.EnableVibration(true);
            NotificationManager.CreateNotificationChannel(channelOne);
            return channelOne;
        }

        /// <summary>
        /// Create notification manager
        /// </summary>
        /// <returns></returns>
        NotificationManager CreateNotificationManager()
        {
            return NotificationManager.FromContext(this);
        }
    }
}