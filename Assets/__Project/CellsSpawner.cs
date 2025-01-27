using System.Collections.Generic;

public class CellsSpawner
{
    private CellFactory _factory;
    private List<Cell> listCells = new List<Cell>();
    public CellsSpawner(CellFactory factory)
    {
        _factory = factory;
    }
    public List<Cell> GetCells() => listCells;
    public CellsSpawner CreateCells(int count)
    {
        listCells.Clear();
        for (int i = 0; i < count; i++)
        {
            listCells.Add(_factory.Create());
        }

        return this;
    }
    
}
