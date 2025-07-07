using LightIdiomas.Data;
using LightIdiomas.Entities;
using LightIdiomas.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LightIdiomas.Controllers
{
    public class CadastrarClienteController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public CadastrarClienteController(ILogger<HomeController> logger,
                                 ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult CadastrarCliente()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClientesViewModel cadastrarCliente)
        {
            if(ModelState.IsValid)
            {

                // Validar se CPF já está cadastrado
                var clienteExistente = _context.Clientes.FirstOrDefault(c => c.CPF == cadastrarCliente.CPF);

                if (clienteExistente != null)
                {
                    ModelState.AddModelError("CPF", "CPF já cadastrado.");
                    return View(cadastrarCliente);
                }

                var cliente = new Clientes
                {
                    Nm_Cliente = cadastrarCliente.Nome_Cliente,
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

                TempData["Sucesso"] = "Cliente cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(cadastrarCliente);
        }
    }
}
