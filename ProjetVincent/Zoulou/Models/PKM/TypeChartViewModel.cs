using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zoulou.Models.PKM
{
    public class TypeChartViewModel
    {
        public List<String> allTypes { get; set; }

        //Data for type chart
        //Dictionary< AttackingType , Dictionary< DefendingType , Double>>
        public Dictionary<String, Dictionary<String, Double>> TypeMatchups { get; set; }
    }
}