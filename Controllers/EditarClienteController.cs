using LightIdiomas.Data;
using LightIdiomas.Entities;
using LightIdiomas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LightIdiomas.Controllers
{
    public class EditarClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EditarClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult EditarCliente(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            var clienteEditavel = new ClientesViewModel
            {
                IdCliente = cliente.Id,
                Nome_Cliente = cliente.Nm_Cliente,
                Nacionalidade = cliente.Nacionalidade,
                Endereco = cliente.Endereco,
                RG = cliente.RG,
                CPF = cliente.CPF,
                Profissao = cliente.Profissao,
                Email = cliente.Email,
                Telefone = cliente.Telefone,
                Whatsapp = cliente.Whatsapp,
                CidadeId = cliente.CidadeId,
                EstadoId = _context.Cidades.FirstOrDefault(c => c.Id == cliente.CidadeId)?.EstadoId ?? 0,
                DataNascimento = cliente.DataNascimento,
                Genero = cliente.Genero,
                TurmaId = cliente.TurmaId,
                NivelIngles = cliente.NivelIngles
            };

            RepopularSelects(clienteEditavel);

            ViewData["Modo"] = "Editar";
            return View("~/Views/CadastrarCliente/CadastrarCliente.cshtml", clienteEditavel);
        }

        [HttpPost]
        public IActionResult EditarCliente(ClientesViewModel model)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == model.IdCliente);

            if (cliente != null)
            {
                cliente.Nm_Cliente = model.Nome_Cliente;
                cliente.Nacionalidade = model.Nacionalidade;
                cliente.Endereco = model.Endereco;
                cliente.RG = model.RG;
                cliente.CPF = model.CPF;
                cliente.Profissao = model.Profissao;
                cliente.Email = model.Email;
                cliente.Telefone = model.Telefone;
                cliente.Whatsapp = model.Whatsapp;
                cliente.CidadeId = model.CidadeId;
                cliente.DataNascimento = model.DataNascimento;
                cliente.Genero = model.Genero;
                cliente.TurmaId = model.TurmaId;
                cliente.NivelIngles = model.NivelIngles;

                _context.SaveChanges();

                TempData["Sucesso"] = "Cliente editado com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Index", "Home");
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
