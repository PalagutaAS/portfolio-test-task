public class CorrectAnswerTracker : IAnswerTrakcer
{
    private AnimateController _animateController;
    private GameLogicLoop _gameLogicLoop;

    public CorrectAnswerTracker(AnimateController animateController, GameLogicLoop gameLogicLoop) 
    {
        _animateController = animateController;
        _gameLogicLoop = gameLogicLoop;
    }

    public void TapToCell(Cell cell)
    {
        if (cell.IsCorrect)
        {
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