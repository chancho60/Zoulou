using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Zoulou.Models.PKM;
using Zoulou.ViewModels.PKM;
using Zoulou.Repositories.PKM;

namespace Zoulou.Controllers {
    public class PKMController : BaseController {
        public ActionResult Index() {
            return View();
        }

        public ActionResult Pokemon(PokemonSearchViewModel PokemonSearch) {
            if (PokemonSearch.AllPokemon == null) {
                PokemonRepository repository = new PokemonRepository();
                PokemonSearch.AllPokemon = new List<PokemonViewModel>();

                foreach(var pokemon in repository.GetAllPokemon()) {
                    PokemonSearch.AllPokemon.Add(new PokemonViewModel() { name = pokemon.name });
                }
            }

            /*var SortElements = CreatureViewModel.Elements.Where(E => E.Value == true).Select(E => E.Key).ToArray();
            var SortRoles = CreatureViewModel.Roles.Where(R => R.Value == true).Select(R => R.Key).ToArray();

            CreatureViewModel.CreaturesFiltered = CreatureViewModel.Creatures
                .Where(C => C.EvolutionId == 0)
                .Where(C => SortElements.Contains(C.Element.Id.ToString()))
                .Where(C => SortRoles.Contains(C.Role.Id.ToString()))
                .ToList();

            return View(CreatureViewModel);*/
            return null;
        }

        public ActionResult TypeChart(TypeChartViewModel typeChart) {
            if (typeChart.TypeMatchups == null) {
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
            }

            if (typeChart.allTypes == null) {
                //Get all types as String
                typeChart.allTypes = new List<string>(Enum.GetNames(typeof(Types)));
            }

            ViewBag.TypeChart = typeChart;
            return View("TypeChart");
        }
    }
}