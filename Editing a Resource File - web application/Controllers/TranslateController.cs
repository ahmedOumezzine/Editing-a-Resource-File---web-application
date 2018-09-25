using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace Editing_a_Resource_File___web_application.Controllers
{
    public class TranslateController : Controller
    {
        // GET: Translate

        public string filename;
        public ActionResult Index()
        {
            ViewBag.cmblanguages = ResxEditor.Getlanguages.GetLists(Request.PhysicalApplicationPath, "language");
            ViewBag.cmbPages = ResxEditor.GetResources.GetListPagess(Request.PhysicalApplicationPath);
            return View();
        }
        public JsonResult GetAllRessource(String Page)
        {
            List<String> items = ResxEditor.GetResources.GetListRessourcess(Request.PhysicalApplicationPath, Page);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllLanguages(String Page)
        {
            List<ResxEditor.Language> items = ResxEditor.Getlanguages.GetLists(Request.PhysicalApplicationPath, Page);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Index2(Editing_a_Resource_File___web_application.Models.RessourcesModel forms)

        {
            if (!ModelState.IsValid)
            {
                return View(forms);
            }
            if (ResxEditor.Getlanguages.LanguageCodeDefault == forms.cmblanguages)
            {
                filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + forms.cmbPages + "\\" + forms.cmbressource + ".resx";
            }
            else
            {
                filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + forms.cmbPages + "\\" + forms.cmbressource + "." + forms.cmblanguages + ".resx";
            }
            ViewBag.file = filename;
            ViewBag.slist = ResxEditor.GetResources.GetDetailRessources(filename);
            return View();
        }

        public ActionResult Update(string Id, string key, string file)
        {
            filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + file + ".resx";
            ViewBag.file = file;
            ViewBag.Id = Id;
            ViewBag.Text = ResxEditor.GetResources.GetString(filename, key);
            return View();
        }

        [HttpPost]
        public ActionResult Update2(string Id, string file, string txtResourceValue)
        {
            int id = Convert.ToInt32(Id);
            filename = Request.PhysicalApplicationPath + "App_GlobalResources\\" + file + ".resx";
            ViewBag.Text = ResxEditor.GetResources.Update(filename, id, txtResourceValue);
            return View();
        }
    }
}