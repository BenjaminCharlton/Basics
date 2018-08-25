using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using Basics.DomainModelling;
using Basics.Mvc.ViewModels;
using Basics.PatternsAndPractices;
using Basics.UI;

namespace Basics.Mvc.Controllers
{
    public abstract class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        [ThreadStatic]
        public static Controller _current = null;

        public static RedirectToActionResult Result = null;

        protected Controller()
        {
            _current = this;
        }

        //protected ViewResult View(
        //    Expression<Func<IActionResult>> actionOfSameName, 
        //    object model = null)
        //{
        //    return View(((MethodCallExpression)actionOfSameName.Body).Method.Name, model);
        //}

        public T GetFromTempData<T>(string key, T defaultValue = default(T))
        {
            var value = TempData[key];
            return value.IsNullOrDefault() ? defaultValue : JsonConvert.DeserializeObject<T>(value.ToString());
        }

        public void PutInTempData<T>(string key, T item)
        {
            TempData[key] = JsonConvert.SerializeObject(item);
        }

        //public static Controller Current
        //{
        //    get
        //    {
        //        var current = _current;
        //        if (current.IsNull())
        //            return null;
        //        if (current.HttpContext.IsNull())
        //            return null;

        //        return current;
        //    }
        //}

        protected override void Dispose(bool disposing)
        {
            _current = null;
            base.Dispose(disposing);
        }
    }
}
