using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01MobilePhoneDevice
{
    //1. Define a class that holds information about a mobile phone device: model, manufacturer, price, owner, battery characteristics (model, hours idle and hours talk) and display characteristics (size and number of colors). Define 3 separate classes (class GSM holding instances of the classes Battery and Display).
    public class GSM
    {
        //6. Add a static field and a property IPhone4S in the GSM class to hold the information about iPhone 4S.
        private static readonly GSM iphone4S = new GSM("IPhone-4S", "Apple", 900, "Pesho",
       "sanyo-321r54D", 120, 14, Battery.BatteryType.LiPol, 4.5, Display.ColorDepth._32Bit);
        private string model;
        private string manufacturer;
        private decimal? price=null;
        private string owner;
        private Battery battery;
        private Display display;
        //9. Add a property CallHistory in the GSM class to hold a list of the performed calls. Try to use the system class List<Call>.
        private List<Call> callHistory = new List<Call>();

        //2. Define several constructors for the defined classes that take different sets of arguments (the full information for the class or part of it). Assume that model and manufacturer are mandatory (the others are optional). All unknown data fill with null.

        public GSM(string model, string manufacturer)
        {
            if (model.Length < 1 || manufacturer.Length < 1) throw new MissingFieldException();
            this.model = model;
            this.manufacturer = manufacturer;
        }

        public GSM(string model, string manufacturer, decimal price, string owner, string batteryModel, double hoursIdle, double hoursTalk, Battery.BatteryType batteryType, double displaySizeInInches, Display.ColorDepth colorDepth)
            : this(model, manufacturer)
        {
            this.price = price;
            this.owner = owner;
            this.battery = new Battery(batteryModel, hoursIdle, hoursTalk, batteryType);
            this.display = new Display(displaySizeInInches, colorDepth);
        }

        //10. Add methods in the GSM class for adding and deleting calls from the calls history. Add a method to clear the call history.

        public int CallHistoryCount()
        {
            return this.callHistory.Count;
        }

        public void AddCallToHistory(DateTime callDateTime,string dialedPhone,int callDuration)
        {
            this.callHistory.Add(new Call(callDateTime,dialedPhone,callDuration));
        }

        public void RemoveCallFromHistory(int index)
        {
            this.callHistory.RemoveAt(index);
        }

        public void ClearCallHistory()
        {
            this.callHistory.Clear();
        }

        public void PrintCallHistory()
        {
            foreach (var item in this.callHistory)
            {
                Console.WriteLine(item);
            }

        }

        //11. Add a method that calculates the total price of the calls in the call history. Assume the price per minute is fixed and is provided as a parameter.

        public decimal PriceOfCalls(decimal pricePerMinute)
        {
            decimal result = 0;

            foreach (var item in this.callHistory)
            {
                result += item.CallDuration * (pricePerMinute / 60);
            }
            return result;
        }

        public static GSM IPhone4S { get { return iphone4S; } }

        //4. Add a method in the GSM class for displaying all information about it. Try to override ToString().

        public override string ToString()
        {
            return string.Format("Model {0}, Manufacturer {1}, Price {2:C}, Owner {3}, {4}, {5}", this.model, this.manufacturer, this.price, this.owner, battery, display);
        }

        public dynamic this[int indexOfCallInHistory, Call.Element typeOfElementToRetyrn]
        {
            get
            {
                Call call=this.callHistory[indexOfCallInHistory];
                if (typeOfElementToRetyrn == Call.Element.CallDateTime) return call.CallDateTime;
                else if (typeOfElementToRetyrn == Call.Element.DialedPhone) return call.DialedPhone;
                else if (typeOfElementToRetyrn == Call.Element.CallDuration) return call.CallDuration;
                throw new ArgumentOutOfRangeException("Invalid type of element to return");
            }
        }
    }


}
