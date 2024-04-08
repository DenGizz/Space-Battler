using System.Collections;
using Assets.Scripts.Battles;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface IBattleSetupProvider 
    {
        BattleSetup BattleSetup { get; set; }
    }
}