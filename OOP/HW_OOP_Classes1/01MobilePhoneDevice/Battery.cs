
using System;
namespace _01MobilePhoneDevice
{
    public class Battery
    {
        public enum BatteryType
        {
            LiIon, NiMH, NiCd, LiPol
        }

        private readonly string model;
        private double hoursIdle;
        private double hoursTalk;
        private readonly BatteryType batteryType;   
        private string batteryModel;
    

        public Battery() { }

        public Battery(string batteryModel) 
        {
            model = batteryModel;
        }

        public Battery(string batteryModel, double hoursIdle)
            : this(batteryModel)
        {
            this.HoursIdle = hoursIdle;

        }

        public Battery(string batteryModel, double hoursIdle, double hoursTalk)
            : this(batteryModel, hoursIdle)
        {
            this.HoursTalk = hoursTalk;
        }

        public Battery(string batteryModel, double hoursIdle, double hoursTalk, BatteryType batteryType)
            : this(batteryModel, hoursIdle, hoursTalk)
        {
            this.batteryType = batteryType;
        }

        public override string ToString()
        {
            return string.Format("Battery model {0}, Idle Time {1} hours, Talk Time {2} hours, Type {3}", this.model, this.hoursIdle, this.hoursTalk, this.batteryType);
            //            base.ToString();
        }

        public double HoursIdle
        {
            get { return this.hoursIdle; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Can not use negative time");
                else
                    this.hoursIdle = value;
            }
        }

        public double HoursTalk
        {
            get { return this.hoursTalk; }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Can not use negative time");
                else
                    this.hoursTalk = value;
            }
        }
    }
}
