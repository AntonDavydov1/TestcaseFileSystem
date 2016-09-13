using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TestcaseFileSystem.ApiModels;

namespace TestcaseFileSystem.Controllers
{
    public class FileSystemController : ApiController
    {
        public DirInfo GetSizesInfo()
        {
            return GetSizesInfo(HttpContext.Current.Server.MapPath("~"));
        }

        const int s10 = 10485760; // 10 * 1024 * 1024
        const int s50 = 52428800; // 50 * 1024 * 1024
        const int s100 = 104857600; // 100 * 1024 * 1024

        public DirInfo GetSizesInfo(string directory)
        {
            int s_less_10 = 0;
            int s_10_50 = 0;
            int s_more_100 = 0;

            string error = string.Empty;

            try
            {
                string[] files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);

                for (int i = 0; i < files.Length; ++i)
                {
                    FileInfo fi = new FileInfo(files[i]);

                    if (fi.Length < s10) ++s_less_10;
                    if (fi.Length >= s10 && fi.Length <= s50) ++s_10_50;
                    if (fi.Length > s100) ++s_more_100;
                }
            }
            catch (DirectoryNotFoundException exc)
            { error = exc.Message; }
            catch (Exception exc) { error = exc.Message; }

            if (!String.IsNullOrEmpty(error)) return new DirInfo { error = error };
            else
            {
                var curDirInfo = new DirectoryInfo(directory);

                return new DirInfo { s_0_10 = s_less_10, s_10_50 = s_10_50, s_100plus = s_more_100, folders = Directory.GetDirectories(directory), files = Directory.GetFiles(directory), parentDir = curDirInfo.Parent.FullName, curPath = curDirInfo.FullName };
            }
        }

    }

}