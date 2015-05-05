using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DirectoryHandler;
using System.IO;
namespace FileSize
{
    class GetAllDetails
    {
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter Drive Letter make Sure it Exists(eg for D drive enter D):");
            string drive = string.Empty;
            bool isvalid;
            do
            {

                drive = Console.ReadLine();
                isvalid = Utility.IsValidDInput(drive);
                if (!isvalid)
                    Console.WriteLine("Invalid Input");
            }
            while (!isvalid);

            DirectoryBrowse dirbrowse=new DirectoryBrowse(drive+":\\");
            foreach (DirectoryInfo dir in dirbrowse.GetDirectorysInfo())
            {
                long size=dirbrowse.GetSize(dir);
                Console.WriteLine(dir + "  " + Utility.GetSize(size));
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
