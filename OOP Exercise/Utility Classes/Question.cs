﻿using SQLite;

namespace OOP_Exercise
{
    public class Question
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string QuestionText { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public string AnswerE { get; set; }
        public byte CorrectAnswer { get; set; }
        public byte CategoryID { get; set; }
      
    }
}