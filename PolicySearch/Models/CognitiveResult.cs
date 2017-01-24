using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PolicySearch.Models
{
    public class CognitiveResult
    {
        public string Query { get; set; }
        public IntentScore TopScoringIntent { get; set; }
        public List<TopicEntity> Entities { get; set; }
    }

    public class TopicEntity
    {
        public string Entity { get; set; }
        public string Type { get; set; }
        public int StartIndex { get; set; }
        public int EndIndex { get; set; }
        public float Score { get; set; }
    }

    public class IntentScore
    {
        public string Intent { get; set; }
        public float Score { get; set; }
    }
}