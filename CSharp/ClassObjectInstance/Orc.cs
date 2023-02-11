using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassObjectInstance
{
    internal class Orc
    {
        public string Name;
        public int Age;
        public float cm;
        public float kg;
        public string gender;

        public void SayMyName()
        {
            Console.WriteLine($"\n이름: {Name}");
        }
        public void SayMyInfo()
        {
            Console.WriteLine($"나이: {Age}");
            Console.WriteLine($"키: {cm}");
            Console.WriteLine($"몸무게: {kg}");
            Console.WriteLine($"성별: {gender}\n");
        }
    }
}
