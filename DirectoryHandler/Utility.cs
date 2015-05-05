using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DirectoryHandler
{
    public static class Utility
    {
        public enum Format
        {
            Bytes,
            KB,
            MB,
            GB,
            All
        }

        public static string GetSize(long length,Format format=Format.All)
        {
            string result = string.Empty;

            double dblength= length;
            switch (format)
            {
                case Format.Bytes:
                    result= dblength + " Bytes";
                    break;
                case Format.KB:
                    result = (dblength/1024) + " KB";
                    break;
                case Format.MB:
                    result = (dblength / 1048576) + " MB";
                    break;
                case Format.GB:
                    result = (dblength/1073741824) + " GB";
                    break;
                default:
                    result = GetInReadableSize(dblength);
                    break;
            }


            return result;
        }

       
        private static string GetInReadableSize(double length)
        {
            string result = string.Empty;
            double count = length;
            while (1024 <= count)
            {
                count /= 1024;
            }

            double temp=(length / count);
            result=Convert.ToString(count);
            if (temp < 1024)
                result +=" "+ Format.Bytes.ToString();
            else if(temp >=1024 && temp <1048576)
                result += " " + Format.KB.ToString();
            else if (temp >= 1048576 && temp < 1073741824)
                result += " " + Format.MB.ToString();
            else if (temp >= 1073741824)
                result += " " + Format.GB.ToString();
            return result;
        }

        public static bool IsValidDInput(string input)
        {
            bool result = false;
            if (String.IsNullOrWhiteSpace(input))
                result = false;
            else if (Regex.IsMatch(input, "[a-zA-Z]"))
                result = true;
            return result;
        }
    }
}
