using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Serializer.Put
{
    [Serializable]
    public class Game
    {
        public int level;
        public List<Answer> answers;

        public Game()
        {
            this.answers = new List<Answer>();
        }
    }
}