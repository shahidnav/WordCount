using System.Collections.Generic;
using System.Text;
using WordCount.Main.Interfaces;

namespace WordCount.Main.Services
{
    public class PlainTextReportBuilder : IReportBuilder
    {
        private const string ReportLineformat = "{0} - {1}";

        public string Build(IDictionary<string, int> distinctWordtoCountMap)
        {
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