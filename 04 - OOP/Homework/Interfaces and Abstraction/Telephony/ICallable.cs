using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public interface ICallable
    {
        public string PhoneNumber { get; set; }

        void Call();
    }
}
