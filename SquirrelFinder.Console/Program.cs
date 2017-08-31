using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Timers;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;

namespace SquirrelFinder
{

    class Program
    {
        static Timer _timer;
        static NutMonitor _finder;
        static SoundPlayer _player;

        static WebRequest _request;
        static SquirrelFinderSound _soundBeingPlayed;
        static void Main(string[] args)
        {
            _soundBeingPlayed = SquirrelFinderSound.Squirrel;
            Console.Write("Enter a Site to Watch: ");
            var SiteName = Console.ReadLine();
            _finder = new NutMonitor();
            _player = new SoundPlayer();
            _timer = new Timer(5000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();

            while (!(Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape))
            {
                if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter)
                {
                    _player.Stop();
                }
            }
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            _finder.PlayTone(SquirrelFinderSound.Gears);
        }

        static void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {

        }
    }
}
