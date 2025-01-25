using System.Collections.Generic;
using UnityEngine;
using VContainer;



public class GameLogicLoop : MonoBehaviour
{
    private LevelCounter _levelCounter;

    private GameGrid _gameGrid;
    private GameSettings _settings;
    private LevelProperties _currentLevelData;
    private CellsSpawner _cellsSpawner;
    private CellsFillService _cellsFillService;
    private AnimateController _animateController;

    [Inject]
    private void Constructor(LevelCounter levelSwithcer, AnswerProvider answerProvider, GameGrid gameGrid, GameSettings settings, CellsSpawner cellsSpawner, CellsFillService cellsFillService, AnimateController animateController) 
    {
        _levelCounter = levelSwithcer;
        _gameGrid = gameGrid;
        _settings = settings;
        _cellsSpawner = cellsSpawner;
        _cellsFillService = cellsFillService;
        _animateController = animateController;
    }

    private void Start()
    {
        _currentLevelData = _settings.GetLevelData(_levelCounter.CurrentLevel);
        int totalCells = _currentLevelData.Column * _currentLevelData.Row;
        _cellsSpawner.CreateCells(totalCells);
        List<Cell> fillCells = _cellsFillService.FillCells(_cellsSpawner.GetCells()).Shuffle();
        _gameGrid.GenerateGridByCells(fillCells);
        _animateController.BounceAnimPlay(_gameGrid.transform, 0.3f);
    }

    public void FoundCorrectAnswer()
    {
        _levelCounter.GoToNextLevel();
    }

}
