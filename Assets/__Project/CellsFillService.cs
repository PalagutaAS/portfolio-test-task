using System.Collections.Generic;

public interface ICellFillService
{
    public List<Cell> FillCells(List<Cell> cells);
}

public class CellsFillService : ICellFillService
{
    private IAnswerProvider _answerProvider;
    private LevelProperties _levelProperties;

    public CellsFillService(IAnswerProvider answerProvider, GameSettings gameSettings, LevelCounter levels)
    {
        _answerProvider = answerProvider;
        _levelProperties = gameSettings.GetLevelData(levels.CurrentLevel);
    }

    public List<Cell> FillCells(List<Cell> cells)
    {
        _answerProvider.CalculateVariants();
        for (int i = 0, j = -1; i < cells.Count; i++, j++)
        {
            int indexSprite = (i == 0) ? _answerProvider.CorrentIndex : _answerProvider.IncorrentIndexes[j];
            bool isCorrect = (i == 0);

            cells[i].Constructor(_levelProperties.IconSprites[indexSprite].Sprite, isCorrect);
        }

        return cells;
    }
}
