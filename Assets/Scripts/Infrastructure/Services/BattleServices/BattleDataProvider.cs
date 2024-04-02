using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleDataProvider : IBattleDataProvider
    {
        public BattleData CurrentBattleData { get; set; }
    }
}