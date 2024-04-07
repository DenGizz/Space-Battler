using System.Collections;
using Assets.Scripts.Battle;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public class BattleSetupProvider : IBattleSetupProvider
    {
        public BattleSetup BattleSetup { get; set; }
    }
}