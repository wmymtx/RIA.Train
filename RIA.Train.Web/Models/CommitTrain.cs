using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RIA.Train.Web.Models
{
    public class CommitTrain
    {
        public int FK_ClassId { get; set; }

        public int FK_ContentId { get; set; }

        public int FK_GradeId { get; set; }
    }

    public class ListCommitTrain
    {
       public List<CommitTrain> CommitTrain { get; set; }
    }
}