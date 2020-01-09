using OnlineServices.Shared.DataAccessHelpers;
using System;
using System.Collections.Generic;

namespace OnlineServices.Shared.EvaluationServices.TransfertObjects
{
    public class FormTO : IEntity<int>
    {
        public int Id { get; set; }
        public int SessionID { get; set; }
        public Dictionary<int, QuestionsTO> Questions { get; set; }
    }
}