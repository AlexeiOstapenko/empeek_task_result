using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using Test_case.Models;

namespace Test_case.Infrastructure
{
      class SearchFile
    {
        public static List<FileInfo> myFiles=new List<FileInfo>();
        public SearchFile(List<FileInfo> _files)
        {
            MyFiles = _files;
        }
       public static List<FileInfo> MyFiles { get; set; }
       public static void WalkDirectoryTree(DirectoryInfo root)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDirs = null;
            try
            {
                files = root.GetFiles("*.*");
            }
            catch (UnauthorizedAccessException e)
            {
                Debug.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Debug.WriteLine(e.Message);
            }
            if (files != null)
            {
                
                myFiles.AddRange(files);
                subDirs = root.GetDirectories();
                foreach (DirectoryInfo dirInfo in subDirs)
                {
                    WalkDirectoryTree(dirInfo);
                }
         
            }
        }
    }
}