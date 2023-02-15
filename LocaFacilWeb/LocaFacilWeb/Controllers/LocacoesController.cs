using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using LocaFacilWeb.Models.Entity;
using LocaFacilWeb.Models.Repository;

namespace LocaFacilWeb.Controllers
{
    public class LocacoesController : Controller
    {
        private LocaFacilContext db = new LocaFacilContext();
 
        public async Task<ActionResult> Index()
        {
            var locacoes = db.Locacoes.Include(l => l.Cliente).Include(l => l.Filme);
            return View(await locacoes.ToListAsync());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = await db.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        } 
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.FilmeId = new SelectList(db.Filmes, "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ClienteId,FilmeId,DataAluguel,Devolução,ValorDiaAluguel,TotalAluguel")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Locacoes.Add(locacao);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.FilmeId = new SelectList(db.Filmes, "Id", "Nome", locacao.FilmeId);
            return View(locacao);
        }

        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = await db.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.FilmeId = new SelectList(db.Filmes, "Id", "Nome", locacao.FilmeId);
            return View(locacao);
        }

        // POST: Locacoes/Edit/5
        // Para se proteger de mais ataques, habilite as propriedades específicas às quais você quer se associar. Para 
        // obter mais detalhes, veja https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ClienteId,FilmeId,DataAluguel,Devolução,ValorDiaAluguel,TotalAluguel")] Locacao locacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(locacao).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", locacao.ClienteId);
            ViewBag.FilmeId = new SelectList(db.Filmes, "Id", "Nome", locacao.FilmeId);
            return View(locacao);
        }

        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Locacao locacao = await db.Locacoes.FindAsync(id);
            if (locacao == null)
            {
                return HttpNotFound();
            }
            return View(locacao);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Locacao locacao = await db.Locacoes.FindAsync(id);
            db.Locacoes.Remove(locacao);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
