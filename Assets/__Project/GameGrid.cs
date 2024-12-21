using DG.Tweening;
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
        GenerateGrid(levelConfig[levelCount - 1]);
    }

    public void GenerateGrid(LevelsConfig levelConfig)
    {
        ClearGrid();

        for (int i = 0; i < levelConfig.Properties.row; i++)
        {
            for (int j = 0; j < levelConfig.Properties.column; j++)
            {
                Cell cell = Instantiate(cellPrefab, transform).GetComponent<Cell>();

                Sprite sprite = levelConfig.SpriteData.spriteDatas[1].sprite;
                cell.Initialize(sprite, "sdfsdf", false);
                cells.Add(cell);
            }
        }
        Invoke(nameof(PlayBounceEffect), 0.5f);

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
