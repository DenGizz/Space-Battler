using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class ScallableGridLayout : MonoBehaviour
{
    private GridLayoutGroup _grid;
    private RectTransform _rectTransform;

    private Vector2 _cellSize;
    private float _cellSizeRatio;

    private void Awake()
    {
        _grid = GetComponent<GridLayoutGroup>();
        _rectTransform = GetComponent<RectTransform>();
    }

    private void LateUpdate()
    {
        ResizeContent();
    }

    public void SetCellSize(Vector2 size)
    {
        _cellSize = size;
        _cellSizeRatio = _cellSize.y / _cellSize.x;
    }

    private void ResizeContent()
    {
        Vector2 size = _rectTransform.rect.size;

        float alaviablePlacesCount = size.x / _cellSize.x;
        float cellsCount = MathF.Floor(alaviablePlacesCount);
        float cellSizeX = MathF.Abs(size.x / cellsCount);
        float cellSizeY = cellSizeX * _cellSizeRatio;

        _grid.cellSize = new Vector2(cellSizeX, cellSizeY);
    }
}
