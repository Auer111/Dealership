using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public class NotificationCenter
    {
        public List<Notification> Notifications { get; set; }
    }


    public class Notification
    {
        public enum NotificationType { Unknown, Installer, DealershipInfo, MissingPhoto, Other }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public NotificationType Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        [NotMapped]
        public string Color
        {
            get
            {
                switch (Type)
                {
                    case NotificationType.Installer: return "danger";
                    case NotificationType.DealershipInfo: return "danger";
                    case NotificationType.MissingPhoto: return "primary";
                    default: return "secondary";
                }
            }
        }
        
        

    }




}
