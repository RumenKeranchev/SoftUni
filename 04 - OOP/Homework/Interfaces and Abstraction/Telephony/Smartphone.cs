using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Telephony
{
    public class Smartphone : ICallable, IBrowsable
    {
        private string phoneNumber;
        private string url;

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

        public string Url
        {
            get
            {
                if (url.ToCharArray().Any(c => char.IsDigit(c)))
                {
                    throw new ArgumentException("Invalid URL!");
                }
                return url;
            }
            set => url = value;
        }

        public void Browse()
        {
            Console.WriteLine($"Browsing: {Url}!");
        }

        public void Call()
        {
            Console.WriteLine($"Calling... {PhoneNumber}");
        }
    }
}
