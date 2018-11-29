using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace jiratogithub
{
    public class JiraExporter
    {
        public IEnumerable<JiraCase> Export(string csvFileName)
        {
            var jiraCases = new List<JiraCase>();
            var lines = File.ReadAllLines($"{Environment.CurrentDirectory}/{csvFileName}", Encoding.Default).ToList();

            foreach (var row in lines.Skip(1).Take)
            {
                jiraCases.Add(new JiraCase());
            }

            return jiraCases;
        }
    }
}