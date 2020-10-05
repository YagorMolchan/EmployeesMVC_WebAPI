using MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> employees = null;
            var responseTask = GlobalVariables.WebApiClient.GetAsync("Employee");
            responseTask.Wait();

            var result = responseTask.Result;
            if (result.IsSuccessStatusCode)
            {
                var readTask = result.Content.ReadAsAsync<IEnumerable<EmployeeModel>>();
                readTask.Wait();
                employees = readTask.Result;
            }
            else
            {
                employees = Enumerable.Empty<EmployeeModel>();
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(employees);


            //FIRST CODE
           
            //HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee").Result;
            //var list = response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;
            //return View(list);
        }

        public ActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
            {
                return View(new EmployeeModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<EmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(EmployeeModel model)
        {
            HttpResponseMessage response;
            if (model.Id == 0)
            {
                response = GlobalVariables.WebApiClient.PostAsJsonAsync("Employee", model).Result;
                TempData["SuccessMessage"] = "Данные успешно сохранены!";
            }
            else
            {
                response = GlobalVariables.WebApiClient.PutAsJsonAsync("Employee/" + model.Id.ToString(), model).Result;
                TempData["SuccessMessage"] = "Данные успешно сохранены!";
            }
            
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Данные успешно удалены!";
            return RedirectToAction("Index");
        }     
    }
}