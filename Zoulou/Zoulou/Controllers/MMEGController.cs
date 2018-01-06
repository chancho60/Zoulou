using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using Zoulou.Models.MMEG;
using Zoulou.ViewModels.MMEG;
using Zoulou.Repositories.MMEG;

namespace Zoulou.Controllers {
    public class MMEGController : BaseController {
        //[ValidateInput(false)]
        //[OutputCache(CacheProfile = "ZoulouCache")]
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
                    CreatureViewModel.SortOrder = "Name" + Thread.CurrentThread.CurrentCulture.ToString();
                }
            }

            var SortElements = CreatureViewModel.Elements.Where(E => E.Value == true).Select(E => E.Key).ToArray();
            var SortRoles = CreatureViewModel.Roles.Where(R => R.Value == true).Select(R => R.Key).ToArray();

            CreatureViewModel.CreaturesFiltered = CreatureViewModel.Creatures
                .Where(C => C.EvolutionId == 0)
                .Where(C => SortElements.Contains(C.Element.Id.ToString()))
                .Where(C => SortRoles.Contains(C.Role.Id.ToString()))
                .OrderBy(CreatureViewModel.SortOrder + " desc")
                .ToList();

            return View(CreatureViewModel);
        }

        [Route("MMEG/Creature/{species}/{stage}/{element}")]
        public ActionResult Creature(CreatureViewModel CreatureViewModel) {
            if(this.ControllerContext.RouteData.Values["species"].ToString() != "0" && this.ControllerContext.RouteData.Values["stage"].ToString() != "0" && this.ControllerContext.RouteData.Values["element"].ToString() != "0") {
                if(CreatureViewModel.Creatures == null) {
                    var CreatureRepository = new CreatureRepository();
                    CreatureViewModel.Creatures = CreatureRepository.getCreatures();
                }

                foreach(var Creature in CreatureViewModel.Creatures) {
                    if(Creature.SpeciesId == this.ControllerContext.RouteData.Values["species"].ToString().AsInt()
                        && Creature.EvolutionStage == this.ControllerContext.RouteData.Values["stage"].ToString().AsInt()
                        && Creature.Element.Id == this.ControllerContext.RouteData.Values["element"].ToString().AsInt()) {
                        CreatureViewModel.Creature = Creature;
                    }
                }

                return View(CreatureViewModel);
            } else {
                return RedirectToAction("Creatures");
            }
        }
    }
}