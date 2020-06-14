using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Serializer.Post
{
    [Serializable]
    public class Level
    {
        public int pin;
        public List<Question> questions;
        public string lastPlayed;
        public string playID;
        public int level;

        public static Level CreateFromJSON(string jsonString)
        {
            return JsonUtility.FromJson<Level>(jsonString);
        }
    }
}

