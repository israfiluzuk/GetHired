using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleAnimationLoop : MonoBehaviour
{
    [SerializeField] private float _scaleMultiplier = 1.1f;
    [SerializeField] private float _duration = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        transform.DOScale(transform.localScale * _scaleMultiplier, _duration).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
