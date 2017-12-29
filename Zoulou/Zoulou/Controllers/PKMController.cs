using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Zoulou.Models.PKM;

namespace Zoulou.Controllers {
    public class PKMController : BaseController {
        public ActionResult Index() {
            return View();
        }
        
        public ActionResult TypeChart() {
            //get all types
            TypeRepository allTypes = new TypeRepository(TypeRepository.GetAllTypes());

            //Transfert to string for the view
            var allTypesMatchups = new Dictionary<String, Dictionary<String, Double>>();

            foreach(var matchup in allTypes.GetTypeMatchups()) {
                //add key if doesn't exist
                if (!allTypesMatchups.ContainsKey(matchup.AttackingType)) {
                    allTypesMatchups.Add(matchup.AttackingType, new Dictionary<String, Double>());
                }

                //add matchup
                allTypesMatchups[matchup.AttackingType].Add(matchup.DefendingType, matchup.Modifier);
            }

            ViewBag.AllTypesMatchups = allTypesMatchups;

            return View("TypeChart");
        }
    }
}