using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class notify : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AndroidNotificationCenter.CancelAllDisplayedNotifications();
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.Default,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
        var notification = new AndroidNotification();
        notification.Title = "Eco-Friendly Reminder!";
        notification.Text = "Remember to constantly save energy by unplugging unused appliances, turning off your lights, and reducing AC usage!";
        notification.FireTime = System.DateTime.Now.AddSeconds(30);

        var id = AndroidNotificationCenter.SendNotification(notification, "channel_id");
        
        if(AndroidNotificationCenter.CheckScheduledNotificationStatus(id) == NotificationStatus.Scheduled){
            AndroidNotificationCenter.CancelAllNotifications();
            AndroidNotificationCenter.SendNotification(notification, "channel_id");
        }
        
    }
}
