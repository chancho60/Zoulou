using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using Zoulou.Models.MMEG;

namespace Zoulou.Controllers {
    public class MMEGController : BaseController {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Glyphs(GlyphViewModel GlyphViewModel) {
            if(GlyphViewModel.AvailableRarities == null || GlyphViewModel.AvailableShapes == null || GlyphViewModel.AvailableStats == null) {
                var GlyphRepository = new GlyphRepository();
                GlyphViewModel.AvailableRarities = GlyphRepository.getRarities();
                GlyphViewModel.AvailableShapes = GlyphRepository.getShapes();
                GlyphViewModel.AvailableStats = GlyphRepository.getStats();
            }

            return View(GlyphViewModel);
        }

        public ActionResult Creatures(CreatureViewModel CreatureViewModel) {
            if(CreatureViewModel.Creatures == null) {
                var CreatureRepository = new CreatureRepository();
                CreatureViewModel.Creatures = CreatureRepository.getCreatures();

                if(String.IsNullOrEmpty(CreatureViewModel.SortOrder)) {
                    CreatureViewModel.SortOrder = "Name" + this.ControllerContext.RouteData.Values["lang"].ToString();
                }
            }

            var SortElements = CreatureViewModel.Elements.Where(E => E.Value == true).Select(E => E.Key).ToArray();
            var SortRoles = CreatureViewModel.Roles.Where(R => R.Value == true).Select(R => R.Key).ToArray();

            CreatureViewModel.CreaturesFiltered = CreatureViewModel.Creatures
                .Where(C => C.EvolutionId == 0)
                .Where(C => SortElements.Contains(C.Element.Id))
                .Where(C => SortRoles.Contains(C.Role.Id))
                .OrderBy(CreatureViewModel.SortOrder + " desc")
                .ToList();

            return View(CreatureViewModel);
        }

        public ActionResult Creature(int id) {
            var CreatureRepository = new CreatureRepository();
            var Creature = CreatureRepository.getCreatureById(id);

            return View(Creature);
        }
    }
}