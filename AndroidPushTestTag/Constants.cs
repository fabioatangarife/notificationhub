using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace AndroidPushTest
{
    public static class Constants
    {
        public const string ListenConnectionString = "Endpoint=sb://mdenet-hub-namespace.servicebus.windows.net/;SharedAccessKeyName=ListenSharedAccessSignature;SharedAccessKey=nCFN4xjIoEJTggZrmYm5C6t2mW2sY+Phd7ZT1zSUj7Q=";
        public const string NotificationHubName = "mdenet-notification-hub";
    }
}