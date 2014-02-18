using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Comment
    {
        private List<string> comments;

        public Comment()
        {
            this.comments = new List<string>();
        }

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public string[] GetAllComments()
        {
            return this.comments.ToArray();
        }

        public string GetAllCommentsToString()
        {
            string classLevel = "+++++";
           
            StringBuilder result = new StringBuilder();

            foreach (var item in this.GetAllComments())
            {
                result.Append(classLevel);
                result.Append("Comment : ");
                result.Append(item);
                result.Append("\n");
            }

            result.Append("\n");

            return result.ToString();
        }
    }
}
