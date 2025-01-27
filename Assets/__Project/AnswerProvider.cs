using System.Collections.Generic;
using UnityEngine;

public interface IAnswerProvider
{
    public int CorrentIndex { get; }
    public List<int> IncorrentIndexes { get; }
}

public class AnswerProvider : IAnswerProvider
{
    private readonly LevelCounter levelSwithcer;
    private readonly GameSettings gameSettings;
    private readonly FindTextPanel findTextPanel;

    private int correntIndex;
    private List<int> incorrentIndexes;
    private List<int> tempCorrentIndexes;

    public AnswerProvider(LevelCounter levelSwithcer, GameSettings gameSettings, FindTextPanel findTextPanel)
    {
        this.findTextPanel = findTextPanel;
        this.levelSwithcer = levelSwithcer;
        this.gameSettings = gameSettings;
        incorrentIndexes = new List<int>();
        tempCorrentIndexes = new List<int>();
    }

    public int CorrentIndex { get => correntIndex; }
    public List<int> IncorrentIndexes { get => incorrentIndexes; }

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

        findTextPanel.SetNameFindObject(isp[correntIndex].Name);
        
    }
    
    private void SelectInorrectIndexes()
    {
        incorrentIndexes.Clear();

        LevelProperties lp = gameSettings.GetLevelData(levelSwithcer.CurrentLevel);
        IconSprites[] isp = lp.IconSprites;
        int allowedCountIncorect = (lp.Row * lp.Column) - 1;
        List<int> possibleIndexes = new List<int>();
        for (int i = 0; i < isp.Length; i++)
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
    }
}
