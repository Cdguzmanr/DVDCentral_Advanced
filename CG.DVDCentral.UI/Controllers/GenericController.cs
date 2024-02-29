using CG.DVDCentral.PL2.Entities;
using CG.DVDCentral.UI.Models;
using CG.Utility;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace CG.DVDCentral.UI.Controllers
{
    public class GenericController<T> : Controller where T : class, new()
    {
        dynamic manager;
        private ApiClient apiClient;        // Api Client helper    
        public GenericController(HttpClient httpClient)
        {
            this.apiClient = new ApiClient(httpClient.BaseAddress.AbsoluteUri);
            manager = (T)Activator.CreateInstance(typeof(T));  // Create an instance of the manager (T) using the ApiClient
        }

        public virtual IActionResult Index()
        {
            ViewBag.Title = "List of " + typeof(T).Name + "s";
            var entities = apiClient.GetList<T>(typeof(T).Name);
            return View(entities);
        }

        // Generic Methods 

        public virtual IActionResult Details(Guid id)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodName + " for " + typeof(T).Name;
            var entity = apiClient.GetItem<T>(typeof(T).Name, id);
            return View(entity);
        }

        public virtual IActionResult Create()
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodName + " for " + typeof(T).Name;
            return View();
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(T entity, bool rollback = false)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {                
                ViewBag.Title = methodName + " for " + typeof(T).Name;  
                var response = apiClient.Post<T>(entity, typeof(T).Name); // Post the entity to the API
                var result = response.Content.ReadAsStringAsync().Result; // Get the result from the API

                // TODO: Get the id

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = methodName + " for " + typeof(T).Name;
                ViewBag.Error = ex.Message;
                return View(entity);
            }
        }

        public virtual IActionResult Edit(Guid id)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodName + " for " + typeof(T).Name;
            var entity = apiClient.GetItem<T>(typeof(T).Name, id);
            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual IActionResult Edit(Guid id, T entity, bool rollback = false)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            try
            {
                ViewBag.Title = methodName + " for " + typeof(T).Name;
                var response = apiClient.Put<T>(entity, typeof(T).Name, id); // Post the entity to the API
                var result = response.Content.ReadAsStringAsync().Result; // Get the result from the API

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Title = methodName + " for " + typeof(T).Name;
                ViewBag.Error = ex.Message;
                return View(entity);
            }
        }

        public virtual IActionResult Delete(Guid id)
        {
            string methodName = System.Reflection.MethodBase.GetCurrentMethod().Name;
            ViewBag.Title = methodName + " for " + typeof(T).Name;
            var entity = apiClient.GetItem<T>(typeof(T).Name, id);
            return View(entity);
        }

        [HttpPost]
        public virtual IActionResult Delete(Guid id, T entity, bool rollback)
        {
            try
            {
                var response = apiClient.Delete(typeof(T).Name, id); // Post the entity to the API

                var result = response.Content.ReadAsStringAsync().Result; // Get the result from the API
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(entity);
            }
        }


    }
}
