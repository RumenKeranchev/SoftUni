using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class StationaryPhone : ICallable
    {
        private string phoneNumber;

        public string PhoneNumber
        {
            get
            {
                if (phoneNumber.ToCharArray().Any(c => !char.IsDigit(c)))
                {
                    throw new ArgumentException("Invalid number!");
                }
                return phoneNumber;
            }
            set => phoneNumber = value;
        }

        public void Call()
        {
            Console.WriteLine($"Dialing... {PhoneNumber}");
        }
    }
}
