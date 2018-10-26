using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Iid;
using System.Collections.Generic;
using WindowsAzure.Messaging;

namespace AndroidPush
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    public class MyFirebaseIIDService : FirebaseInstanceIdService
    {
        const string TAG = "MyFirebaseIIDService";
        NotificationHub hub;

        /// <summary>
        ///  Register OnTokenRefresh Event
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

            var tags = new List<string>() { "mde_net" };
            /// Register two times, one for standar register and other one for template
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
            var messageTemplate = "{\"data\":{\"message\":\"$(message)\", \"origin\":\"$(origin)\"}}";
            return messageTemplate;
        }
    }
}