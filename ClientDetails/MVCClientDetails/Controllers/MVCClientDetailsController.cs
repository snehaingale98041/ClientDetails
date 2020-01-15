using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCClientDetails.Models;
using System.Net.Http;

namespace MVCClientDetails.Controllers
{
    public class MVCClientDetailsController : Controller
    {
        // GET: MVCClientDetails
        public ActionResult Index()            
        {
            IEnumerable<MVCClinetDetailsModel> ClientList;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("tblClientDetails").Result;
            ClientList = response.Content.ReadAsAsync<IEnumerable<MVCClinetDetailsModel>>().Result;
            return View(ClientList);
        }

        public ActionResult AddOrEdit(int id =0)
        {
            if(id == 0 )
                return View(new MVCClinetDetailsModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("tblClientDetails/"+id.ToString()).Result;
                return View(response.Content.ReadAsAsync<MVCClinetDetailsModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult AddOrEdit(MVCClinetDetailsModel Client)
        {
            if(Client.ClientDetailsID == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("tblClientDetails", Client).Result;
                TempData["SuccessMessage"] = "Client details are saved successfully.";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("tblClientDetails/"+Client.ClientDetailsID, Client).Result;
                TempData["SuccessMessage"] = "Client details are updated successfully.";
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(long id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("tblClientDetails/"+ id.ToString()).Result;
            TempData["SuccessMessage"] = "Client details are deleted successfully.";
            return RedirectToAction("Index"); 
        }



    }
}