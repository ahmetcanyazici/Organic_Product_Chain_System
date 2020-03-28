using OrganikUrunZincirTakip.Dto;
using OrganikUrunZincirTakip.Models;
using System.Linq;
using System.Web.Mvc;

namespace OrganikUrunZincirTakip.Controllers
{
    public class HomeController : Controller
    {
        OrganikUrunDBContext context = new OrganikUrunDBContext();
        // GET: Home
        public ActionResult Index()
        {
            Sati sati = new Sati();
            return View(sati);
        }

        [HttpPost]
        public ActionResult Index(Sati sati)
        {
            var satis = context.Satis.FirstOrDefault(s => s.SatısID == sati.SatısID);
            return View(satis);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDto dto)
        {
            var user = context.Users.FirstOrDefault(x => x.Username == dto.Username && x.Password == dto.Password);
            if (user != null)
            {
                Session["KisiId"] = user.Id;
                Session["RoleId"] = user.RoleId.ToString();

                if (user.Role.Id == 1)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (user.Role.Id == 5)
                {
                    return RedirectToAction("Index", "Denetlemes");
                }
                else if (user.Role.Id == 2)
                {
                    return RedirectToAction("Index", "Depolamas");
                }
                else if (user.Role.Id == 3)
                {
                    return RedirectToAction("Index", "Nakliyes");
                }
                else if (user.Role.Id == 4)
                {
                    return RedirectToAction("Index", "Satis");
                }
                return View();
            }
            else
            {
                ViewBag.Message = "Kullanıcı Bulunamadı";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}