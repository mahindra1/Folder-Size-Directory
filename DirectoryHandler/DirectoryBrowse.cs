using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryHandler
{
    public class DirectoryBrowse
    {
        private string _drive;
        public DirectoryBrowse(string drive)
        {
            _drive = drive;
        }
        
        DirectoryBrowse()
        {
        }

        private static DirectoryBrowse _Instance;

        public static DirectoryBrowse Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DirectoryBrowse();
                }
                return _Instance;
            }
        }

        public FileInfo[] GetFiles(DirectoryInfo dirinfo)
        {
            FileInfo[] result = null;

            return result;
        }

        public FileInfo[] GetFiles(string dirinfo)
        {
            FileInfo[] result = null;

            return result;
        }

        public DirectoryInfo GetDirectoryInfo(string dirpath)
        {
            DirectoryInfo result = null;
            result = new DirectoryInfo(dirpath);
            return result;
        }

        public DirectoryInfo[] GetDirectorysInfo(DirectoryInfo dirpath)
        {
            DirectoryInfo[] result = null;
            result = dirpath.GetDirectories();
            return result;
        }
        public DirectoryInfo[] GetDirectorysInfo()
        {
            DirectoryInfo[] result = null;
            result = new DirectoryInfo(_drive).GetDirectories();
            return result;
        }
        //public DirectoryInfo GetDirectoryInfo(Directory dirpath)
        //{
        //    DirectoryInfo result = null;

        //    return result;
        //}

        public long GetSize(DirectoryInfo dirinfo)
        {
            long result = 0;
            try
            {
                foreach (DirectoryInfo dr in dirinfo.GetDirectories())
                {
                    result += GetSize(dr);
                }
                if (dirinfo.GetFiles() != null) 
                result += dirinfo.GetFiles().Sum(q => q.Length);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            return result;
        }

        public long GetThisSize()
        {
            long result = 0;
            string drivepath = _drive;
            DirectoryInfo dirinfo = GetDirectoryInfo(drivepath);
            result = GetSize(dirinfo);
            return result;
        }
    }
}
