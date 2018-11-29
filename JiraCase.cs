using System.Linq;
using System.Text;

namespace jiratogithub
{
    public class JiraCase
    {
        public string Summary { get; set; }
        
        /*public string IssueKey { get; set; }
        public string IssueType { get; set; }
        public string IssueId { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Assignee { get; set; }
        public string Description { get; set; }
        public string Company { get; set; }
        public string Creator { get; set; }*/

        public string GetBody()
        {
            return "";
            /*
            var stringBuilder = new StringBuilder();
            var split = Description.Split("\r\n");
            
            var pieces = split.Skip(3).Take(split.Length - 3);

            foreach (var piece in pieces)
            {
                stringBuilder.Append(pieces);
            }

            return stringBuilder.ToString(); */
        }
    }
}