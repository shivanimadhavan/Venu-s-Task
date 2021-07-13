using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AjaxCountryTask.Models;

namespace AjaxCountryTask.Controllers
{
    public class CasController : Controller
    {
        // GET: Cas
        public ActionResult Index()
        {
            AjaxCountryEntities sd = new AjaxCountryEntities();
            ViewBag.CountryList=new SelectList(GetCountryList(),"Cid","Cname");
            return View();
        }
        public List<Country> GetCountryList()
        {
            AjaxCountryEntities sd = new AjaxCountryEntities();
            List<Country> countries = sd.Countries.ToList();
            return countries;
        }
        public ActionResult GetStateList(int Cid)
        {
            AjaxCountryEntities sd = new AjaxCountryEntities();
            List<State> selectList = sd.States.Where(x => x.Cid == Cid).ToList();
            ViewBag.Slist = new SelectList(selectList, "Sid", "Sname");
            return PartialView("DisplayStates");
        }
        public ActionResult GetCityList(int Sid)
        {
            AjaxCountryEntities sd = new AjaxCountryEntities();
            List<City> selectList = sd.Cities.Where(x => x.Sid == Sid).ToList();
            ViewBag.Citylist = new SelectList(selectList, "Cityid", "Cityname");
            return PartialView("DisplayCities");
        }
    }
}