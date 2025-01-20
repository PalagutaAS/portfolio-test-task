using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Cell prefab;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameGrid gameGrid;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<LevelCounter>(Lifetime.Singleton);
        builder.Register<AnswerProvider>(Lifetime.Scoped);
        builder.Register<CellsSpawner>(Lifetime.Scoped);
        builder.Register<CellsFillService>(Lifetime.Scoped);
        builder.RegisterInstance(gameSettings);
        builder.RegisterInstance(gameGrid);
        builder.RegisterComponent(prefab);
    }
}
