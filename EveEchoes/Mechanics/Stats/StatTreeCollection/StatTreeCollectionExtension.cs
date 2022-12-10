using EveEchoes.Mechanics.Stats.StatCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveEchoes.Mechanics.Stats.StatTreeCollection
{
    public static class StatTreeCollectionExtension
    {
        public static IEnumerable<IStat> GetStatsDeep(this IStatTreeCollection collection,string Type)
        {
            List<IStat> res = new List<IStat>();
            res.AddRange(collection.GetStats(Type));
            foreach(IStatCollection stat in collection.Childs)
            {
                if (stat is IStatTreeCollection)
                    res.AddRange((stat as IStatTreeCollection).GetStatsDeep(Type));
                else
                    res.AddRange(stat.GetStats(Type));
            }
            return res;
        }
        public static IStat GetStatsSumDeep(this IStatTreeCollection collection,string Type)
        {
            var typed = collection.GetStatsDeep(Type).ToList();
            if (typed.Count == 0)
                return null;
            var res = typed[0];
            for (int i = 0; i < typed.Count; i++)
                res.AddStat(typed[i]);
            return res;
        }
    }
}
