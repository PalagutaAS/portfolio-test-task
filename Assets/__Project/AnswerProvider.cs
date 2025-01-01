using System.Collections.Generic;
using UnityEngine;

public class AnswerProvider
{
    private readonly LevelSwithcer levelSwithcer;
    private readonly GameSettings gameSettings;

    private int correntIndex;
    private List<int> incorrentIndexes;
    private List<int> tempCorrentIndexes;
    public AnswerProvider(LevelSwithcer levelSwithcer, GameSettings gameSettings)
    {
        this.levelSwithcer = levelSwithcer;
        this.gameSettings = gameSettings;
        incorrentIndexes = new List<int>();
        tempCorrentIndexes = new List<int>();
        CalculateVariants();
    }

    public void CalculateVariants()
    {
        SelectCorrectIndex();
        SelectInorrectIndexes();
    }

    private void SelectCorrectIndex()
    {
        LevelProperties lp = gameSettings.GetLevelData(levelSwithcer.CurrentLevel);
        IconSprites[] isp = lp.IconSprites;

        bool notUniqueIndex = tempCorrentIndexes.Count < isp.Length;

        int newIndex;
        do
        {
            newIndex = Random.Range(0, isp.Length);
        }
        while (tempCorrentIndexes.Contains(newIndex) && notUniqueIndex);

        correntIndex = newIndex;
        tempCorrentIndexes.Add(correntIndex);
        Debug.Log($"Выбранный индекс: {correntIndex}");
    }
    
    private void SelectInorrectIndexes()
    {
        LevelProperties lp = gameSettings.GetLevelData(levelSwithcer.CurrentLevel);
        IconSprites[] isp = lp.IconSprites;
        int allowedCountIncorect = (lp.Row * lp.Column) - 1;
        List<int> possibleIndexes = new List<int>();
        for (int i = isp.Length; i >= 0; i--)
        {
            possibleIndexes.Add(i);
        }
        possibleIndexes.Remove(correntIndex);

        int newIndex;
        do
        {
            newIndex = Random.Range(0, possibleIndexes.Count);
            possibleIndexes.RemoveAt(newIndex);
        }
        while (allowedCountIncorect < possibleIndexes.Count);
        incorrentIndexes = possibleIndexes;

        foreach (var item in incorrentIndexes)
        {
            Debug.Log($"Неправельный индекс: {item}");

        }
    }
}
