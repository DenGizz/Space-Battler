using Assets.Scripts.UI.BaseUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.NewUi.UiElements
{
    public class UiGrid : MonoBehaviour
    {
        [SerializeField] private Transform _contentContainer;
        [SerializeField] private GridLayoutGroup _contentGridLayoutGroup;

        public void SetContent(IEnumerable<MonoBehaviour> content)
        {
            foreach (var item in content)
                item.transform.SetParent(_contentContainer);
        }

        public void SetCellSize(Vector2 size)
        {
            _contentGridLayoutGroup.cellSize = size;
        }
    }
}
