using System;

using CsvHelper.Configuration.Attributes;

namespace jiratogithub
{
    public class JiraCase
    {
        [Name("Summary")]
        public string Summary { get; set; }

        [Name("Description")]
        public string Description { get; set; }

        [Name("Issue key")]
        public string IssueKey { get; set; }

        [Name("Issue id")]
        public int IssueId { get; set; }

        [Name("Issue Type")]
        public string IssueType { get; set; }

        [Name("Status")]
        public string Status { get; set; }

        [Name("Project key")]
        public string ProjectKey { get; set; }

        [Name("Project name")]
        public string ProjectName { get; set; }

        [Name("Project type")]
        public string ProjectType { get; set; }

        [Name("Priority")]
        public string Priority { get; set; }

        [Name("Resolution")]
        public string Resolution { get; set; }

        [Name("Assignee")]
        public string Assignee { get; set; }

        [Name("Reporter")]
        public string Reporter { get; set; }

        [Name("Created")]
        public DateTime Created { get; set; }
    }
}