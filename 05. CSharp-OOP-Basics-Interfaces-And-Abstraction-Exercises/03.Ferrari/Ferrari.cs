using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Ferrari
{
    public class Ferrari : ICar
    {
        private string model;
        private string driver;

        public Ferrari(string driver)
        {
            this.model = "488-Spider";
            this.Driver = driver;
        }

        public string Driver
        {
            get { return driver; }
            set { driver = value; }
        }

        public string Brake()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{model}/{Brake()}/{Gas()}/{Driver}";
        }
    }
}
