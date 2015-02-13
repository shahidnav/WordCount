using System.Collections.Generic;
using System.Linq;
using System.Text;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Services
{
    public class PlainTextReportBuilder : IReportBuilder
    {
        private const string ReportLineformat = "{0} - {1}";
        private const string EmptyMapMessage = "Nothing to report as no words were provided.";

        public string Build(IEnumerable<KeyValuePair<string, int>> distinctWordtoCountMap)
        {
            var wordtoCountMap = distinctWordtoCountMap as IList<KeyValuePair<string, int>> ?? distinctWordtoCountMap.ToList();
            if (distinctWordtoCountMap == null || !wordtoCountMap.Any())
            {
                return EmptyMapMessage;
            }

            var reportBuilder = new StringBuilder();
            foreach (var wordAndCount in wordtoCountMap)
            {
                reportBuilder.AppendFormat(ReportLineformat, wordAndCount.Key, wordAndCount.Value);
                reportBuilder.AppendLine();
            }

            return reportBuilder.ToString();
        }
    }
}