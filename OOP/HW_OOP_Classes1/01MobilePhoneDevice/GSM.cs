using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01MobilePhoneDevice
{
    public class GSM
    {
        private static readonly GSM iphone4S = new GSM("IPhone-4S", "Apple", 900, "Pesho",
       "sanyo-321r54D", 120, 14, Battery.BatteryType.LiPol, 4.5, Display.ColorDepth._32Bit);
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private List<Call> callHistory = new List<Call>();

        public GSM(string model, string manufacturer)
        {
            if (model.Length < 1 || manufacturer.Length < 1) throw new MissingFieldException();
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal price, string owner, string batteryModel, double hoursIdle, double hoursTalk, Battery.BatteryType batteryType, double sizeInInches, Display.ColorDepth colorDepth)
            : this(model, manufacturer)
        {
            this.price = price;
            this.owner = owner;
            this.battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
        }

        public int CallHistoryCount
        {
            get { return this.callHistory.Count; }
        }

        public void AddCallToHistory(Call call)
        {
            this.callHistory.Add(call);
        }

        public void RemoveCallFromHistory(int index)
        {
            this.callHistory.RemoveAt(index);
        }

        public int ClearCallHistory
        {
            get
            {
                this.callHistory.Clear();
                return 0;
            }
        }

        public int PrintCallHistory
        {
            get
            {
                foreach (var item in this.callHistory)
                {
                    Console.WriteLine(item);
                    
                }
                return 0;
            }
        }

        public decimal PriceOfCalls(decimal pricePerMinute)
        {
            decimal result=0;

            foreach (var item in this.callHistory)
            {
                result += item.CallDuration / 60 * pricePerMinute;
            }

            return result;
        }





        public static GSM IPhone4S { get { return iphone4S; } }

        public override string ToString()
        {
            return string.Format("Model {0}, Manufacturer {1}, Price {2:C}, Owner {3}, {4}, {5}", this.model, this.manufacturer, this.price, this.owner, battery, display);
        }
    }


}
