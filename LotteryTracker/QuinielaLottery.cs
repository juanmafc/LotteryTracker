using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LotteryTracker
{
    public class QuinielaLottery : Lottery
    {
        public override int getFirstNumberOn(int day, int month, int year)
        {
            return 2000;
        }
    }
}
