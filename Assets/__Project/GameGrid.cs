using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameGrid : MonoBehaviour
{ 
    private GameSettings _gameSettings;
    private LevelCounter _levelCounter;
    private LevelProperties _levelConfig;

    private Dictionary<Vector2Int, Cell> _cells = new Dictionary<Vector2Int, Cell>();

    public Dictionary<Vector2Int, Cell> Cells { get => _cells; }

    [Inject] 
    private void Constructor(LevelCounter levelCounter, GameSettings gameSettings)
    {
        _levelCounter = levelCounter;
        _gameSettings = gameSettings;
    }

    private void BindLevelConfig()
    {
        _levelConfig = _gameSettings.GetLevelData(_levelCounter.CurrentLevel);
    }

    private void ResetGrid()
    {
        ClearGrid();
        BindLevelConfig();
    }

    public void GenerateGridByCells(List<Cell> cells)
    {
        ResetGrid();
        Centering();
        GenerageGrid(_levelConfig, cells);
    }

    private void GenerageGrid(LevelProperties levelConfig, List<Cell> cells)
    {
        int i = 0;
        for (int x = 0; x < levelConfig.Row; x++)
        {
            for (int y = 0; y < levelConfig.Column; y++)
            {
                Vector2Int positionInGrid = new Vector2Int(x, y);
                _cells.Add(positionInGrid, cells[i]);
                cells[i].transform.SetParent(transform, false);
                cells[i].gameObject.transform.localPosition = GetWorldPosition(positionInGrid, levelConfig);
                i++;
            }
        }
    }

    public void Centering()
    {
        transform.position = Vector3.zero;
    }

    private void ClearGrid()
    {
        foreach (var item in _cells)
        {
            Destroy(item.Value.gameObject);
        }
        _cells.Clear();
    }

    private Vector3 GetWorldPosition(Vector2Int positionOnGrid, LevelProperties levelConfig)
    {
        float cellSize = 1f;
        float halthCellSize = cellSize / 2f;
        float offsetX = ((levelConfig.Row / 2f) - halthCellSize) * cellSize;
        float offsetY = ((levelConfig.Column / 2f) - halthCellSize) * cellSize;

        return new Vector2((positionOnGrid.x * cellSize) - offsetX, -(positionOnGrid.y * cellSize) + offsetY);
    }

}
