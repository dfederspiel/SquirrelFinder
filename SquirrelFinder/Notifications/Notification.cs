using SquirrelFinder.Nuts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SquirrelFinder.Notifications
{
    public class Notification
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public INut Nut { get; set; }
        public NutState State { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
