using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace ResxEditor
{
    public class Language
    {
       public String Code { get; set; }
       public String Name { get; set; }
    }
    public static class Getlanguages
    {
        public static List<Language> GetLists(String PhysicalApplicationPath,String langage= "langage")
        {
            List<Language> cmblanguages = new List<Language>();
            string resourcespath = PhysicalApplicationPath + "App_GlobalResources/"+ langage;
            DirectoryInfo dirInfo = new DirectoryInfo(resourcespath);
            foreach (FileInfo filInfo in dirInfo.GetFiles())
            {
                string filename = filInfo.Name;
                if (!filename.ToUpper().EndsWith(".designer.cs".ToUpper()))
                {
                    ResXResourceReader RrX = new ResXResourceReader(filInfo.Directory.FullName+"\\"+filInfo.Name);
                    IDictionaryEnumerator RrEn = RrX.GetEnumerator();
                    Language language = new Language();
                    while (RrEn.MoveNext())
                    {
                        if (RrEn.Key.ToString()=="code")
                        language.Code = RrEn.Value.ToString();
                        if (RrEn.Key.ToString() == "Language")
                            language.Name = RrEn.Value.ToString();
                    }
                    cmblanguages.Add(language);
                    RrX.Close();
                }
            }
            return cmblanguages;
        }
    }
}
