using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public abstract class Lottery
    {
        public abstract int getFirstNumberOn(string date);
    }
}
