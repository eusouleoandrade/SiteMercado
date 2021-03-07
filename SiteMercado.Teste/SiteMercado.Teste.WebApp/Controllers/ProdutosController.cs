using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SiteMercado.Teste.Application.DTOs.Produto;
using SiteMercado.Teste.Application.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;

namespace SiteMercado.Teste.WebApp.Controllers
{
    public class ProdutosController : BaseController
    {
        private readonly HttpClient _client;

        public ProdutosController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("ApiProdutosClient");
        }

        [HttpGet]
        public IActionResult Index()
        {
            HttpResponseMessage httpResponse = _client.GetAsync($"produtos").Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });
                Notify(response.Title, true);
                return View();
            }

            var produtoResponseList = JsonConvert.DeserializeObject<IEnumerable<ProdutoResponse>>(httpResponse.Content.ReadAsStringAsync().Result);

            return View(produtoResponseList.Select(s => s.ToProdutoViewModel()));
        }

        [HttpGet]
        public IActionResult Details(Guid id)
        {
            HttpResponseMessage httpResponse = _client.GetAsync($"produtos/{id}").Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });
                Notify(response.Title, true);
                return RedirectToAction("Index");
            }

            var produtoResponse = JsonConvert.DeserializeObject<ProdutoResponse>(httpResponse.Content.ReadAsStringAsync().Result);

            return View(produtoResponse.ToProdutoViewModel());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var contentCreate = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse =  _client.PostAsync("produtos", contentCreate).Result;
                var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });

                if (httpResponse.IsSuccessStatusCode)
                {
                    Notify(response.Title, false);
                    return RedirectToAction(nameof(Index));
                }
                else
                     Notify(response.Title, true);
            }

            return View(viewModel);
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            HttpResponseMessage httpResponse = _client.GetAsync($"produtos/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var viewModel = JsonConvert.DeserializeObject<ProdutoViewModel>(httpResponse.Content.ReadAsStringAsync().Result);
                return View(viewModel);
            }
            else
            {
                var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });
                Notify(response.Title, true);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var contentEdit = new StringContent(JsonConvert.SerializeObject(viewModel), Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = _client.PutAsync($"produtos/{viewModel.Id}", contentEdit).Result;
                var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });

                if (httpResponse.IsSuccessStatusCode)
                {
                    Notify(response.Title, false);
                    return RedirectToAction(nameof(Index));
                }
                else
                    Notify(response.Title, true);
            }

            return View(viewModel);
        }

        public ActionResult Delete(Guid id)
        {
            HttpResponseMessage httpResponse = _client.GetAsync($"produtos/{id}").Result;

            if (httpResponse.IsSuccessStatusCode)
            {
                var viewModel = JsonConvert.DeserializeObject<ProdutoViewModel>(httpResponse.Content.ReadAsStringAsync().Result);
                return View(viewModel);
            }
            else
            {
                var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });
                Notify(response.Title, true);
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProdutoViewModel viewModel)
        {
            HttpResponseMessage httpResponse = _client.DeleteAsync($"tipoexame/{viewModel.Id}").Result;
            var response = JsonConvert.DeserializeAnonymousType(httpResponse.Content.ReadAsStringAsync().Result, new { Title = "" });

            if (httpResponse.IsSuccessStatusCode)
            {
                Notify(response.Title, false);
                return RedirectToAction(nameof(Index));
            }
            else
                Notify(response.Title, true);

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
                _client?.Dispose();
            base.Dispose(disposing);
        }
    }
}
