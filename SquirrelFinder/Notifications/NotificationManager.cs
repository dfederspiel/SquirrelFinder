using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SquirrelFinder.Nuts;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SquirrelFinder.Notifications
{
    public class NotificationManager
    {
        public static Dictionary<Guid, Notification> Notifications = new Dictionary<Guid, Notification>();

        public NotificationManager(NotifyIcon icon)
        {
            // For eventual queue of messages
        }

        public static void Add(INut nut, string title, string message)
        {
            Guid guid = getGuidFromText(message);
            Notifications.Add(guid, new Notification
            {
                Id = guid,
                Url = nut.Url.ToString(),
                State = nut.State,
                Nut = nut,
                Title = title,
                Message = message
            });
        }

        public static Notification GetNotificationForMessage(string balloonTipText)
        {
            return Notifications.Where(n => n.Key == getGuidFromText(balloonTipText)).FirstOrDefault().Value;
        }

        static Guid getGuidFromText(string text)
        {
            string pattern = @"[{(]?[0-9A-F]{8}[-]?([0-9A-F]{4}[-]?){3}[0-9A-F]{12}[)}]?";
            RegexOptions options = RegexOptions.IgnoreCase;

            Guid returnGuid = Guid.Empty;
            foreach (Match m in Regex.Matches(text, pattern, options))
            {
                returnGuid = Guid.Parse(m.Value);
            }
            return returnGuid;
        }

       
    }
}
