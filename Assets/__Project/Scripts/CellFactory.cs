using VContainer;
using VContainer.Unity;

public interface ICreatableCell
{
    public Cell Create();
}

public class CellFactory : ICreatableCell
{
    private readonly Cell _cellPrefab;
    private readonly IObjectResolver _resolver;

    public CellFactory(Cell cellPrefab, IObjectResolver resolver)
    {
        _cellPrefab = cellPrefab;
        _resolver = resolver;
    }

    public Cell Create()
    {
        var instance = _resolver.Instantiate(_cellPrefab);
        return instance.GetComponent<Cell>();
    }
}
