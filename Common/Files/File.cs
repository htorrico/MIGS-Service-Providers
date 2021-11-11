using System;
using System.IO;

namespace Common.Files
{
    public static class FileService
    {

        public static void Save(string FullName, string Base64)
        {
            //File.WriteAllBytes(@"c:\yourfile", Convert.FromBase64String(Base64));
            File.WriteAllBytes(FullName, Convert.FromBase64String(Base64));
        }

        public static void Delete(string FullName)
        {
            //File.WriteAllBytes(@"c:\yourfile", Convert.FromBase64String(Base64));
            File.Delete(FullName);
        }
    }
}