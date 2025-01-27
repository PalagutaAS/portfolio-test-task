using DG.Tweening;
using UnityEngine;

public class AnimateController
{
    private Transform _fromShake;
    private Transform _fromBounce;

    public void WrongAnimPlay(Transform transform)
    {
        if (transform == _fromShake) return;

        _fromShake = transform;
        DOTween.Sequence()
            .Append(transform.DOShakePosition(0.4f, 0.19f))
            .OnComplete(() => {
                transform.position = _fromShake.position;
                _fromShake = null;
            });
    }

    public void BounceAnimPlay(Transform transform, float delay = 0.5f)
    {
        if (transform == _fromBounce) return;

        _fromBounce = transform;
        transform.localScale = Vector3.zero;
        DOTween.Sequence()
            .Append(transform.DOScale(1.5f, 0.45f).SetEase(Ease.OutQuad))
            .Append(transform.DOScale(0.8f, 0.35f).SetEase(Ease.InOutQuad))
            .Append(transform.DOScale(1f, 0.25f).SetEase(Ease.OutBounce))
            .SetDelay(delay)
            .OnComplete(() => _fromBounce = null );
    }

}
