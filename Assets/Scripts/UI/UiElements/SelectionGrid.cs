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
    public class SelectionGrid : MonoBehaviour
    {
        [SerializeField] private Transform _contentGrid;
        [SerializeField] private GridLayoutGroup _contentGridLayoutGroup;

        private readonly List<MonoBehaviour> _clickableContent = new List<MonoBehaviour>();

        public event Action<MonoBehaviour> OnSelected;

        public void SetContentViews(IEnumerable<MonoBehaviour> contentViews)
        {
            _clickableContent.Clear();

            foreach (var view in contentViews)
            {
                var clickable = view.GetComponent<ClickableView>() ?? 
                    throw new Exception("Content view must have ClickableView component");

                clickable.OnClicked += OnContentClick;
                view.GetComponent<RectTransform>().SetParent(_contentGrid);
            }
        }

        public void SetCellSize(Vector2 size)
        {
            _contentGridLayoutGroup.cellSize = size;
        }

        private void OnDestroy()
        {
            foreach (var content in _clickableContent)
                content.GetComponent<ClickableView>().OnClicked -= OnContentClick;
        }


        private void OnContentClick(MonoBehaviour content)
        {
            OnSelected?.Invoke(content);
        }
    }
}
