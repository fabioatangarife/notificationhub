using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Collections.Generic;

namespace AndroidPush
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            SetButtonEvent();
        }

        /// <summary>
        /// Set event to sender button
        /// </summary>
        private void SetButtonEvent()
        {
            Button btn = FindViewById<Button>(Resource.Id.button1);
            btn.Click += SendNotification;
        }

        /// <summary>
        /// Send a notification to other device
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SendNotification(object sender, System.EventArgs e)
        {
            EditText message = FindViewById<EditText>(Resource.Id.editText1);
            var notification = new Dictionary<string, string> { { "message", message.Text }, { "origin", "MDE.Net App" } };
            var result = await Notifications.Instance.Hub.SendTemplateNotificationAsync(notification, "gap_latam");
        }
    }
}