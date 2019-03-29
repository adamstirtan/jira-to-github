using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using CsvHelper;

namespace jiratogithub
{
    public class JiraExporter
    {
        private readonly List<string> _fileNames;

        public JiraExporter(IEnumerable<string> fileNames)
        {
            _fileNames = fileNames.ToList();
        }

        public IEnumerable<JiraCase> Export()
        {
            var jiraCases = new List<JiraCase>();

            foreach (var fileName in _fileNames)
            {
                using (var reader = new StreamReader($"{Environment.CurrentDirectory}/{fileName}"))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToLower();

                    var cases = csv.GetRecords<JiraCase>();

                    jiraCases.AddRange(cases);
                }
            }

            return jiraCases;
        }
    }
}