using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class GameGrid : MonoBehaviour
{ 
    private Cell cellPrefab;
    //private GameSettings gameSettings;
    //private LevelSwithcer levelSwithcer;
    private Dictionary<Vector2Int, Cell> cells = new Dictionary<Vector2Int, Cell>();

    public Dictionary<Vector2Int, Cell> Cells { get => cells; }

    [Inject] 
    private void Constructor(Cell cellPrefab)
    {
        //this.levelSwithcer = levelSwithcer;
        //this.gameSettings = gameSettings;
        this.cellPrefab = cellPrefab;
    }

    public void GenerateGrid()
    {
        ClearGrid();
        Centering();
        //GenerageGrid(this.gameSettings.GetLevelSpriteData(levelSwithcer.CurrentLevel));
        //Invoke(nameof(PlayBounceEffect), 0.5f);
    }
    public void GenerateGridByLevelConfig(LevelProperties levelConfig)
    {
        ClearGrid();
        Centering();
        GenerageGrid(levelConfig);
    }

    private void GenerageGrid(LevelProperties levelConfig)
    {
        for (int x = 0; x < levelConfig.Row; x++)
        {
            for (int y = 0; y < levelConfig.Column; y++)
            {
                //Cell cell = Instantiate(cellPrefab, transform).GetComponent<Cell>();
                //Sprite sprite = levelConfig.IconSprites[1].Sprite;
                //cell.Constructor(sprite, false);
                cells.Add(new Vector2Int(x, y), null);
            }
        }
    }

    public void Centering()
    {
        transform.position = Vector3.zero;
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

}
