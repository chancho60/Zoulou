using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Zoulou.Models.PKM;

namespace Zoulou.Controllers {
    public class PKMController : BaseController {
        public ActionResult Index() {
            return View();
        }

        public ActionResult TypeChart(TypeChartViewModel typeChart) {

            TypeRepository allTypes = new TypeRepository();
            //var matchups = allTypes.GetTypeMatchups();  

            //get all TypeMatchups
            typeChart.TypeMatchups = new Dictionary<String, Dictionary<String, Double>>();

            foreach (var matchup in allTypes.GetTypeMatchups()) {
                //add key if doesn't exist
                if ( !typeChart.TypeMatchups.ContainsKey( Enum.GetName(typeof(Types), matchup.AttackingTypeId) ) ) {
                    typeChart.TypeMatchups.Add(
                        //position (Attk Type Name)
                        Enum.GetName(typeof(Types), matchup.AttackingTypeId),
                        //Value (Dict<Def Type Name, Modifer>)
                        new Dictionary<String, Double>() { { Enum.GetName(typeof(Types), matchup.AttackingTypeId), matchup.Modifier } }
                    );
                }
            }

            //Get all types as String
            typeChart.allTypes = new List<String>( Enum.GetNames(typeof(Types)) );

            ViewBag.TypeChart = typeChart;

            return View("TypeChart");
        }
    }
}