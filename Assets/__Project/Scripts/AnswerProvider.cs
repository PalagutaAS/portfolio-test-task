using System.Collections.Generic;
using UnityEngine;

public interface IAnswerProvider
{
    public int CorrentIndex { get; }
    public List<int> IncorrentIndexes { get; }
    public void CalculateVariants();
}

public class AnswerProvider : IAnswerProvider
{
    private readonly LevelCounter _levelSwithcer;
    private readonly GameSettings _gameSettings;
    private readonly FindTextPanel _findTextPanel;

    private int _correntIndex;
    private List<int> _incorrentIndexes;
    private List<int> _tempCorrentIndexes;

    public AnswerProvider(LevelCounter levelSwithcer, GameSettings gameSettings, FindTextPanel findTextPanel)
    {
        _findTextPanel = findTextPanel;
        _levelSwithcer = levelSwithcer;
        _gameSettings = gameSettings;
        _incorrentIndexes = new List<int>();
        _tempCorrentIndexes = new List<int>();
    }

    public int CorrentIndex { get => _correntIndex; }
    public List<int> IncorrentIndexes { get => _incorrentIndexes; }

    public void CalculateVariants()
    {
        SelectCorrectIndex();
        SelectInorrectIndexes();
    }

    private void SelectCorrectIndex()
    {
        LevelProperties lp = _gameSettings.GetLevelData(_levelSwithcer.CurrentLevel);
        IconSprites[] isp = lp.IconSprites;

        bool notUniqueIndex = _tempCorrentIndexes.Count < isp.Length;

        int newIndex;
        do
        {
            newIndex = Random.Range(0, isp.Length);
        }
        while (_tempCorrentIndexes.Contains(newIndex) && notUniqueIndex);

        _correntIndex = newIndex;
        _tempCorrentIndexes.Add(_correntIndex);

        _findTextPanel.SetNameFindObject(isp[_correntIndex].Name);
        
    }
    
    private void SelectInorrectIndexes()
    {
        _incorrentIndexes.Clear();

        LevelProperties lp = _gameSettings.GetLevelData(_levelSwithcer.CurrentLevel);
        IconSprites[] isp = lp.IconSprites;
        int allowedCountIncorect = (lp.Row * lp.Column) - 1;
        List<int> possibleIndexes = new List<int>();
        for (int i = 0; i < isp.Length; i++)
        {
            possibleIndexes.Add(i);
        }
        possibleIndexes.Remove(_correntIndex);

        int newIndex;
        while (allowedCountIncorect < possibleIndexes.Count)
        {
            newIndex = Random.Range(0, possibleIndexes.Count);
            possibleIndexes.RemoveAt(newIndex);
        }

        _incorrentIndexes = possibleIndexes;
    }
}
