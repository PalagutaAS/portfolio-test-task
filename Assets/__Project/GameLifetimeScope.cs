using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Cell prefab;
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private GameGrid gameGrid;
    [SerializeField] private GameLogicLoop gameLogicLoop;
    [SerializeField] private FindTextPanel findTextPanel;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<IAnswerTrakcer, CorrectAnswerTracker>(Lifetime.Transient);
        builder.Register<LevelCounter>(Lifetime.Singleton);
        builder.Register<AnswerProvider>(Lifetime.Scoped);
        builder.Register<AnimateController>(Lifetime.Transient);
        builder.Register<CellsSpawner>(Lifetime.Scoped);
        builder.Register<CellsFillService>(Lifetime.Scoped);
        builder.Register<CellFactory>(Lifetime.Scoped);
        builder.RegisterInstance(gameLogicLoop);
        builder.RegisterInstance(gameSettings);
        builder.RegisterInstance(gameGrid);
        builder.RegisterInstance(prefab);
        builder.RegisterInstance(findTextPanel);

    }
}
