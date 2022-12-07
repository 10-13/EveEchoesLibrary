using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EveEchoes.Mechanics.Stats.StatCollection
{
    public static class StatCollectionExtension
    {
        public static IStat GetStatSum(this IStatCollection collection,string StatType)
        {
            var typed = (from element in collection.Stats where element.SubType == StatType select element).ToList();
            if (typed.Count == 0)
                return null;
            var res = typed[0];
            for (int i = 0; i < typed.Count; i++)
                res.AddStat(typed[i]);
            return res;
        }
        public static IEnumerable<IStat> GetStats(this IStatCollection collection, string StatType)
        {
            return from element in collection.Stats where element.SubType == StatType select element;
        }
    }
}
