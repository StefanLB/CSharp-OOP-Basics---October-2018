using _04.OnlineRadioDatabase.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04.OnlineRadioDatabase
{
    public static class SongValidator
    {
        public static void Song(string[] parts)
        {
            if (parts.Length!=3)
            {
                throw new InvalidSongException();
            }
        }

        public static void AuthorName(string name)
        {
            if (name.Length<3||name.Length>20)
            {
                throw new InvalidArtistNameException();
            }
        }

        public static void SongName(string name)
        {
            if (name.Length<3 || name.Length>30)
            {
                throw new InvalidSongNameException();
            }
        }

        public static void LengthFormat(string format)
        {
            var split = format.Split(":", StringSplitOptions.RemoveEmptyEntries);
            if (split.Length!=2)
            {
                throw new InvalidSongLengthException();
            }

            var minutes = split[0];
            var seconds = split[1];

            if (!minutes.Any(char.IsDigit) || !seconds.Any(char.IsDigit))
            {
                throw new InvalidSongLengthException();
            }
        }

        public static void Minutes(int minutes)
        {
            if (minutes<0 || minutes >14)
            {
                throw new InvalidSongMinutesException();
            }
        }

        public static void Seconds(int seconds)
        {
            if (seconds < 0 || seconds > 59)
            {
                throw new InvalidSongSecondsException();
            }
        }
    }
}
