using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameLogicLoop : MonoBehaviour
{
    private LevelCounter _levelCounter;
    private GameGrid _gameGrid;
    private GameSettings _settings;
    private LevelProperties _currentLevelData;
    private ISpawnerCells _cellsSpawner;
    private ICellFillService _cellsFillService;
    private IAnimatable _animateController;
    

    [Inject]
    private void Constructor(LevelCounter levelSwithcer, GameGrid gameGrid, GameSettings settings, ISpawnerCells cellsSpawner, ICellFillService cellsFillService, IAnimatable animateController) 
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
        StartGame();
    }

    public void StartGame()
    {
        Restart();
        _animateController.BounceAnimPlay(_gameGrid.transform, 0.3f);
    }

    private void Restart()
    {
        _currentLevelData = _settings.GetLevelData(_levelCounter.CurrentLevel);
        int totalCells = _currentLevelData.Column * _currentLevelData.Row;
        _cellsSpawner.CreateCells(totalCells);
        List<Cell> fillCells = _cellsFillService.FillCells(_cellsSpawner.GetCells()).Shuffle();
        _gameGrid.GenerateGridByCells(fillCells);
    }

    public void CorrectAnswer()
    {
        if (!_levelCounter.IsLastLevel) 
        {
            StartCoroutine(DoToNextLevel());
        } else
        {
            StartCoroutine(DoToFirstLevel());
        }

    }

    private IEnumerator DoToNextLevel()
    {
        float delay = 1f;
        float elapsedTime = 0f;
        while(elapsedTime < delay)
        {   
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _levelCounter.GoToNextLevel();
        Restart();
    }

    private IEnumerator DoToFirstLevel()
    {
        float delay = 1f;
        float elapsedTime = 0f;
        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;
        _levelCounter.Restart();

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        StartGame();
    }
}
