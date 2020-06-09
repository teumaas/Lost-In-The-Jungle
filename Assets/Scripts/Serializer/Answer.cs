using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Serializer
{
    [Serializable]
    public class Answer
    {
        public string _id { get; set; }
        public string answer { get; set; }
    }
}
