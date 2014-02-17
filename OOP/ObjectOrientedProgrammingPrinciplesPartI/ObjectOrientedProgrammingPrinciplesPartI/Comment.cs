using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ObjectOrientedProgrammingPrinciplesPartI
{
    public class Comment
    {
        private List<string> comments;

        public void AddComment(string comment)
        {
            this.comments.Add(comment);
        }

        public string[] GetComments()
        {
            return this.comments.ToArray();
        }
    }
}
