using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public abstract class Lottery
    {
        public abstract string getFirstNumberOn(string date);

        public abstract string getFirstNumberOn(string date, int numberOfDigits);
    }
}
