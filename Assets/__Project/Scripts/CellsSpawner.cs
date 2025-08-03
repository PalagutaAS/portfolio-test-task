using System.Collections.Generic;

public interface ISpawnerCells 
{
    public List<Cell> GetCells();
    public CellsSpawner CreateCells(int count);
}

public class CellsSpawner : ISpawnerCells
{
    private readonly ICreatableCell _factory;
    private List<Cell> _listCells = new();
    public CellsSpawner(ICreatableCell factory)
    {
        _factory = factory;
    }
    public List<Cell> GetCells() => _listCells;
    public CellsSpawner CreateCells(int count)
    {
        _listCells.Clear();
        for (int i = 0; i < count; i++)
        {
            _listCells.Add(_factory.Create());
        }

        return this;
    }
    
}
