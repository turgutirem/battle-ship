using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Server
{
    //https://msdn.microsoft.com/pl-pl/library/fx6588te(v=vs.110).aspx
    class AsynchronousSocketListener
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public AsynchronousSocketListener() { }

        public static void StartListening()
        {
            // Data buffer for incoming data.
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.
            // The DNS name of the computer
            // running the listener is "host.contoso.com".
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            int i = 0;
            Console.WriteLine("Choose server IPv4 address:");
            foreach (var item in ipHostInfo.AddressList)
            {
                Console.WriteLine(i + " - " + item);
                i++;
            }
            do
            {
                Console.Write("Type: ");
                i = (int)(Console.ReadKey().KeyChar) - 48;
                Console.WriteLine();
            } while (i < 0 || i >= ipHostInfo.AddressList.Count());

            IPAddress ipAddress = ipHostInfo.AddressList[i];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            // Create a TCP/IP socket.
            Socket listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and listen for incoming connections.
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                Console.WriteLine("Server is running (" + ipAddress + ")");
                while (true)
                {
                    // Set the event to nonsignaled state.
                    allDone.Reset();

                    // Start an asynchronous socket to listen for connections.                
                    listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);

                    // Wait until a connection is made before continuing.
                    allDone.WaitOne();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void AcceptCallback(IAsyncResult ar)
        {
            // Signal the main thread to continue.
            allDone.Set();

            // Get the socket that handles the client request.
            Socket listener = (Socket)ar.AsyncState;
            Socket handler = listener.EndAccept(ar);

            // Create the state object.
            StateObject state = new StateObject();
            state.workSocket = handler;
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            String content = String.Empty;

            // Retrieve the state object and the handler socket
            // from the asynchronous state object.
            StateObject state = (StateObject)ar.AsyncState;
            Socket handler = state.workSocket;

            int bytesRead = 0;

            // Read data from the client socket. 
            bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0)
            {
                // There  might be more data, so store the data received so far.
                state.sb.Append(Encoding.ASCII.GetString(
                    state.buffer, 0, bytesRead));

                // Check for end-of-file tag. If it is not there, read 
                // more data.
                content = state.sb.ToString();
                if (content.IndexOf("<EOF>") > -1)
                {
                    // All the data has been read from the 
                    // client. Display it on the console.
                    Console.WriteLine("Read {0} bytes from socket. \nData : {1}",
                        content.Length, content);

                    string messageBits = Utilities.getBinaryMessage(content);
                    //take 8 bits to recognize the communique
                    int bits8 = Convert.ToInt32(messageBits.Substring(0, 8), 2);//decimal value
                    //Get parameters sent with message
                    //parameters[0] is message flag
                    string[] parameters = content.Split(' ');
                    string nick = String.Empty;
                    string IPport = String.Empty;
                    string port = String.Empty;
                    string enemyNick = String.Empty;
                    string players = String.Empty;
                    bool result = false;
                    string whoSent = "";
                    string whomSent = "";
                    switch (bits8)
                    {
                        case 0://StarGame
                            {
                                //Get nick
                                whoSent = parameters[1];
                                //Get nick
                                whomSent = parameters[2];

                                if (Program.loggedplayingNicks.ContainsKey(whomSent))
                                {
                                    //Check if whomSent has sent message earlier

                                    //Check if whom+who is on whowhomSentStart & whowhomSentGiveUp
                                    if (!Program.whowhomSentStart.Contains(whomSent + whoSent) && !Program.whowhomSentGiveUp.Contains(whomSent + whoSent))
                                    {
                                        Program.whowhomSentStart.Add(whoSent + whomSent);
                                        state.buffer = new byte[1024];
                                        state.sb = new StringBuilder();
                                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                        new AsyncCallback(ReadCallback), state);
                                        break;
                                    }
                                    else if (Program.whowhomSentStart.Contains(whomSent + whoSent))//Check if whom+who is on whowhomSentStart
                                    {
                                        //Send OK to both players
                                        if (Program.loggedplayingNicks.ContainsKey(whoSent))
                                        {
                                            Send(Program.loggedplayingNicks[whoSent], ((char)16).ToString() + " <EOF>");
                                        }
                                        if (Program.loggedplayingNicks.ContainsKey(whomSent))
                                        {
                                            Send(Program.loggedplayingNicks[whomSent], ((char)0).ToString() + " <EOF>");
                                        }
                                        //Remove both players from whowhomSentStart
                                        Program.whowhomSentStart.Remove(whomSent + whoSent);
                                        state.buffer = new byte[1024];
                                        state.sb = new StringBuilder();
                                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                        new AsyncCallback(ReadCallback), state);
                                        break;

                                    }
                                    else if (Program.whowhomSentGiveUp.Contains(whomSent + whoSent))//Check if whom+who is on whowhomSentGiveUp
                                    {
                                        if (Program.loggedplayingNicks.ContainsKey(whoSent))
                                        {
                                            Send(Program.loggedplayingNicks[whoSent], ((char)17).ToString() + " <EOF>");
                                        }
                                        Program.whowhomSentGiveUp.Remove(whomSent + whoSent);
                                    }
                                }
                                else if (Program.loggedplayingNicks.ContainsKey(whoSent))
                                {
                                    Send(Program.loggedplayingNicks[whoSent], ((char)17).ToString() + " <EOF>");
                                    Program.loggedNicks.Add(whoSent, Program.loggedplayingNicks[whoSent]);
                                    Program.loggedplayingNicks.Remove(whoSent);
                                }
                                else if (Program.loggedNicks.ContainsKey(whoSent))
                                {
                                    Send(Program.loggedNicks[whoSent], ((char)17).ToString() + " <EOF>");
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 1://EndGame
                            {
                                nick = parameters[1];
                                enemyNick = parameters[2];

                                if (Program.loggedplayingNicks.ContainsKey(nick))
                                {
                                    if (!Program.loggedNicks.ContainsKey(nick))
                                    {
                                        Program.loggedNicks.Add(nick, Program.loggedplayingNicks[nick]);
                                        Program.loggedplayingNicks.Remove(nick);
                                    }
                                }
                                if (Program.loggedplayingNicks.ContainsKey(enemyNick))
                                {
                                    if (!Program.loggedNicks.ContainsKey(enemyNick))
                                    {
                                        Program.loggedNicks.Add(enemyNick, Program.loggedplayingNicks[enemyNick]);
                                        Program.loggedplayingNicks.Remove(enemyNick);
                                        Send(Program.loggedNicks[enemyNick], ((char)1).ToString() + " <EOF>");
                                    }
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 2: //Give up
                            {
                                //Get nick
                                whoSent = parameters[1];
                                //Get nick
                                whomSent = parameters[2];
                                //Check if whomSent has sent message earlier

                                //Check if whom+who is on whowhomSentStart & whowhomSentGiveUp
                                if (!Program.whowhomSentStart.Contains(whomSent + whoSent) && !Program.whowhomSentGiveUp.Contains(whomSent + whoSent))
                                {
                                    Program.whowhomSentGiveUp.Add(whoSent + whomSent);
                                    if (Program.loggedplayingNicks.ContainsKey(whoSent))
                                    {
                                        if (!Program.loggedNicks.ContainsKey(whoSent))
                                        {
                                            Program.loggedNicks.Add(whoSent, Program.loggedplayingNicks[whoSent]);
                                            Program.loggedplayingNicks.Remove(whoSent);
                                            Send(Program.loggedNicks[whoSent], ((char)10).ToString() + " <EOF>");
                                        }
                                    }
                                    state.buffer = new byte[1024];
                                    state.sb = new StringBuilder();
                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                    new AsyncCallback(ReadCallback), state);
                                    break;
                                }
                                else if (Program.whowhomSentStart.Contains(whomSent + whoSent))//Check if whom+who is on whowhomSentStart
                                {
                                    //Send Fail to whom player
                                    if (Program.loggedplayingNicks.ContainsKey(whomSent))
                                    {
                                        Send(Program.loggedplayingNicks[whomSent], ((char)9).ToString() + " <EOF>");
                                    }
                                    //Remove both players from whowhomSentStart
                                    Program.whowhomSentStart.Remove(whomSent + whoSent);

                                    //Remove both players from loggedplayingNicks
                                    if (Program.loggedplayingNicks.ContainsKey(whomSent))
                                    {
                                        if (!Program.loggedNicks.ContainsKey(whomSent))
                                        {
                                            Program.loggedNicks.Add(whoSent, Program.loggedplayingNicks[whomSent]);
                                            Program.loggedplayingNicks.Remove(whomSent);
                                        }
                                    }
                                    if (Program.loggedplayingNicks.ContainsKey(whoSent))
                                    {
                                        if (!Program.loggedNicks.ContainsKey(whoSent))
                                        {
                                            Program.loggedNicks.Add(whoSent, Program.loggedplayingNicks[whoSent]);
                                            Program.loggedplayingNicks.Remove(whoSent);
                                            Send(Program.loggedNicks[whoSent], ((char)10).ToString() + " <EOF>");
                                        }
                                    }
                                    state.buffer = new byte[1024];
                                    state.sb = new StringBuilder();
                                    handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                    new AsyncCallback(ReadCallback), state);
                                    break;
                                }
                                else if (Program.whowhomSentGiveUp.Contains(whomSent + whoSent))//Check if whom+who is on whowhomSentGiveUp
                                {
                                    Program.whowhomSentGiveUp.Remove(whomSent + whoSent);
                                    if (Program.loggedplayingNicks.ContainsKey(whoSent))
                                    {
                                        if (!Program.loggedNicks.ContainsKey(whoSent))
                                        {
                                            Program.loggedNicks.Add(whoSent, Program.loggedplayingNicks[whoSent]);
                                            Program.loggedplayingNicks.Remove(whoSent);
                                            Send(Program.loggedNicks[whoSent], ((char)10).ToString() + " <EOF>");
                                        }

                                    }
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 3: //SinkShip
                            {


                                break;
                            }
                        case 4: //Miss
                            {
                                enemyNick = parameters[1];
                                if (Program.loggedplayingNicks.ContainsKey(enemyNick))
                                {
                                    string message = ((char)4).ToString() + " <EOF>";
                                    Send(Program.loggedplayingNicks[enemyNick], message);
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 5: //Hit
                            {
                                enemyNick = parameters[1];
                                if (Program.loggedplayingNicks.ContainsKey(enemyNick))
                                {
                                    string message = ((char)5).ToString() + " <EOF>";
                                    Send(Program.loggedplayingNicks[enemyNick], message);
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 6://Shot
                            {
                                enemyNick = parameters[1];
                                string x = parameters[2];
                                string y = parameters[3];
                                if (Program.loggedplayingNicks.ContainsKey(enemyNick))
                                {
                                    string message = ((char)6).ToString() + " " + x + " " + y + " <EOF>";
                                    Send(Program.loggedplayingNicks[enemyNick], message);
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 7://GetOffers - somebody want to know who offers him game
                            {
                                //Get nick
                                nick = parameters[1];
                                //enemiesoffers
                                if (Program.enemiesoffers.ContainsKey(nick))
                                {
                                    //enemy1 enemy 2 ... enemy3
                                    string enemiesString = "";
                                    foreach (var item in Program.enemiesoffers[nick])
                                    {
                                        enemiesString += item + " ";
                                    }
                                    string message = ((char)7).ToString() + " " + enemiesString + "<EOF>";
                                    Send(handler, message);
                                }
                                else//Fail
                                {
                                    Send(handler, ((char)7).ToString() + " <EOF>");
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 8://Offer - somebody offers someone game
                            {
                                //who offers (enemy)
                                nick = parameters[1];
                                //whom he offers
                                enemyNick = parameters[2];
                                bool nickOffers = false;
                                if (Program.enemiesoffers.ContainsKey(nick))
                                {
                                    if (Program.enemiesoffers[nick].Contains(enemyNick))
                                    {
                                        Send(handler, ((char)10).ToString() + " <EOF>");
                                        nickOffers = true;
                                    }
                                }
                                if (nickOffers == false)
                                {
                                    if (Program.enemiesoffers.ContainsKey(enemyNick))
                                    {
                                        Program.enemiesoffers[enemyNick].Add(nick);
                                    }
                                    else
                                    {
                                        Program.enemiesoffers.Add(enemyNick, new List<string>() { nick });
                                    }
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 9: //Fail
                            {
                                Send(handler, ((char)10).ToString() + " <EOF>");

                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 10: //OK
                            {
                                Send(handler, ((char)10).ToString() + " <EOF>");

                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 11: //Join (Connection: Client joins to server) (TICK)
                            {
                                //Get nick
                                nick = parameters[1];
                                //Get IP
                                IPport = handler.RemoteEndPoint.ToString().Split(':')[0]; //get IP
                                //Get port No
                                port = parameters[2];
                                IPport += ":" + port;
                                //Check if nick is in dictionary
                                if (Program.loggedNicks.ContainsKey(nick)) //nick is occupied
                                {
                                    //Send Fail
                                    Send(handler, ((char)9).ToString() + " <EOF>");
                                }
                                else //User can join to server
                                {
                                    //Add to players dictionary <nick, IP>
                                    Program.loggedNicks.Add(nick, handler);
                                    //If everything OK send OK
                                    Send(handler, ((char)10).ToString() + " <EOF>");
                                }

                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 12: //Agree to play
                            {
                                nick = parameters[1];
                                enemyNick = parameters[2];
                                //Send OK to enemy you want to play
                                if (Program.enemiesoffers.ContainsKey(nick))
                                {
                                    if (nick != enemyNick) //If i don't decline
                                    {
                                        if (Program.enemiesoffers[nick].Contains(enemyNick))
                                        {
                                            if (Program.loggedNicks.ContainsKey(enemyNick))
                                            {
                                                Send(Program.loggedNicks[enemyNick], ((char)10).ToString() + " <EOF>");
                                                Program.loggedplayingNicks.Add(nick, Program.loggedNicks[nick]);
                                                Program.loggedplayingNicks.Add(enemyNick, Program.loggedNicks[enemyNick]);
                                                if (Program.enemiesoffers.ContainsKey(enemyNick))
                                                {
                                                    //decline offers to enemy
                                                    foreach (var item in Program.enemiesoffers[enemyNick])
                                                    {
                                                        //Send Fail to Rest
                                                        if (Program.loggedNicks.ContainsKey(item))
                                                        {
                                                            Send(Program.loggedNicks[item], ((char)9).ToString() + " <EOF>");
                                                        }
                                                    }
                                                }
                                                Program.loggedNicks.Remove(nick);
                                                Program.loggedNicks.Remove(enemyNick);
                                            }
                                            else
                                            {
                                                //Enemy Give up! You win!
                                                Send(Program.loggedNicks[nick], ((char)17).ToString() + " <EOF>");
                                            }
                                            Program.enemiesoffers[nick].Remove(enemyNick);
                                            //Program.loggedNicks.Remove(enemyNick);
                                        }
                                    }
                                    foreach (var item in Program.enemiesoffers[nick])
                                    {
                                        //Send Fail to Rest
                                        if (Program.loggedNicks.ContainsKey(item))
                                        {
                                            Send(Program.loggedNicks[item], ((char)9).ToString() + " <EOF>");
                                        }
                                    }
                                    Program.enemiesoffers[nick].Clear(); //Clear list
                                }

                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }

                        case 13: //GetEnemies <nick>
                            {
                                //Get nick
                                nick = parameters[1];
                                //Check if nick is in dict
                                result = Program.loggedNicks.ContainsKey(nick);
                                if (result == false) //If not in dictionary send Fail Communique to person
                                {
                                    Send(handler, ((char)12).ToString() + " <EOF>");
                                }
                                else
                                {
                                    //Get players from dictionary: only nicks!
                                    players = "";
                                    //"nick_1;ipv4_1:portNo_1 nick_2;ipv4_2:portNo_2 ... nick_n:ipv4_n:portNo_n "
                                    foreach (var item in Program.loggedNicks)
                                    {
                                        //omit person with <nick>
                                        if (!item.Key.Equals(nick))
                                            players += item.Key + ";" + item.Value.LocalEndPoint + " ";
                                    }
                                    if (players == "") //if nobody's online send Fail Communique
                                    {
                                        Send(handler, ((char)12).ToString() + " <EOF>");
                                    }
                                    else //Send Send Enemies Communique
                                    {
                                        players += "<EOF>";
                                        players = ((char)12).ToString() + " " + players;

                                        //Send enemies
                                        Send(handler, players);
                                    }
                                }

                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                        case 14://Close app
                            {
                                whoSent = parameters[1];
                                //Get nick
                                whomSent = parameters[2];
                                //

                                //Check if nick is in dict
                                if (Program.loggedNicks.ContainsKey(whoSent) == true)
                                {
                                    //Program.whowhomSentGiveUp.Add(whoSent + whomSent);
                                    Program.loggedNicks.Remove(whoSent);
                                }
                                if (Program.loggedplayingNicks.ContainsKey(whoSent) == true)
                                {
                                    Program.loggedplayingNicks.Remove(whoSent);
                                }

                                if (Program.enemiesoffers.ContainsKey(whoSent))
                                {
                                    //decline offers to enemy
                                    foreach (var item in Program.enemiesoffers[whoSent])
                                    {
                                        //Send Fail to Rest
                                        if (Program.loggedNicks.ContainsKey(item))
                                        {
                                            Send(Program.loggedNicks[item], ((char)9).ToString() + " <EOF>");
                                        }
                                    }
                                }

                                handler.Shutdown(SocketShutdown.Both);
                                handler.Close();
                                break;
                            }
                        case 15://GiveUp in MainGame
                            {
                                nick = parameters[1];
                                enemyNick = parameters[2];

                                if (Program.loggedplayingNicks.ContainsKey(nick))
                                {
                                    if (!Program.loggedNicks.ContainsKey(nick))
                                    {
                                        Program.loggedNicks.Add(nick, Program.loggedplayingNicks[nick]);
                                        Program.loggedplayingNicks.Remove(nick);
                                    }
                                }
                                if (Program.loggedplayingNicks.ContainsKey(enemyNick))
                                {
                                    if (!Program.loggedNicks.ContainsKey(enemyNick))
                                    {
                                        Program.loggedNicks.Add(enemyNick, Program.loggedplayingNicks[enemyNick]);
                                        Program.loggedplayingNicks.Remove(enemyNick);
                                        Send(Program.loggedNicks[enemyNick], ((char)17).ToString() + " <EOF>");
                                    }
                                }
                                state.buffer = new byte[1024];
                                state.sb = new StringBuilder();
                                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                                new AsyncCallback(ReadCallback), state);
                                break;
                            }
                    }
                }

            }
            else
            {
                // Not all data received. Get more.
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                new AsyncCallback(ReadCallback), state);
            }
        }

        private static void Send(Socket handler, String data)
        {
            // Convert the string data to byte data using ASCII encoding.
            byte[] byteData = Encoding.ASCII.GetBytes(data);

            // Begin sending the data to the remote device.
            handler.BeginSend(byteData, 0, byteData.Length, 0,
                new AsyncCallback(SendCallback), handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the socket from the state object.
                Socket handler = (Socket)ar.AsyncState;

                // Complete sending the data to the remote device.
                int bytesSent = handler.EndSend(ar);
                Console.WriteLine("Sent {0} bytes to client.", bytesSent);


            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
            }
        }
    }
}
