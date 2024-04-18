using System.Collections;
using Assets.Scripts.Battles;
using UnityEngine;

namespace Assets.Scripts.Infrastructure.Services.BattleServices
{
    public interface IBattleProvider 
    {
        Battle CurrentBattle { get; set; }
    }
}