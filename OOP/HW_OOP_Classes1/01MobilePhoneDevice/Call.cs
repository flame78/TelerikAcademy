//8. Create a class Call to hold a call performed through a GSM. It should contain date, time, dialed phone number and duration (in seconds).

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01MobilePhoneDevice
{
    public class Call
    {
        private readonly DateTime callDateTime;
        private readonly string dialedPhone;
        private readonly int callDuration;

        public Call(DateTime callDateTime,string dialedPhone,int callDuration )
        {
            this.callDateTime = callDateTime;
            this.dialedPhone = dialedPhone;
            if (callDuration < 0) throw new ArgumentOutOfRangeException("Call Duration cannot be negative.");
            else this.callDuration = callDuration;
        }


        public DateTime CallDateTime { get { return this.callDateTime; } }

        public string DialedPhone { get { return this.dialedPhone; } }

        public int CallDuration { get { return this.callDuration; }
          
        }

        public override string ToString()
        {
            return string.Format("Call Date/Time {0}, Dialed Phone {1} hours, Call Duration {2}", this.callDateTime, this.dialedPhone, this.callDuration);
        }
    }
}
