public class CorrectAnswerTracker : IAnswerTrakcer
{
    private AnimateController _animateController;

    public CorrectAnswerTracker(AnimateController animateController) 
    {
        _animateController = animateController;
    }

    public void TapToCell(Cell cell)
    {
        if (cell.IsCorrect)
        {

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