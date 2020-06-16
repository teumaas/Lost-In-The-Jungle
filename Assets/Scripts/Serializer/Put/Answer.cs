using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Serializer.Put
{
    [Serializable]
    public class Answer
    {
        public string question;
        public string answer;
        
        public Answer(string question, string answer)
        {
            this.question = question;
            this.answer = answer;
        }
    }
}