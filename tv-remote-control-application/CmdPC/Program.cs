using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace CmdPC
{
    class Program
    {
        static SerialPort sp;
        static void Main(string[] args)
        {
            Console.WriteLine("Ports List:");
            string[] s= SerialPort.GetPortNames();
            foreach(string si in s)
            {
                Console.WriteLine("   " + si);
            }
            

            Console.Write("Enter Port Name (COMX): ");
            sp = new SerialPort(Console.ReadLine());
            sp.DataReceived += datareceivedonport;
            try
            {
                sp.Open();
            }
            catch (Exception ex){
                sp.Close();
                Console.WriteLine("Error: " + ex.Message);
                Console.ReadLine();

                return;
            }
            Console.WriteLine("Periph connected");
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(CurrentDomain_ProcessExit);
            // do some work
            while (true) ;

        }

        static void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            Console.WriteLine("exit");
        }

        static string lastcode="";
        static string code;
        private static void datareceivedonport(object sender, SerialDataReceivedEventArgs e)
        {
            code = "";
            while(sp.BytesToRead!=0)
            {
                char c = (char)sp.ReadByte();
                if (c!='\n')
                {
                    code += c;
                }
                else
                {
                    bool repeat = (code == "FFFFFFFF\r");
                    if (repeat)
                        code = lastcode;
                    else
                        lastcode = code;
                    switch (code)
                    {
                        case "FF30CF\r":
                            PowerManager.Hibernate();
                            //Shutdown or sleep                            
                            Console.WriteLine("Hibernate");

                            break;
                        case "FFA857\r":
                        case "FFB04F\r":
                            Volume.VolUp();
                            Console.WriteLine("VolUp");
                            break;
                        case "FFF00F\r":
                        case "FF8877\r":
                            Volume.VolDown();
                            Console.WriteLine("VolDown");
                            break;
                        case "FF50AF\r":
                            if (repeat == false)
                            {
                                Volume.Mute();
                                Console.WriteLine("Mute");
                            }
                            break;
                        case "FF00FF\r":
                        case "FF708F\r":
                            if (repeat == false) { 
                                VirtualKeyboard.MediaPlayPause();
                                Console.WriteLine("MediaPlayPause");
                            }
                            break;
                        case "FF48B7\r":
                            if (repeat == false) { 
                                VirtualKeyboard.MediaNextTrack();
                                Console.WriteLine("MediaNextTrack");
                            }
                            break;
                        case "FFB847\r":
                            if (repeat == false) { 
                                VirtualKeyboard.MediaPreviousTrack();
                                Console.WriteLine("MediaPreviousTrack");
                            }
                            break;
                        case "FF38C7\r":
                            if (repeat == false) { 
                                VirtualKeyboard.MediaStop();
                                Console.WriteLine("MediaStop");
                            }
                            break;
                        
                    }
                }
               
            }
        }
    }
}
