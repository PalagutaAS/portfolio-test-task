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
    [SerializeField] private ParticleSystem particle;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<LevelCounter>(Lifetime.Singleton);
        builder.Register<IAnswerTrakcer, CorrectAnswerTracker>(Lifetime.Transient);
        builder.Register<IAnswerProvider, AnswerProvider>(Lifetime.Scoped);
        builder.Register<IAnimatable, AnimateController>(Lifetime.Transient);
        builder.Register<ISpawnerCells, CellsSpawner>(Lifetime.Scoped);
        builder.Register<ICellFillService, CellsFillService>(Lifetime.Scoped);
        builder.Register<ICreatableCell, CellFactory>(Lifetime.Scoped);
        builder.RegisterInstance(particle);
        builder.RegisterInstance(gameLogicLoop);
        builder.RegisterInstance(gameSettings);
        builder.RegisterInstance(gameGrid);
        builder.RegisterInstance(prefab);
        builder.RegisterInstance(findTextPanel);

    }
}
