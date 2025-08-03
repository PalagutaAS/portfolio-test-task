using VContainer;
using VContainer.Unity;
using UnityEngine;

public class GameLifetimeScope : LifetimeScope
{
    [SerializeField] private Cell _prefab;
    [SerializeField] private GameSettings _gameSettings;
    [SerializeField] private GameGrid _gameGrid;
    [SerializeField] private GameLogicLoop _gameLogicLoop;
    [SerializeField] private FindTextPanel _findTextPanel;
    [SerializeField] private ParticleSystem _prefabParticle;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.Register<LevelCounter>(Lifetime.Singleton);
        builder.Register<IAnswerTrakcer, CorrectAnswerTracker>(Lifetime.Transient);
        builder.Register<IAnswerProvider, AnswerProvider>(Lifetime.Scoped);
        builder.Register<IAnimatable, AnimateController>(Lifetime.Transient);
        builder.Register<ISpawnerCells, CellsSpawner>(Lifetime.Scoped);
        builder.Register<ICellFillService, CellsFillService>(Lifetime.Scoped);
        builder.Register<ICreatableCell, CellFactory>(Lifetime.Scoped);
        builder.Register<IParticleService, ParticleService>(Lifetime.Scoped);
        builder.RegisterInstance(_prefabParticle);
        builder.RegisterInstance(_gameLogicLoop);
        builder.RegisterInstance(_gameSettings);
        builder.RegisterInstance(_gameGrid);
        builder.RegisterInstance(_prefab);
        builder.RegisterInstance(_findTextPanel);

    }
}
