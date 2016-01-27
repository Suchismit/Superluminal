using Superluminal.Models;
using Superluminal.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Superluminal.Controllers
{
    public class ParentSearchController : Controller
    {
        [HttpGet]
        public ActionResult ParentSearch()
        {
            using (var parentContext = new SuperluminalContext())
            {
                return View("~/Views/Parent/ParentSearch.cshtml");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ParentSearchDetail(ParentSearch model)
        {
            var parentSearchList = new List<Parent>();
            var parent = new Parent();

            using (var parentContext = new SuperluminalContext())
            {
                if (model != null)
                {
                    var parentSearchDetail = (from parents in parentContext.Parents
                                              where (parents.Id == (model.Id ?? 0) || parents.Phone == (model.Phone ?? 0) || parents.FirstName.Contains(model.Name ?? ""))
                                              select new
                                              {
                                                  Id = parents.Id,
                                                  FirstName = parents.FirstName,
                                                  LastName = parents.LastName,
                                                  MiddleName = parents.MiddleName,
                                                  PostCode = parents.PostCode,
                                                  Phone = parents.Phone
                                              }).ToList();

                    foreach (var item in parentSearchDetail)
                    {
                        parent = new Parent
                        {
                            Id = item.Id,
                            FirstName = item.FirstName,
                            MiddleName = item.MiddleName,
                            LastName = item.LastName,
                            Phone = item.Phone,
                            PostCode = item.PostCode
                        };
                        parentSearchList.Add(parent);
                    }
                }
            }
            return PartialView("~/Views/Parent/_ParentSearchGrid.cshtml", parentSearchList);
        }

      
        [HttpGet]
        public JsonResult GetParentNames(string term)
        {
            List<string> parentNames = new List<string>();

            if (!string.IsNullOrEmpty(term))
            {
                using (var parentContext = new SuperluminalContext())
                {
                    parentNames = parentContext.Parents.Where(p => p.FirstName.StartsWith(term)).Select(m => m.FirstName).ToList();
                }
            }
            return Json(parentNames, JsonRequestBehavior.AllowGet);
        }
    }
}