using LightIdiomas.Data;
using LightIdiomas.Entities;
using LightIdiomas.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LightIdiomas.Controllers
{
    public class CadastrarTurmaController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public CadastrarTurmaController(ILogger<HomeController> logger,
                                        ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult CadastrarTurma()
        {
            var model = new TurmaViewModel
            {
                Niveis = Enum.GetValues(typeof(NivelTurma))
                .Cast<NivelTurma>()
                .Select(n => new SelectListItem
                {
                    Value = ((int)n).ToString(),
                    Text = n.ToString()
                }).ToList(),

                Statuses = Enum.GetValues(typeof(StatusTurma))
                .Cast<StatusTurma>()
                .Select(s => new SelectListItem
                {
                    Value = ((int)s).ToString(),
                    Text = s.ToString()
                }).ToList(),

                Tipos = Enum.GetValues(typeof(TipoTurma))
                .Cast<TipoTurma>()
                .Select(t => new SelectListItem
                {
                    Value = ((int)t).ToString(),
                    Text = t.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CadastrarTurma(TurmaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var turma = new Turma
                {
                    Nome = model.Nome,
                    Dia = (DayOfWeek)model.Dia,
                    Horario = TimeSpan.Parse(model.Horario),
                    NivelIngles = (NivelTurma)model.NivelIngles,
                    Status = (StatusTurma)model.Status,
                    Tipo = (TipoTurma)model.Tipo
                };

                _context.Turmas.Add(turma);
                _context.SaveChanges();

                TempData["Sucesso"] = "Turma cadastrada com sucesso!";
                return RedirectToAction("Index", "Home");
            }

            model.Niveis = Enum.GetValues(typeof(NivelTurma)).Cast<NivelTurma>()
                .Select(n => new SelectListItem { Value = ((int)n).ToString(), Text = n.ToString() }).ToList();
            model.Statuses = Enum.GetValues(typeof(StatusTurma)).Cast<StatusTurma>()
                .Select(s => new SelectListItem { Value = ((int)s).ToString(), Text = s.ToString() }).ToList();
            model.Tipos = Enum.GetValues(typeof(TipoTurma)).Cast<TipoTurma>()
                .Select(t => new SelectListItem { Value = ((int)t).ToString(), Text = t.ToString() }).ToList();

            return View(model);
        }
    }
}
