using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.Telephony
{
    public class SmartPhone : ICall, IBrowse
    {
        private List<string> callsToMake;
        private List<string> sitesToBrowse;

        public SmartPhone(List<string> callsToMake, List<string> sitesToBrowse)
        {
            this.callsToMake = callsToMake;
            this.sitesToBrowse = sitesToBrowse;
        }

        public string Browse(string site)
        {
            if (site.Any(x=>char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {site}!";
            }
        }

        public string Call(string number)
        {
            if (number.Any(x=>!char.IsDigit(x)))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var call in callsToMake)
            {
                sb.Append($"{Call(call)}\n");
            }
            foreach (var site in sitesToBrowse)
            {
                sb.Append($"{Browse(site)}\n");
            }

            return sb.ToString();
        }
    }
}
