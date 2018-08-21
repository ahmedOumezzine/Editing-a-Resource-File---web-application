using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResxEditor
{
    public static class GetResources
    {
        public static List<String> GetListPagess(String PhysicalApplicationPath)
        {
            List<String> cmbPages = new List<String>();
            string resourcespath = PhysicalApplicationPath + "App_GlobalResources/";
            DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            foreach (var filInfo in dirInfo.GetDirectories())
            {
                cmbPages.Add(filInfo.Name);
            }
            return cmbPages;
        }

        public static List<String> GetListRessourcess(String PhysicalApplicationPath)
        {
            List<String> cmbresources = new List<String>();
            string resourcespath = PhysicalApplicationPath + "App_GlobalResources/";
            DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            foreach (FileInfo filInfo in dirInfo.GetFiles())
            {
                string filename = filInfo.Name;
                if (!filename.ToUpper().EndsWith(".designer.cs".ToUpper()))
                {
                    var items = filename.Split('.');
                    cmbresources.Add(filename);
                }
            }
            return cmbresources;
        }
    }
}
