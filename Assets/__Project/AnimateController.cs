using DG.Tweening;
using UnityEngine;

public class AnimateController
{
    private Sequence _shakeSequence;
    private Sequence _bounceSequence;
    public void WrongAnimPlay(Transform transform)
    {
        bool isPlaying = _shakeSequence?.IsPlaying() ?? false;
        if (isPlaying) return;

        _shakeSequence = DOTween.Sequence()
            .Append(transform.DOShakePosition(0.4f, 0.19f))
            .OnComplete(() =>
            {
                _shakeSequence.Kill();
                _shakeSequence = null;
            });
    }

    public void BounceAnimPlay(Transform transform, float delay = 0.5f)
    {
        if (_bounceSequence?.IsPlaying() ?? false) return;

        _bounceSequence = DOTween.Sequence()
            .Append(transform.DOScale(1.5f, 0.45f).SetEase(Ease.OutQuad))
            .Append(transform.DOScale(0.8f, 0.35f).SetEase(Ease.InOutQuad))
            .Append(transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce))
            .SetDelay(delay)
            .OnComplete(() =>
            {
                _bounceSequence.Kill();
                _bounceSequence = null;
            });
    }

}
