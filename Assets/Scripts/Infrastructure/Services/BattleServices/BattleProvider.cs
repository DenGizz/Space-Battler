using Assets.Scripts.Battles;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public class BattleProvider : IBattleProvider
    {
        public Battle CurrentBattle { get; set; }
    }
}