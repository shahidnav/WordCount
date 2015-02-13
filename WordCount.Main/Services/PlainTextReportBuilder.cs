using System.Collections.Generic;
using System.Text;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Services
{
    public class PlainTextReportBuilder : IReportBuilder
    {
        private const string ReportLineformat = "{0} - {1}";
        private const string EmptyMapMessage = "Nothing to report as no words were provided.";

        public string Build(IDictionary<string, int> distinctWordtoCountMap)
        {
            if (distinctWordtoCountMap == null || distinctWordtoCountMap.Count == 0)
            {
                return EmptyMapMessage;
            }

            var reportBuilder = new StringBuilder();
            foreach (var wordAndCount in distinctWordtoCountMap)
            {
                reportBuilder.AppendFormat(ReportLineformat, wordAndCount.Key, wordAndCount.Value);
                reportBuilder.AppendLine();
            }

            return reportBuilder.ToString();
        }
    }
}