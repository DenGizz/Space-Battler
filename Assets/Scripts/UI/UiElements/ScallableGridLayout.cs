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

    private bool _isCellSizeOverriden;

    private Vector3 _defaultCellSize;
    private float _defaultCellSizeRatio;

    private void Awake()
    {
        _grid = GetComponent<GridLayoutGroup>();
        _rectTransform = GetComponent<RectTransform>();

        _defaultCellSize = _grid.cellSize;
        _defaultCellSizeRatio = _defaultCellSize.y / _defaultCellSize.x;
    }

    private void LateUpdate()
    {
        ResizeContent();
    }

    public void SetCellSize(Vector2 size)
    {
        _cellSize = size;
        _cellSizeRatio = _cellSize.y / _cellSize.x;

        _isCellSizeOverriden = true;
    }

    private void ResizeContent()
    {
        Vector2 size = _rectTransform.rect.size;

        Vector2 cellSize  = _isCellSizeOverriden ? _cellSize : _defaultCellSize;
        float cellSizeRato = _isCellSizeOverriden ? _cellSizeRatio : _defaultCellSizeRatio;

        float alaviablePlacesCount = size.x / cellSize.x;
        float cellsCount = MathF.Floor(alaviablePlacesCount);
        float cellSizeX = MathF.Abs(size.x / cellsCount);
        float cellSizeY = cellSizeX * cellSizeRato;

        _grid.cellSize = new Vector2(cellSizeX, cellSizeY);
    }
}
