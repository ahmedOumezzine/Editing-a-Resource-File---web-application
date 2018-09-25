using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Xml;

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

        public static List<String> GetListRessourcess(String PhysicalApplicationPath, String Page)
        {
            List<String> cmbresources = new List<String>();
            string resourcespath = PhysicalApplicationPath + "App_GlobalResources/" + Page;
            DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            foreach (FileInfo filInfo in dirInfo.GetFiles())
            {
                string filename = filInfo.Name.Split('.')[0];
                if (!filename.ToUpper().EndsWith(".designer.cs".ToUpper()))
                {
                    if (!cmbresources.Contains(filename))
                        cmbresources.Add(filename);
                }
            }
            return cmbresources;
        }

        public static SortedList GetDetailRessources(String filename)
        {
            Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
            ResXResourceReader RrX = new ResXResourceReader(stream);
            IDictionaryEnumerator RrEn = RrX.GetEnumerator();
            SortedList slist = new SortedList();
            while (RrEn.MoveNext())
            {
                slist.Add(RrEn.Key, RrEn.Value);
            }
            RrX.Close();
            stream.Dispose();
            return slist;
        }

        public static String GetString(String filename,String key)
        {
            ResXResourceSet rset = new ResXResourceSet(filename);
            return rset.GetString(key);
        }

        public static String Update(String filename, int key,String txtResourceValue)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNodeList nlist = xmlDoc.GetElementsByTagName("data");
            XmlNode childnode = nlist.Item(key);
            childnode.Attributes["xml:space"].Value = "default";
            xmlDoc.Save(filename);
            XmlNode lastnode = childnode.SelectSingleNode("value");
            lastnode.InnerText = txtResourceValue;
            xmlDoc.Save(filename);
            return "Resource File Updated...";
        }
    }
}