﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineServices.Shared.EvaluationServices.TransfertObjects
{
    public class QuestionMultipleChoice : QuestionsTO
    {
        public bool IsMultipleChoice { get; set; }
        public Dictionary<int, string> Choices { get; set; }
    }
}
