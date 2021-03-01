using System;
using IfOfficeMap.DataAccess.Database;

namespace IfOfficeMap.DataAccess
{
    public class Person
    {
        public enum PersonAvailability
        {
            Invalid = -1,
            None = 0,
            Free = 3500,
            FreeIdle = 5000,
            Busy= 6500,
            BusyIdle = 7500,
            DND = 9500,
            TemporarilyAway = 12500,
            Away = 15500,
            Offline = 18500
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Available { get; set; }

        public string Title { get; set; }

        public string Department { get; set; }

        public string Activity { get; set; }

        public Guid ID { get; set; }

        public Workplace Workplace { get; set; }

        public byte[] Photo { get; set; }

        public string BlobLink { get; set; }

        public string ActivityColor
        {
            get
            {
                switch (Available)
                {
                    case "Free":
                    case "FreeIdle":
                    {
                        return "green";
                    }
                    case "Busy":
                    case "BusyIdle":
                    case "DND":
                    {
                        return "red";
                    }
                    case "Away":
                    case "TemporarilyAway":
                    {
                        return "yellow";
                    }
                    case "Offline":
                    {
                        return "grey";
                    }
                    default:
                    {
                        return "blue";
                    }
                }
            }
        }
       
        public string PhotoData
        {
            get
            {
                if (Photo != null)
                {
                    var base64 = Convert.ToBase64String(Photo);
                    return $"data:image/jpg;base64,{base64}";
                }
                else
                {
                    return string.Empty;
                }
            }
        }
    }
}
