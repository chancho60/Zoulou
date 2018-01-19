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
            TypeMatchupRepository repository = new TypeMatchupRepository();

            //get all TypeMatchups
            typeChart.TypeMatchups = new Dictionary<String, Dictionary<String, Double>>();

            foreach (var matchup in repository.GetTypeMatchups()) {
                //declare var
                var atkType = Enum.GetName(typeof(Types), matchup.AttackingType);
                var defType = Enum.GetName(typeof(Types), matchup.DefendingType);

                //add key if doesn't exist
                if (!typeChart.TypeMatchups.ContainsKey(atkType)) {
                    typeChart.TypeMatchups.Add(atkType, new Dictionary<String, Double>());
                }

                //add matchup
                typeChart.TypeMatchups[atkType].Add(defType, matchup.Modifier);
            }

            //Get all types as String
            typeChart.allTypes = new List<string>( Enum.GetNames(typeof(Types)) );

            ViewBag.TypeChart = typeChart;

            return View("TypeChart");
        }
    }
}