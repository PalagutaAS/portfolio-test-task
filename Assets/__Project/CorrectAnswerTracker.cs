public class CorrectAnswerTracker : IAnswerTrakcer
{
    private IAnimatable _animateController;
    private ISpawnerCells _cellsSpawner;
    private GameLogicLoop _gameLogicLoop;
    public CorrectAnswerTracker(IAnimatable animateController, ISpawnerCells cellsSpawner, GameLogicLoop gameLogicLoop) 
    {
        _animateController = animateController;
        _gameLogicLoop = gameLogicLoop;
        _cellsSpawner = cellsSpawner;
    }

    public void TapToCell(Cell cell)
    {
        if (cell.IsCorrect)
        {
            foreach (Cell item in _cellsSpawner.GetCells())
            {
                item.DisabledTap();
            }
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