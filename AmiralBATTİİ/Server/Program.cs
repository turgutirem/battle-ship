using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        //list of logged not playing people and their IPs
        public static Dictionary<string, Socket> loggedNicks = new Dictionary<string, Socket>();
        //list of logged playing people and thei IPs
        public static Dictionary<string, Socket> loggedplayingNicks = new Dictionary<string, Socket>();
        //person and list of enemies who offers game
        public static Dictionary<string, List<string>> enemiesoffers = new Dictionary<string, List<string>>();
        //Form1 Players Clicked Start <WHO+WHOM>
        public static List<string> whowhomSentStart = new List<string>();
        //Form1 Players Clicked GiveUp
        public static List<string> whowhomSentGiveUp = new List<string>();
        static void Main(string[] args)
        {
            //You cannot start 2 games in one time
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                return;

            AsynchronousSocketListener.StartListening();
        }
    }
}
