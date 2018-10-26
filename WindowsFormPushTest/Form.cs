using Microsoft.Azure.NotificationHubs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindowsFormPushTest
{
    public partial class Form : System.Windows.Forms.Form
    {
        private NotificationHubClient hub;
        public Form()
        {
            InitializeComponent();
            hub = Notifications.Instance.Hub;
        }

        /// <summary>
        /// Send the notificaiton on send button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Sender_Click(object sender, EventArgs e)
        {
            //// Send native notification to google devices
            //var result = await hub.SendGcmNativeNotificationAsync("{ \"data\":{ \"message\":\"" + messagetext.Text + "\"} }", tag.Text);
            //state.Text = result.State.ToString();
            await SendWithTemplate();
        }

        /// <summary>
        /// Send a notification with the defined template
        /// </summary>
        /// <returns></returns>
        public async Task SendWithTemplate()
        {
            var notification = new Dictionary<string, string> { { "message", messagetext.Text }, { "origin", "GAP Windows Office" } };
            var result = await Notifications.Instance.Hub.SendTemplateNotificationAsync(notification, tag.Text);
            state.Text = result.State.ToString();
        }

    }
}
