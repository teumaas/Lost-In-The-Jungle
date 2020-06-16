using System.Collections.Generic;
using System;

namespace Assets.Scripts.Serializer.Post
{
    [Serializable]
    public class Question
    {
        public List<Answer> answers;
        public string _id;
        public string question;
    }
}