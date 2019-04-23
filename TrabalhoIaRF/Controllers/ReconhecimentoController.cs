using System;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TrabalhoIaRF.Services;

namespace TrabalhoIaRF.Controllers
{
    public class ReconhecimentoController : Controller
    {
        private ReconhecimentoService _reconhecimentoService;

        public ReconhecimentoController()
        {
            _reconhecimentoService = new ReconhecimentoService();
        }

        // GET: Reconhecimento
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> UploadAsync()
        {
            try
            {
                HttpPostedFileBase file = Request.Files[0];

                return Json(await _reconhecimentoService.BuscarEmocao(file.InputStream), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                var a = ex.Message;
                throw;
            }
        }
    }
}