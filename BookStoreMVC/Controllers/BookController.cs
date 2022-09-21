using BookStoreUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStoreMVC.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        public async Task<IActionResult> Index()
        {
            //var client = new RestClient("http://localhost:24552");
            //var request = new RestRequest("/api/Books", Method.Get);
            //var queryResult = client.Execute<List<BookModel>>(request).Data;

            //using (var httpClient = new HttpClient())
            //{
            //    //httpClient.BaseAddress = new Uri("http://localhost:24552");

            //    var response = await httpClient.GetAsync("http://localhost:24552/api/Books");
            //    var test = response.IsSuccessStatusCode;
            //    //string apiResponse = await response.Content.ReadAsStringAsync();

            //        //reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);

            //}
            //string Baseurl = "http://localhost:24552";
            //httpClient.BaseAddress = new Uri(Baseurl);
            //httpClient.DefaultRequestHeaders.Clear();
            ////Define request data format
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var response = await httpClient.GetStringAsync("http://localhost:24552/api/Books");
            //HttpResponseMessage Res = await httpClient.GetAsync(Baseurl+ "/api/Books");

            //httpClient.BaseAddress = new Uri("http://localhost:24552/api/");
            //HTTP GET
            HttpClient httpClient = new HttpClient();

            var responseTask = httpClient.GetAsync("http://localhost:24552/api/Books");
            responseTask.Wait();

            var result = responseTask.Result;
            return View();
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            //httpClient.BaseAddress = new Uri("http://localhost:24552/");
            //httpClient.DefaultRequestHeaders.Accept.Clear();
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ////GET Method
            //HttpResponseMessage response = await httpClient.GetAsync("api/Books/1");

            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
