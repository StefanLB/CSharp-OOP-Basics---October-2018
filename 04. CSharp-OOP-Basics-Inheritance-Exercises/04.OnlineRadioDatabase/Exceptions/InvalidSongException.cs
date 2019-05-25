using System;
using System.Collections.Generic;
using System.Text;

namespace _04.OnlineRadioDatabase.Exceptions
{
    public class InvalidSongException : Exception
    {
        public override string Message => "Invalid song.";
    }
}
