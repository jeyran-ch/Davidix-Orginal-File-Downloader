
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Davidix_Original_File_Downloader
{
    class CLI_cmd
    {
        public static string dir, src, fltr;
        Helper clshp = new Helper();

        static string[] dlfiles, svfiles;
        public static void StartCLI()
        {
            Console.WriteLine("src - dir - fltr - dl");
            string cmd = Console.ReadLine().ToLower();
            switch (cmd)
            {
                case "src":
                    getSRC();
                    break;
                /*************************/

                case "dir":
                    getDIR();
                    break;
                /*************************/

                case "fltr":
                    getFLTR();
                    break;
                /*************************/

                case "dl":
                    dl();
                    break;
                /*************************/



                case "exit":
                case "q":
                  
                    break;




                default:
                    break;
            }
        }

        public static void getSRC()
        {
            Console.WriteLine("Enter Src");
            src = Console.ReadLine();
            Console.WriteLine("Src => " + src);
            StartCLI();
        }

        public static void getDIR()
        {
            Console.WriteLine("Enter Dir");
            src = Console.ReadLine();
            Console.WriteLine("Dir => " + dir);
            StartCLI();
        }

        public static void getFLTR()
        {
            Console.WriteLine("Enter Fltr");
            src = Console.ReadLine();
            Console.WriteLine("Fltr => " + fltr);
            StartCLI();
        }

        public static void dl()
        {
            if (Directory.Exists(dir))
                svfiles = clshp.GetDirFiles(dir, null, true, false, null);
            for (int i = 0; i < dlfiles.Length; i++)
                clshp.Download((dlfiles[i]), svfiles[i]);
        }

        public void getFils()
        {
            if (Directory.Exists(dir))
                svfiles = clshp.GetDirFiles(dir, null, true, false, null);
        }
    }
}
