using LightIdiomas.Data;
using LightIdiomas.Entities;
using LightIdiomas.Models;
using LightIdiomas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace LightIdiomas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(CadastrarClienteViewModel cadastrarCliente)
        {
            if(ModelState.IsValid)
            {
                var cliente = new Clientes
                {
                    NomeCompleto = cadastrarCliente.Nome,
                    Email = cadastrarCliente.Email,
                    Telefone = cadastrarCliente.Telefone,
                    Whatsapp = cadastrarCliente.Whatsapp,
                    Profissao = cadastrarCliente.Profissao,
                    Endereco = cadastrarCliente.Endereco,
                    Nacionalidade = cadastrarCliente.Nacionalidade,
                    RG = cadastrarCliente.RG,
                    CPF = cadastrarCliente.CPF
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(cadastrarCliente);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
