using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Davidix_Original_File_Downloader
{
    static class Program
    {
        public static string dir, src, fltr;

        private static void HideConsoleWindow()
        {
            var handle = GetConsoleWindow();

            ShowWindow(handle, 0);
        }

        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Any() && args[0] == "-cli")
            {
                Console.WriteLine("Welcome to Davidix Orginal File Downloader");
                Console.WriteLine("For Switching to GUI mode type 'GUI'");
                Console.WriteLine("For Switching to CLI mode type 'CLI'");
                string cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "GUI":
                    case "gui":
                        StartGUI();
                        break;


                    case "CUI":
                    case "cui":
                        StartCLI();
                        break;





                    default:
                        StartCLI();
                        break;
                }
            }
            else
            {
                StartGUI();
            }

            


        }
        public static void StartGUI()
        {
            HideConsoleWindow();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        public static void StartCLI()
        {
            Console.WriteLine("src - dir - fltr");
            string cmd = Console.ReadLine();
            switch (cmd)
            {
                case "SRC":
                case "src":
                    getSRC();
                    break;

                case "exit":
                case "q":
                    Application.Exit();
                    break;




                default:
                    break;
            }
        }

        public static void getSRC() 
        {
            Console.WriteLine("Enter Src");
            src = Console.ReadLine();
            Console.WriteLine("src => "+src);
            StartCLI();
        }

    }
    }
