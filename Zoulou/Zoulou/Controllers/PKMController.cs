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
            TypeChartViewModel typeChart = new TypeChartViewModel();

            //get all TypeMatchups
            TypeRepository allTypes = new TypeRepository(TypeRepository.GetAllTypes());
            typeChart.TypeMatchups = new Dictionary<String, Dictionary<String, Double>>();

            foreach (var matchup in allTypes.GetTypeMatchups()) {
                //add key if doesn't exist
                if (!typeChart.TypeMatchups.ContainsKey(matchup.AttackingType)) {
                    typeChart.TypeMatchups.Add(matchup.AttackingType, new Dictionary<String, Double>());
                }

                //add matchup
                typeChart.TypeMatchups[matchup.AttackingType].Add(matchup.DefendingType, matchup.Modifier);
            }

            //Get all types as String
            typeChart.allTypes = new List<string>();
            foreach (Models.PKM.Type type in TypeRepository.GetAllTypes()) {
                typeChart.allTypes.Add(type.Name);
            }

            ViewBag.TypeChart = typeChart;

            return View("TypeChart");
        }
    }
}