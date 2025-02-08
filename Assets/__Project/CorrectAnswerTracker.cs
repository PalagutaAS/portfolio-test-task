using UnityEngine;

public class CorrectAnswerTracker : IAnswerTrakcer
{
    private IAnimatable _animateController;
    private ISpawnerCells _cellsSpawner;
    private GameLogicLoop _gameLogicLoop;
    private ParticleSystem _particle;
    public CorrectAnswerTracker(IAnimatable animateController, ISpawnerCells cellsSpawner, GameLogicLoop gameLogicLoop, ParticleSystem particle) 
    {
        _animateController = animateController;
        _gameLogicLoop = gameLogicLoop;
        _cellsSpawner = cellsSpawner;
        _particle = particle;

    }

    public void TapToCell(Cell cell)
    {
        if (cell.IsCorrect)
        {
            foreach (Cell item in _cellsSpawner.GetCells())
            {
                item.DisabledTap();
            }
            _particle.transform.position = cell.transform.position;
            _particle.Play();
            _gameLogicLoop.CorrectAnswer();
        } else
        {
            _animateController.WrongAnimPlay(cell.InnerSpriteTransform);
        }
    }
}

internal interface IAnswerTrakcer
{
    void TapToCell(Cell cell);
}