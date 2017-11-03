using HockeyAppCrashReport.Logic;
using HockeyAppCrashReport.Models.HockeyAppCrashReportLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace HockeyAppCrashReport.Controllers.HockeyAppCrashReport
{
    public class CrashReportController : Controller
    {
        CrashReasonReportLogic crashReasonReportLogic = new CrashReasonReportLogic();
        // GET: CrashReport/index/page/per_page
        public ActionResult Index(int? current_page, int? per_page)
        {
            CrashReasonReportList crashlist = crashReasonReportLogic.List(current_page, per_page);
            return View(crashlist);
        }

        // GET: CrashReport/Details/id/page/per_page
        public ActionResult Details(string id, int? current_page, int? per_page)
        {
            CrashReasonReportDetails crashlist = crashReasonReportLogic.Details(id, current_page, per_page);

            return View(crashlist);
        }
        //GET: CrashReport/Histogram/startDate/endTime
        public ActionResult Histogram(string startDate, string endTime)
        {
            Histogram histogram = crashReasonReportLogic.Histogram(Convert.ToDateTime(startDate), Convert.ToDateTime(endTime));
            
            return View(histogram);
        }
        // GET: CrashReport/CrashSearch/query
        public ActionResult CrashSearch(string crashProperty = "model", string querytxt = "", int? current_page = 1, int? per_page = 25)
        {
            string query = crashProperty + ":" + querytxt + "*";
            ViewBag.CrashProperty = crashProperty;
            ViewBag.Querytxt = querytxt;
            CrashSearch crashSearch = crashReasonReportLogic.CrashSearch(query, current_page, per_page);
            crashSearch.querytxt = querytxt;
            crashSearch.crashProperty = crashProperty;
            return View(crashSearch);
        }        // GET: CrashReport/Create



        public ActionResult BarChart(string startDate, string endTime)
        {
            Histogram histogram = crashReasonReportLogic.Histogram(Convert.ToDateTime(startDate), Convert.ToDateTime(endTime));

            TwoDimensionalData data = new TwoDimensionalData();
            //data.Data.AddRange(histogram?.histogram?.Select(x => new { x., x.ID ));
            //data.Data.Add(new int[] { 2007, 23045 });
            //data.Data.Add(new int[] { 2008, 20345 });
            //data.Data.Add(new int[] { 2009, 23405 });
            //data.Data.Add(new int[] { 2010, 23425 });
            //data.Data.Add(new int[] { 2011, 21345 });
            //data.Data.Add(new int[] { 2012, 32345 });
            //data.Data.Add(new int[] { 2013, 48345 });
            //data.Data.Add(new int[] { 2014, 62345 });
            //data.Data.Add(new int[] { 2015, 72345 });
            //data.Data.Add(new int[] { 2016, 82345 });
            //data.Data.Add(new int[] { 2017, 89345 });
            //data.Data.Add(new int[] { 2018, 92345 });
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: CrashReport/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrashReport/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CrashReport/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CrashReport/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CrashReport/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
