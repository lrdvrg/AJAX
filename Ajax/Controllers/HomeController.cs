using Ajax.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ajax.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        DBAccess.db dblayer = new DBAccess.db();
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getData()
        {
            DataSet ds = dblayer.showData();

            List<estudiantes> listreg = new List<estudiantes>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listreg.Add(new estudiantes
                {
                    Matricula = Convert.ToInt32(dr["Matricula"]),
                    Nombre = dr["Matricula"].ToString(),
                    Carrera = dr["Carrera"].ToString(),
                });
            }

            return Json(listreg, JsonRequestBehavior.AllowGet);
        }
    }
}