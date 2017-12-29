using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Zoulou.Models.MMEG;

namespace Zoulou.Controllers {
    public class MMEGController : BaseController {
        public ActionResult Index() {
            return View();
        }

        public async Task<ActionResult> Glyphs() {
            CancellationToken cToken = new CancellationToken();

            return await GlyphsAsync(cToken);
        }

        public async Task<ActionResult> GlyphsAsync(CancellationToken cancellationToken) {
            GlyphRepository GlyphRepository = new GlyphRepository();
            GlyphViewModel GlyphViewModel = new GlyphViewModel() {
                AvailableRarities = GlyphRepository.getRarities(),
                AvailableShapes = GlyphRepository.getShapes(),
                AvailableStats = GlyphRepository.getStats()
            };

            return View(GlyphViewModel);
        }
    }
}