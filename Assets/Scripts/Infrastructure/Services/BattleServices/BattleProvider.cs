using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleProvider : IBattleProvider
    {
        public Battle.Battle CurrentBattle { get; set; }
    }
}