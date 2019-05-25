using System;
using System.Collections.Generic;

namespace _04.OnlineRadioDatabase
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfSongs = int.Parse(Console.ReadLine());
            var playlist = new Playlist();

            for (int i = 0; i < numOfSongs; i++)
            {
                try
                {
                    var songTokens = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                    SongValidator.Song(songTokens);

                    Track track = new Track(songTokens[0], songTokens[1], songTokens[2]);

                    Console.WriteLine("Song added.");
                    playlist.Add(track);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(playlist);
        }
    }
}
