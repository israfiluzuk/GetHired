using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookAtMove : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _endPos;
    [SerializeField] private float _travelDuration;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return transform.DOMove(_endPos, _travelDuration).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_target);
    }
}
