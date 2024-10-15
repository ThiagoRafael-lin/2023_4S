using Microsoft.AspNetCore.Mvc;
using sistema.Contexts;

namespace sistema.Controllers
{
    public class AtividadeController : Controller
    {
        private readonly SistemaContext _context;

        public AtividadeController(SistemaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            int? atividadeId = HttpContext.Session.GetInt32("AtividadeId");

            if (atividadeId == null)
            {
                return RedirectToAction("Index");
            }

            var descricao = _context.Atividades.Find(atividadeId);

            var turmas = _context.Turmas.Where(t => t.ProfessorId == atividadeId).ToList();

            return View(turmas);

        }
    }
}
