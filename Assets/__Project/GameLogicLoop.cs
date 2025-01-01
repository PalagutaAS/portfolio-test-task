using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameLogicLoop : MonoBehaviour
{
    private LevelSwithcer _levelSwithcer;

    private GameGrid _gameGrid;
    private GameSettings _settings;
    private LevelProperties _currentLevelData;
    private CellsSpawner _cellsSpawner;
    private CellsFillService _cellsFillService;

    [Inject]
    private void Constructor(LevelSwithcer levelSwithcer, AnswerProvider answerProvider, GameGrid gameGrid, GameSettings settings, CellsSpawner cellsSpawner, CellsFillService cellsFillService) 
    {
        _levelSwithcer = levelSwithcer;
        _gameGrid = gameGrid;
        _settings = settings;
        _cellsSpawner = cellsSpawner;
        _cellsFillService = cellsFillService;
    }

    private void Start()
    {
        _currentLevelData = _settings.GetLevelData(_levelSwithcer.CurrentLevel);
        int totalCells = _currentLevelData.Column * _currentLevelData.Row;
        _cellsSpawner.CreateCells(totalCells);
        _cellsFillService.FillCells(_cellsSpawner.GetCells());
        _gameGrid.GenerateGridByLevelConfig(_currentLevelData);
        foreach (var item in _gameGrid.Cells)
        {
            var cell = item.Value;
            Vector2Int positionInGrid = item.Key;
            cell.gameObject.transform.localPosition = GetWorldPosition(positionInGrid, _currentLevelData);
        }
        _gameGrid.PlayBounceEffect();
    }

    public void FoundCorrectAnswer()
    {
        _levelSwithcer.GoToNextLevel();
    }

    private Vector3 GetWorldPosition(Vector2Int gridPosition, LevelProperties levelConfig)
    {
        float cellSize = 1f;
        float halthCellSize = cellSize / 2f;
        float offsetX = ((levelConfig.Row / 2f) - halthCellSize) * cellSize;
        float offsetY = ((levelConfig.Column / 2f) - halthCellSize) * cellSize;

        return new Vector2((gridPosition.x * cellSize) - offsetX, -(gridPosition.y * cellSize) + offsetY);
    }

}
