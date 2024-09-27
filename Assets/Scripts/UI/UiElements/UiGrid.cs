using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI.UiElements
{
    public class UiGrid : MonoBehaviour
    {
        [SerializeField] private Transform _contentContainer;
        [SerializeField] private GridLayoutGroup _contentGridLayoutGroup;
        [SerializeField] private ScallableGridLayout _flexableContentGridLayout;

        private void Awake()
        {
            if (_contentContainer == null)
                throw new NullReferenceException();
            if (_contentGridLayoutGroup == null)
                throw new NullReferenceException();
        }

        public void SetContent(IEnumerable<MonoBehaviour> content)
        {
            foreach (var item in content)
                item.transform.SetParent(_contentContainer);
        }

        public void SetCellSize(Vector2 size)
        {
            _contentGridLayoutGroup.cellSize = size;
            _flexableContentGridLayout.SetCellSize(size);
        }
    }
}
