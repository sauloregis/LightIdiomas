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
                EstadoId = cliente.Cidade.EstadoId,
                DataNascimento = cliente.DataNascimento,
                Genero = cliente.Genero,
                TurmaId = cliente.TurmaId,
                NivelIngles = cliente.NivelIngles
            };

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
    }
}
