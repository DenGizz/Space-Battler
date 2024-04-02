using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Infrastructure.Services
{
    public interface ISceneLoader
    {
        public void LoadSceneAsync(string sceneName, Action onSceneLoaded);
    }
}
