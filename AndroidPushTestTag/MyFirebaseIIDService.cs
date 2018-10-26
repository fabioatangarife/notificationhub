using Android.App;
using Android.Content;
using Android.Util;
using AndroidPushTest;
using Firebase.Iid;
using System.Collections.Generic;
using WindowsAzure.Messaging;

namespace AndroidPushTestTag
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        NotificationHub hub;

        /// <summary>
        /// Register OnTokenRefresh Event
        /// </summary>
        public override void OnTokenRefresh()
        {
            var refreshedToken = FirebaseInstanceId.Instance.Token;
            Log.Debug(TAG, "FCM token: " + refreshedToken);
            SendRegistrationToServer(refreshedToken);
        }

        /// <summary>
        /// Send the registration to Azure Notification Hub
        /// </summary>
        /// <param name="token"></param>
        void SendRegistrationToServer(string token)
        {
            // Register with Notification Hubs
            hub = new NotificationHub(Constants.NotificationHubName,
                                      Constants.ListenConnectionString, this);

            var tags = new List<string>() { "mde_net", "gap_latam" };
            var regID = hub.RegisterTemplate(token, "GAP Template", GetTemplate(), tags.ToArray()).RegistrationId;
            var regID2 = hub.Register(token, tags.ToArray()).RegistrationId;

            Log.Debug(TAG, $"Successful registration of ID {regID}");
        }

        /// <summary>
        /// Get the register template
        /// </summary>
        /// <returns></returns>
        string GetTemplate()
        {
            //switch (deviceUpdate.Platform)
            //{
            //    case "mpns":
            //        var toastTemplate = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            //            "<wp:Notification xmlns:wp=\"WPNotification\">" +
            //               "<wp:Toast>" +
            //                    "<wp:Text1>$(message)</wp:Text1>" +
            //               "</wp:Toast> " +
            //            "</wp:Notification>";
            //        registration = new MpnsTemplateRegistrationDescription(deviceUpdate.Handle, toastTemplate);
            //        break;
            //    case "wns":
            //        toastTemplate = @"<toast><visual><binding template=""ToastText01""><text id=""1"">$(message)</text></binding></visual></toast>";
            //        registration = new WindowsTemplateRegistrationDescription(deviceUpdate.Handle, toastTemplate);
            //        break;
            //    case "apns":
            //        var alertTemplate = "{\"aps\":{\"alert\":\"$(message)\"}}";
            //        registration = new AppleTemplateRegistrationDescription(deviceUpdate.Handle, alertTemplate);
            //        break;
            //    case "gcm":
            var messageTemplate = "{\"data\":{\"message\":\"$(message)\", \"origin\":\"$(origin)\"}}";
            // registration = new GcmTemplateRegistrationDescription(deviceUpdate.Handle, messageTemplate);
            //    break;
            //default:
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}
            return messageTemplate;
        }
    }   
}
