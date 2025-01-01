using System;
using System.Collections.Generic;
using UnityEngine;

public class CellsFillService
{
    private AnswerProvider _answerProvider;

    public CellsFillService(AnswerProvider answerProvider)
    {
        _answerProvider = answerProvider;
    }

    public List<Cell> FillCells(List<Cell> cells)
    {
        var fillCells = new List<Cell>();
        foreach (var cell in cells)
        {
            //Sprite sprite = levelConfig.IconSprites[1].Sprite;
            //cell.Constructor(sprite, false);
            //cell
        }
        return fillCells;
    }
}
