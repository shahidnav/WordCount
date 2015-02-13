using System.Collections.Generic;

namespace WordCount.Main.Interfaces
{
    public interface IReportBuilder
    {
        string Build(IEnumerable<KeyValuePair<string, int>> distinctWordtoCountMap);
    }
}