using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneManagement
{
    public class SmartPhone
    {
        public string SmartPhoneID { get; set; }
        public string SmartPhoneName { get; set; }
        public string SmartPhoneType { get; set; }
        public DateTime AnnouncedDate { get; set; }
        public string Platform {  get; set; }
        public string Camera {  get; set; }
        public string RAM { get; set; }
        public string Battery { get; set; }
        public int Price { get; set; }
        public string Avatar { get; set; }
        public SmartPhone()
        {
            SmartPhoneID = "Not Assigned";
            SmartPhoneName = "Not Assigned";
        }
    }
}
