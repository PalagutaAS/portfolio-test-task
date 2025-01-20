using System.Collections.Generic;

public class CellsFillService
{
    private AnswerProvider _answerProvider;
    private LevelProperties _levelProperties;

    public CellsFillService(AnswerProvider answerProvider, GameSettings gameSettings, LevelCounter levels)
    {
        _answerProvider = answerProvider;
        _levelProperties = gameSettings.GetLevelData(levels.CurrentLevel);
    }

    public List<Cell> FillCells(List<Cell> cells)
    {
        int correntIndex = _answerProvider.CorrentIndex;
        List<int> incorrectIndexes = _answerProvider.IncorrentIndexes;

        for (int i = 0, j = -1; i < cells.Count; i++, j++)
        {
            int indexSprite = (i == 0) ? correntIndex : incorrectIndexes[j];
            bool isCorrect = (i == 0);

            cells[i].Constructor(_levelProperties.IconSprites[indexSprite].Sprite, isCorrect);
        }

        return cells;
    }
}
