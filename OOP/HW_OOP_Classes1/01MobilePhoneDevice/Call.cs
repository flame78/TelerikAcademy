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
        private readonly uint callDuration;

        public Call(DateTime callDateTime,string dialedPhone,uint callDuration )
        {
            this.callDateTime = callDateTime;
            this.dialedPhone = dialedPhone;
            this.callDuration = callDuration;
        }


        public DateTime CallDateTime { get { return this.callDateTime; } }

        public string DialedPhone { get { return this.dialedPhone; } }

        public uint CallDuration { get { return this.callDuration; } }

        public override string ToString()
        {
            return string.Format("Call Date/Time {0}, Dialed Phone {1} hours, Call Duration {2}", this.callDateTime, this.dialedPhone, this.callDuration);
        }
    }
}
