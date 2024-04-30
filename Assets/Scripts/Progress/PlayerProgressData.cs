using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Progress
{
    public class PlayerProgressData
    {
        public int BattlesWon { get; set; }
        public int BattlesLost { get; set; }

        public PlayerProgressData()
        {
            BattlesWon = 0;
            BattlesLost = 0;
        }

        public PlayerProgressData(int battlesWon, int battlesLost)
        {
            BattlesWon = battlesWon;
            BattlesLost = battlesLost;
        }
    }
}
