using Aplicacao.Models;
using Aplicacao.Service;
using System.Web.Mvc;

namespace Aplicacao.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var retorno = GitHubService.GetAll();
            return View(retorno.items);
        }

        public ActionResult Detalhes(int id, string owner, string name)
        {
            return View(GitHubService.GetItem(id, owner, name));
        }
    }
}