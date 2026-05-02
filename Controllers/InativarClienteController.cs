using LightIdiomas.Data;
using Microsoft.AspNetCore.Mvc;

namespace LightIdiomas.Controllers
{
    public class InativarClienteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InativarClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AlternarStatus(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            cliente.Ativo = !cliente.Ativo;

            _context.SaveChanges();

            TempData["Sucesso"] = cliente.Ativo ? "Cliente ativado com sucesso" : "Cliente inativado com sucesso!";
            return RedirectToAction("Index", "Home");
        }
    }
}
