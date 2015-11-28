using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contacts.Web.Controllers
{
    public class ContactsController : Controller
    {
        public ActionResult Layout()
        {
            return View();
        }
    }
}