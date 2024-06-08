using Assets.Scripts.AI.AiStrategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.AI
{
    public interface ISpaceSipAi
    {
        ISelectTargetStrategy SelectTargetStrategy { get; set; }
        IUpdateTargetStrategy UpdateTargetStrategy { get; set; }
    }
}
