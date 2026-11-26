using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos = new List<Aluno>()
        {
            new Aluno()
            {
                AlunoID = 1,
                Nome = "Aluno Teste",
                Email = "aluno@mail.com",
                Telefone = "(99) 99999-9999",
                Endereco = "Rua X, numero 1000",
                Complemento = "apto 1001",
                Bairro = "Bairro do Aluno",
                Municipio = "Cidade do Aluno",
                Uf = "RJ",
                Cep = "27100-000"
            }
        };

        // GET: Aluno
        public IActionResult Index()
        {
            return View(alunos);
        }

        // GET: Aluno/Details/5
        public IActionResult Details(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aluno/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Nome,Email,Telefone,Endereco,Complemento,Bairro,Municipio,Uf,Cep")] Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.AlunoID = alunos.Select(a => a.AlunoID).DefaultIfEmpty(0).Max() + 1;
                    alunos.Add(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possível inserir os dados: " + e.Message);
            }
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public IActionResult Edit(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var alunoExistente = alunos.FirstOrDefault(a => a.AlunoID == aluno.AlunoID);
                    if (alunoExistente == null)
                    {
                        return NotFound();
                    }
                    alunos.Remove(alunoExistente);
                    alunos.Add(aluno);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", "Não foi possível editar os dados: " + e.Message);
            }
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public IActionResult Delete(int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
            if (aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
                if (aluno == null)
                {
                    return NotFound();
                }
                alunos.Remove(aluno);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Não foi possível excluir o aluno: {ex.Message}");
            }
            return View(alunos);
        }
    }
}
