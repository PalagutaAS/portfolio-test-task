using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameGrid : MonoBehaviour
{ 
    private GameSettings _gameSettings;
    private LevelCounter _levelCounter;
    private LevelProperties _levelConfig;

    private Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();

    public Dictionary<Vector2Int, Cell> Cells { get => cells; }

    [Inject] 
    private void Constructor(LevelCounter levelCounter, GameSettings gameSettings)
    {
        _levelCounter = levelCounter;
        _gameSettings = gameSettings;
        _levelConfig = _gameSettings.GetLevelData(levelCounter.CurrentLevel);
    }

    public void GenerateGrid()
    {
        ClearGrid();
        Centering();
        //GenerageGrid(this.gameSettings.GetLevelSpriteData(levelSwithcer.CurrentLevel));
    }
    public void GenerateGridByLevelConfig(List<Cell> cells)
    {
        ClearGrid();
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
                this.cells.Add(positionInGrid, cells[i]);
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

    public void PlayBoundsEffect()
    {
        Invoke(nameof(PlayBounceEffect), 0.5f);
    }

    public void PlayBounceEffect()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(1.5f, 0.45f).SetEase(Ease.OutQuad))
            .Append(transform.DOScale(0.8f, 0.35f).SetEase(Ease.InOutQuad))
            .Append(transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce))
            .Play();
    }

    private void ClearGrid()
    {
        foreach (var item in cells)
        {
            Destroy(item.Value.gameObject);
        }
        cells.Clear();
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
