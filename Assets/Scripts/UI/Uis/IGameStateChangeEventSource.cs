﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.UI.NewUi.Uis
{
    public interface IGameStateChangeEventSource
    {
        public event Action<GameStateChangeEvent> OnGameStateChangeEvent;
    }
}