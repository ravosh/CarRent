using CarRent.Models;
using Microsoft.CSharp.RuntimeBinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using CarRent.Models;
using System.IO;
using System.Web.Helpers;
using System.Data;

namespace CarRent.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserStory1()
        {
            carlist();
            return View();
        }

        public void carlist()
        {
            Datalayer dl = new Datalayer();
            DataSet ds = new DataSet();
            ds = dl.runQueryDs("select * from Tbl_Car_Info where status='Available'");

            List<SelectListItem> lss = new List<SelectListItem>();
            lss.Add(new SelectListItem { Text = "Select Car", Value = "" });
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lss.Add(new SelectListItem { Text = dr["carname"].ToString(), Value = dr["Id"].ToString() });
            }
            ViewBag.carlist = new SelectList(lss, "Value", "Text");
        }

        [HttpPost]
        public ActionResult UserStory1(userstory1 model)
        {
            Datalayer dl = new Datalayer();

            int i = dl.SP_USERSTORY1_INFO(model);
            if (i > 0)
            {
                TempData["MSG"] = model.carid+" is the Car Number!!";
                ModelState.Clear();
            }
            else
            {
                TempData["MSG"] = "Failed!!";
            }
            return RedirectToAction("UserStory1");
        }

        

        public ActionResult addcarinfo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult addcarinfos(carinfo model, HttpPostedFileBase carimage)
        {
            if (carimage == null)
            {
                Datalayer dl = new Datalayer();

                model.carimage = "";
                int i = dl.SP_CAR_INFO(model);
                if (i > 0)
                {
                    TempData["MSG"] = "Data Posted Successfully!!";
                    ModelState.Clear();
                }
                else
                {
                    TempData["MSG"] = "Failed!!";
                }
            }
            else
            {
                string _imgname = string.Empty;
                if (System.Web.HttpContext.Current.Request.Files.AllKeys.Any())
                {
                    var pic = System.Web.HttpContext.Current.Request.Files["carimage"];
                    if (pic.ContentLength > 0)
                    {
                        var fileName = Path.GetFileName(pic.FileName);
                        var _ext = Path.GetExtension(pic.FileName);

                        _imgname = Guid.NewGuid().ToString();
                        var _comPath = Server.MapPath("/Upload/MVC_") + _imgname + _ext;
                        _imgname = "MVC_" + _imgname + _ext;

                        ViewBag.Msg = _comPath;
                        var path = _comPath;

                        // Saving Image in Original Mode
                        pic.SaveAs(path);

                        // resizing image
                        MemoryStream ms = new MemoryStream();
                        WebImage img = new WebImage(_comPath);

                        //if (img.Width > 200)
                        //    img.Resize(200, 150);
                        img.Save(_comPath);
                        Datalayer dl = new Datalayer();
                        string filepath = "/Upload/" + _imgname;
                        model.carimage = filepath;
                        int i = dl.SP_CAR_INFO(model);
                        if (i > 0)
                        {
                            TempData["MSG"] = "Data Posted Successfully!!";
                            ModelState.Clear();
                        }
                        else
                        {
                            TempData["MSG"] = "Failed!!";
                        }
                    }
                }
            }

            return RedirectToAction("addcarinfo");

        }


        public JsonResult carlists(int? id = 0)
        {
            Datalayer dl = new Datalayer();
            // loginmodel p = new loginmodel();
            DataSet ds = new DataSet();
            ds = dl.runQueryDs("select * from Tbl_Car_Info where id='" + id + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {
                ViewBag.carimage = ds.Tables[0].Rows[0]["carimage"].ToString();
            }


            return Json(ViewBag.carimage, JsonRequestBehavior.AllowGet);
        }


        public ActionResult UserStory2()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult UserStory2(userstory2 model)
        {
            Datalayer dl = new Datalayer();
            DataSet ds = new DataSet();
            model.status = "Rented";
            ds = dl.SP_USERSTORY2_INFO(model);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TempData["MSG"] = ds.Tables[0].Rows[0]["msg"].ToString();
                ModelState.Clear();
            }
            else
            {
                TempData["MSG"] = "Failed!!";
            }
            return RedirectToAction("UserStory2");
        }

        public ActionResult UserStory3()
        {

            return View();
        }


        [HttpPost]
        public ActionResult UserStory3(userstory3 model)
        {
            Datalayer dl = new Datalayer();
            DataSet ds = new DataSet();
            ds = dl.SP_USERSTORY3_INFO(model);
            if (ds.Tables[0].Rows.Count > 0)
            {
                TempData["MSG"] = ds.Tables[0].Rows[0]["msg"].ToString();
                if(ds.Tables[1].Rows[0]["howmanyhour"].ToString() != "")
                {

                TempData["time"] = ds.Tables[1].Rows[0]["howmanyhour"].ToString();
                }
                if (ds.Tables[1].Rows[0]["price"].ToString() != "")
                {

                    TempData["rate"] = ds.Tables[1].Rows[0]["price"].ToString();
                }
                ModelState.Clear();
            }
            else
            {
                TempData["MSG"] = "Failed!!";
            }
            return RedirectToAction("UserStory3");
        }

        public ActionResult UserStory4()
        {
            carlistss();
            return View();
        }


        [HttpPost]
        public ActionResult UserStory4(userstory3 model)
        {
            Datalayer dl = new Datalayer();
            int i = dl.SP_USERSTORY4_INFO(model);
            if (i > 0)
            {
                TempData["MSG"] = "Data related to car no. '"+model.carid+"' has been deleted!!";
                
                ModelState.Clear();
            }
            else
            {
                TempData["MSG"] = "We don't have data related to '"+model.carid+"' car no.!!";
            }
            return RedirectToAction("UserStory4");
        }

        public void carlistss()
        {
            Datalayer dl = new Datalayer();
            DataSet ds = new DataSet();
            ds = dl.runQueryDs("select u3.status,ci.CarName,CarId from [dbo].[Tbl_UserStory3] u3 join Tbl_Car_Info ci on ci.Id=u3.CarId");

            List<SelectListItem> lss = new List<SelectListItem>();
            lss.Add(new SelectListItem { Text = "Select Car", Value = "" });
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                lss.Add(new SelectListItem { Text = dr["carname"].ToString(), Value = dr["CarId"].ToString() });
            }
            ViewBag.carlist = new SelectList(lss, "Value", "Text");
        }
    }
}