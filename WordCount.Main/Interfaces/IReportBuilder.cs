using System.Collections.Generic;

namespace WordCount.Main.Interfaces
{
    public interface IReportBuilder
    {
        string Build(IDictionary<string, int> distinctWordtoCountMap);
    }
}