using System;
using System.Collections.Generic;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var mixedPhones = new List<ICallable>();
            var smartphones = new List<Smartphone>();

            var phones = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            var urls = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var phoneNumber in phones)
            {
                ICallable phone;
                if (phoneNumber.Length == 7)
                {
                    phone = new StationaryPhone();
                }
                else
                {
                    phone = new Smartphone();
                }

                phone.PhoneNumber = phoneNumber;
                mixedPhones.Add(phone);

            }

            foreach (var url in urls)
            {
                var phone = new Smartphone();
                phone.Url = url;
                smartphones.Add(phone);
            }

            foreach (var phone in mixedPhones)
            {
                try
                {
                    phone.Call();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
            
            foreach (var phone in smartphones)
            {
                try
                {
                    phone.Browse();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }
    }
}