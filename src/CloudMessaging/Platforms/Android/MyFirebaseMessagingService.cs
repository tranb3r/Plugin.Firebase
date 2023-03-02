using Android.App;
using Firebase.Messaging;
using Microsoft.Maui.Controls.Internals;
using Plugin.Firebase.CloudMessaging.Platforms.Android.Extensions;

namespace Plugin.Firebase.CloudMessaging.Platforms.Android;

[Service(Exported = true)]
[IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
[Preserve(AllMembers = true)]
public class MyFirebaseMessagingService : FirebaseMessagingService
{
    public override void OnMessageReceived(RemoteMessage message)
    {
        base.OnMessageReceived(message);
        CrossFirebaseCloudMessaging.Current.OnNotificationReceived(message.ToFCMNotification());
    }

    public override async void OnNewToken(string token)
    {
        await CrossFirebaseCloudMessaging.Current.OnTokenRefreshAsync();
    }
}