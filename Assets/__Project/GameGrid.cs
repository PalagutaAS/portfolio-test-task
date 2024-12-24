using DG.Tweening;
using System;
using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
    public GameObject cellPrefab;
    public LevelsConfig[] levelConfig;

    private List<Cell> cells = new List<Cell>();
    private int levelCount = 1;

    private void Awake()
    {
        GenerateGridByLevelConfig(levelConfig[levelCount - 1]);
        Invoke(nameof(PlayBounceEffect), 0.5f);
    }

    public void GenerateGridByLevelConfig(LevelsConfig levelConfig)
    {
        ClearGrid();
        Centering();
        GenerageGrid(levelConfig);

    }

    private void GenerageGrid(LevelsConfig levelConfig)
    {
        for (int x = 0; x < levelConfig.Properties.row; x++)
        {
            for (int y = 0; y < levelConfig.Properties.column; y++)
            {
                Cell cell = Instantiate(cellPrefab, transform).GetComponent<Cell>();
                cell.gameObject.transform.localPosition = GetWorldPosition(new Vector2Int(x, y), levelConfig);
                Sprite sprite = levelConfig.SpriteData.spriteDatas[1].sprite;
                cell.Initialize(sprite, "sdfsdf", false);
                cells.Add(cell);
            }
        }
    }

    private Vector3 GetWorldPosition(Vector2Int gridPosition, LevelsConfig levelConfig)
    {
        float cellSize = 1f;
        float halthCellSize = cellSize / 2f;
        float offsetX = ((levelConfig.Properties.row / 2f) - halthCellSize) * cellSize;
        float offsetY = ((levelConfig.Properties.column / 2f) - halthCellSize) * cellSize;

        return new Vector2((gridPosition.x * cellSize) - offsetX, -(gridPosition.y * cellSize) + offsetY);
    }

    public void Centering()
    {
        transform.position = new Vector3(0, 0, -10);
    }
    public void PlayBounceEffect()
    {
        DOTween.Sequence()
            .Append(transform.DOScale(1.5f, 0.3f).SetEase(Ease.OutQuad))
            .Append(transform.DOScale(0.8f, 0.2f).SetEase(Ease.InOutQuad))
            .Append(transform.DOScale(1f, 0.2f).SetEase(Ease.OutBounce))
            .Play();
    }

    private void ClearGrid()
    {
        foreach (var cell in cells)
        {
            Destroy(cell.gameObject);
        }
        cells.Clear();
    }
}
