using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameGrid : MonoBehaviour
{ 
    private GameSettings _gameSettings;
    private LevelCounter _levelCounter;
    private LevelProperties _levelConfig;

    private Dictionary<Vector2Int, Cell> _cells = new Dictionary<Vector2Int, Cell>();
    
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
        GenerateGrid(_levelConfig, cells);
    }

    private void GenerateGrid(LevelProperties levelConfig, List<Cell> cells)
    {
        int i = 0;
        for (int x = 0; x < levelConfig.Row; x++)
        {
            for (int y = 0; y < levelConfig.Column; y++)
            {
                Vector2Int positionInGrid = new Vector2Int(x, y);
                var cell = cells[i];
                _cells.Add(positionInGrid, cells[i]);
                cell.transform.SetParent(transform, false);
                cell.gameObject.transform.localPosition = GetWorldPosition(positionInGrid, levelConfig);
                i++;
            }
        }
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
        float cellSize = levelConfig.CellSize;
        int gridWidth =  levelConfig.Row; 
        int gridHeight = levelConfig.Column;
        
        float offsetX = -gridWidth * cellSize / 2 + cellSize / 2;
        float offsetY = gridHeight * cellSize / 2 - cellSize / 2;
        
        float x = positionOnGrid.x * cellSize + offsetX;
        float y = -positionOnGrid.y * cellSize + offsetY;
        return new Vector3(x, y, 0);
    }

}
