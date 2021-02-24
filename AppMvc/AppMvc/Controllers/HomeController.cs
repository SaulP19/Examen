using Newtonsoft.Json;
using AppMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;


namespace AppMvc.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult>  Index()
        {
            // https://localhost:44307/api/PRODUCTOS/

            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync(" https://localhost:44307/api/PRODUCTOS/");
            var productos = JsonConvert.DeserializeObject<List<PRODUCTOS>>(json);

            return View(productos);
        }

        //Nuevo Usuario
        public ActionResult create()
        {
            return View();
        }

        [HttpPost]

        public ActionResult create(PRODUCTOS producto)
        {        
            using (var cliente = new HttpClient())

            {
                cliente.BaseAddress = new Uri("https://localhost:44307/api/");
                var postTask = cliente.PostAsJsonAsync<PRODUCTOS>("PRODUCTOS", producto);
                //var posTask = cliente.PostAsync("PRODUCTOS", producto, new JsonMediaTypeFormatter());
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Error contctar al administrador.");
            return View(producto);
        }

        //Modificar Usuario

        public ActionResult Edit(int id)
        {
            PRODUCTOS producto = null;
            using(var cliente = new HttpClient())
            {
                cliente.BaseAddress = new  Uri("https://localhost:44307/");
                var responseTask = cliente.GetAsync("api/PRODUCTOS/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTaks = result.Content.ReadAsAsync<PRODUCTOS>();
                    readTaks.Wait();
                    producto = readTaks.Result;
                }

            }
            return View(producto);
        }


        [HttpPost]
        public ActionResult Edit(PRODUCTOS productos)
        {
          
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44307/");
                //http post
                var putTask = cliente.PutAsJsonAsync($"api/PRODUCTOS/{productos.SKU}", productos);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(productos);
        }


        //Eliminar Usuario

        public ActionResult Delete(int id)
        {
            PRODUCTOS producto = null;
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44307/");
                var responseTask = cliente.GetAsync("api/PRODUCTOS/" + id.ToString());
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTaks = result.Content.ReadAsAsync<PRODUCTOS>();
                    readTaks.Wait();
                    producto = readTaks.Result;
                }

            }
            return View(producto);
        }


        [HttpPost]
        public ActionResult Delete(PRODUCTOS productos, int id)
        {

            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri("https://localhost:44307/");
                //http Delete
                var deleteTas = cliente.DeleteAsync($"api/PRODUCTOS/"+id);
                deleteTas.Wait();
                var result = deleteTas.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }
            return View(productos);
        }
    }
}