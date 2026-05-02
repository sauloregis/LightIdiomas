using LightIdiomas.Data;
using LightIdiomas.Entities;
using LightIdiomas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Text.RegularExpressions;

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

            model.Estados = _context.Estados
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.UF + " - " + e.Nome
                }).ToList();

            model.Turmas = _context.Turmas
                .Select(t => new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome
                }).ToList();

            ViewData["Modo"] = "Cadastrar";
            return View(model);
        }

        [HttpPost]
        public IActionResult CadastrarCliente(ClientesViewModel cadastrarCliente)
        {
            if (!ModelState.IsValid)
            {
                RepopularSelects(cadastrarCliente);
                return View(cadastrarCliente);
            }

            var cpfLimpo = Regex.Replace(cadastrarCliente.CPF ?? string.Empty, @"\D", "");

            var clienteExistente = _context.Clientes.FirstOrDefault(c => c.CPF == cpfLimpo);

            if (clienteExistente != null)
            {
                ModelState.AddModelError("CPF", "CPF já cadastrado.");
                RepopularSelects(cadastrarCliente);
                return View(cadastrarCliente);
            }

            var rgLimpo = Regex.Replace(cadastrarCliente.RG ?? string.Empty, @"\D", "");
            var telefoneLimpo = Regex.Replace(cadastrarCliente.Telefone ?? string.Empty, @"\D", "");

            var cliente = new Clientes
            {
                Nm_Cliente = cadastrarCliente.Nome_Cliente,
                Email = cadastrarCliente.Email,
                Telefone = telefoneLimpo,
                Whatsapp = cadastrarCliente.Whatsapp,
                Profissao = cadastrarCliente.Profissao,
                Endereco = cadastrarCliente.Endereco,
                Nacionalidade = cadastrarCliente.Nacionalidade,
                RG = rgLimpo,
                CPF = cpfLimpo,
                CidadeId = cadastrarCliente.CidadeId,
                DataNascimento = cadastrarCliente.DataNascimento,
                Genero = cadastrarCliente.Genero,
                TurmaId = cadastrarCliente.TurmaId,
                NivelIngles = cadastrarCliente.NivelIngles,
                Ativo = true
            };

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            TempData["Sucesso"] = "Cliente cadastrado com sucesso!";
            return RedirectToAction("Index", "Home");
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

        private void RepopularSelects(ClientesViewModel model)
        {
            if (model is null)
                return;

            model.Generos = Enum.GetValues(typeof(Genero))
                .Cast<Genero>()
                .Select(g => new SelectListItem
                {
                    Value = ((int)g).ToString(),
                    Text = g.ToString()
                }).ToList();

            model.Estados = _context.Estados
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.UF + " - " + e.Nome
                }).ToList();

            model.Turmas = _context.Turmas
                .Select(t => new SelectListItem()
                {
                    Value = t.Id.ToString(),
                    Text = t.Nome
                }).ToList();

            if (model.EstadoId > 0)
            {
                model.Cidades = _context.Cidades
                    .Where(c => c.EstadoId == model.EstadoId)
                    .OrderBy(c => c.Nome)
                    .Select(c => new SelectListItem
                    {
                        Value = c.Id.ToString(),
                        Text = c.Nome
                    }).ToList();
            }
            else
            {
                model.Cidades = new List<SelectListItem>();
            }
        }
    }
}
