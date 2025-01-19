using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace VoiceSwnikTextBot1.Services
{
    public class Processor :  IProcessor
    {
        public int NumOfSymbols(string message)
        {
            return message.Length; 
        }

        public int SumOfDigits(string message)
        {
            int sum = 0;
            string[] s = message.Split(' ');

            for(int i = 0; i < s.Length; i++)
            {
                sum += Convert.ToInt32(s[i]);
            }
            return sum;
        }
    }
}
