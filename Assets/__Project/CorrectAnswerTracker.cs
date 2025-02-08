public interface IAnswerTrakcer
{
    void TapToCell(Cell cell);
}
public class CorrectAnswerTracker : IAnswerTrakcer
{
    private IAnimatable _animateController;
    private IParticleService _particleService;
    private ISpawnerCells _cellsSpawner;
    private GameLogicLoop _gameLogicLoop;

    public CorrectAnswerTracker(IAnimatable animateController, ISpawnerCells cellsSpawner, GameLogicLoop gameLogicLoop, IParticleService particleService) 
    {
        _animateController = animateController;
        _gameLogicLoop = gameLogicLoop;
        _cellsSpawner = cellsSpawner;
        _particleService = particleService;
    }

    public void TapToCell(Cell cell)
    {
        if (cell.IsCorrect)
        {
            foreach (Cell item in _cellsSpawner.GetCells())
            {
                item.DisabledTap();
            }
            _particleService.Play(cell.transform.position);
            _gameLogicLoop.CorrectAnswer();
        } else
        {
            _animateController.WrongAnimPlay(cell.InnerSpriteTransform);
        }
    }
}