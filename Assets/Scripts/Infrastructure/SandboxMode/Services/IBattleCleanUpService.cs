﻿using Assets.Scripts.Battles.BattleRun;

namespace Assets.Scripts.Infrastructure.SandboxMode.Services
{
    public interface IBattleCleanUpService
    {
        void CleanUpBattle(BattleRunner battleRunner);
    }
}