using System.Collections.Generic;
using UnityEngine;

public class CellsSpawner
{
    private Cell _cellPrefab;
    private List<Cell> listCells = new List<Cell>();
    public CellsSpawner(Cell cellPrefab)
    {
        _cellPrefab = cellPrefab;
    }
    public List<Cell> GetCells() => listCells;
    public CellsSpawner CreateCells(int count)
    {
        for (int i = 0; i < count; i++)
        {
            listCells.Add(Object.Instantiate(_cellPrefab).GetComponent<Cell>());
        }

        return this;
    }
    
}
