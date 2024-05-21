﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Factories.UI_Factories
{
    public interface IUiFactory
    {
        Ui CreateMainMenuUi();
        Ui CreateSandboxBattleUi();
    }
}
