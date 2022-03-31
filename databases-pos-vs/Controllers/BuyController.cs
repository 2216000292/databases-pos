using databases_pos_vs.Common;
using databases_pos_vs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace databases_pos_vs.Controllers
{
    public class BuyController : Controller
    {
        public IActionResult Index(string key)
        {
            List<Products> list = new List<Products>();
            string sqlWhere = "";
            if (!string.IsNullOrWhiteSpace(key))
            {
                sqlWhere = " and name like '%" + key + "%' ";
                ViewBag.Key = key;
            }
            list = ProductsDB.GetList(sqlWhere);

            return View(list);
        }
    }
}
