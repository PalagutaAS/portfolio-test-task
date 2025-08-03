using System.Collections.Generic;

public interface ICellFillService
{
    public List<Cell> FillCells(List<Cell> cells);
}

public class CellsFillService : ICellFillService
{
    private IAnswerProvider _answerProvider;
    private GameSettings _gameSettings;
    private LevelCounter _levelCounter;

    public CellsFillService(IAnswerProvider answerProvider, GameSettings gameSettings, LevelCounter levels)
    {
        _answerProvider = answerProvider;
        _levelCounter = levels;
        _gameSettings = gameSettings;
    }

    public List<Cell> FillCells(List<Cell> cells)
    {
        LevelProperties levelProperties = _gameSettings.GetLevelData(_levelCounter.CurrentLevel);
        _answerProvider.CalculateVariants();
        for (int i = 0, j = -1; i < cells.Count; i++, j++)
        {
            int indexSprite = (i == 0) ? _answerProvider.CorrentIndex : _answerProvider.IncorrentIndexes[j];
            bool isCorrect = (i == 0);

            cells[i].Constructor(levelProperties.IconSprites[indexSprite].Sprite, isCorrect, levelProperties.CellSize);
        }

        return cells;
    }
}
