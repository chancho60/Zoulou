using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading;
using System.Web.Mvc;
using Zoulou.Helpers;
using Zoulou.Models.MMEG;
using Zoulou.Repositories.MMEG;
using Zoulou.ViewModels.MMEG;

namespace Zoulou.Controllers {
    public class MMEGController : BaseController {
        //[ValidateInput(false)]
        //[OutputCache(CacheProfile = "ZoulouCache")]
        public ActionResult Index() {
            return View();
        }

        public ActionResult Glyphs(GlyphViewModel GlyphViewModel) {
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
        [Route("MMEG/Creature")]
        public ActionResult Creature(CreatureViewModel CreatureViewModel) {
            if(ConvertHelper.IsOfTypeCode(this.ControllerContext.RouteData.Values["species"], TypeCode.Int32)
                && ConvertHelper.IsOfTypeCode(this.ControllerContext.RouteData.Values["stage"], TypeCode.Int32)
                && ConvertHelper.IsOfTypeCode(this.ControllerContext.RouteData.Values["element"], TypeCode.Int32)) {
                if(CreatureViewModel.Creatures == null) {
                    var CreatureRepository = new CreatureRepository();
                    CreatureViewModel.Creatures = CreatureRepository.getCreatures();
                }

                foreach(var Creature in CreatureViewModel.Creatures) {
                    if(Creature.SpeciesId == Convert.ToInt32(this.ControllerContext.RouteData.Values["species"])
                        && Creature.EvolutionStage == Convert.ToInt32(this.ControllerContext.RouteData.Values["stage"])
                        && Creature.Element.Id == Convert.ToInt32(this.ControllerContext.RouteData.Values["element"])) {
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