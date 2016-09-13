using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestcaseFileSystem.ApiModels
{
    public class DirInfo
    {
        public int s_0_10;
        public int s_10_50;
        public int s_100plus;

        public string[] folders;
        public string[] files;

        public string parentDir;
        public string curPath;

        public string error;
    }
}