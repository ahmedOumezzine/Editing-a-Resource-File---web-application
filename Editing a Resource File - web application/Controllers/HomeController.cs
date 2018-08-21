using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Reflection;
using System.Resources;
using System.IO;
using System.Xml;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Editing_a_Resource_File___web_application.Controllers
{
    public class HomeController : Controller
    {
        public string filename;
        public ActionResult Index()
        {
            ViewBag.cmblanguages = ResxEditor.Getlanguages.GetLists(Request.PhysicalApplicationPath, "language");
            ViewBag.cmbPages = ResxEditor.GetResources.GetListPagess(Request.PhysicalApplicationPath);
            return View();
        }
        public JsonResult GetAllRessource(String Page)
        {
            List <String> items = ResxEditor.GetResources.GetListRessourcess(Request.PhysicalApplicationPath, Page);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index2(Editing_a_Resource_File___web_application.Models.RessourcesModel forms)

        {
            if (!ModelState.IsValid)
            {
                return View(forms);
            }
            filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + forms.cmbPages + "\\"+ forms.cmbressource + "." + forms.cmblanguages + ".resx";
        
            ViewBag.file = forms.cmbPages + "\\" + forms.cmbressource + forms.cmblanguages ;
            ViewBag.slist = ResxEditor.GetResources.GetDetailRessources(filename);
            return View();
        }



        public ActionResult Update(string Id, string key,string file)
        {
            filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + file;
            ResXResourceSet rset = new ResXResourceSet(filename);
            ViewBag.file = file;
            ViewBag.Id = Id;
            ViewBag.Text = rset.GetString(key);
            return View();
        }

        [HttpPost]
        public ActionResult Update2(string Id ,string file, string txtResourceValue)
        {
            int id = Convert.ToInt32(Id);
            filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + file;
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filename);
            XmlNodeList nlist = xmlDoc.GetElementsByTagName("data");
            XmlNode childnode = nlist.Item(id);
            childnode.Attributes["xml:space"].Value = "default";
            xmlDoc.Save(filename);
            XmlNode lastnode = childnode.SelectSingleNode("value");
            lastnode.InnerText = txtResourceValue;
            xmlDoc.Save(filename);
            ViewBag.Text = "Resource File Updated...";
            return View();
        }
    }
}