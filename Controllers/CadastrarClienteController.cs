using LightIdiomas.Data;
using LightIdiomas.Entities;
using LightIdiomas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var model = new ClientesViewModel();

            model.Generos = Enum.GetValues(typeof(Genero))
                .Cast<Genero>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                }).ToList();

            return View(model);
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClientesViewModel cadastrarCliente)
        {
            if(ModelState.IsValid)
            {
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
                    CPF = cadastrarCliente.CPF,
                    CidadeId = cadastrarCliente.CidadeId,
                    DataNascimento = cadastrarCliente.DataNascimento,
                    Genero = cadastrarCliente.Genero,
                    TurmaId = cadastrarCliente.TurmaId,
                    NivelIngles = cadastrarCliente.NivelIngles
                };

                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                TempData["Sucesso"] = "Cliente cadastrado com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            return View(cadastrarCliente);
        }
        
        [HttpGet]
        public JsonResult ObterCidadesPorEstado(int estadoId)
        {
            var cidades = _context.Cidades
                .Where(c => c.EstadoId == estadoId)
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Nome
                }).ToList();

            return Json(cidades);
        }
    }
}
