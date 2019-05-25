using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Counters.Models;
namespace Counters.Controllers
{
    public class HomeController : Controller
    {
        FillingContext DbFill = new FillingContext();
        [HttpPost]
        public ActionResult Logins(Login log)
        {
            if (log.login == "Илья" && log.pass == "123")
            {
                return RedirectToAction("Index", log);       
            }
            return RedirectToAction("Contact");
        }

        public ActionResult Index(Login log)
        {
            if (log.login == "Илья" && log.pass == "123")
            {
                DateTime CurrentDate = new DateTime(2018, 12, 10);
                List<Filling> LstModel = DbFill.Fillings.Where(x => x.Date.Year == CurrentDate.Year && x.Date.Month == CurrentDate.Month && x.Date.Day == CurrentDate.Day).ToList();
                List<List<Filling>> fillings = new List<List<Filling>>();
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.AG02.Bossar_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.Arsil_Dos.Arsil1_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.CombiBloc.Combiblock_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.CombiFit.Combifit_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.Cvadrobloc.Kvadroblock_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.Krones_FMT.FMT_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.MainPLC.TBA11_Counter_Time")).ToList());
                fillings.Add(LstModel.Where(x => x.Name.Contains("Topics.MainPLC.TBA12_Counter_Time")).ToList());
                return View(fillings);
            }
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            Login log = new Login();

            return View(log);
        }
    }
}