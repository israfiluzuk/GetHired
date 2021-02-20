using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCamera : LocalSingleton<TPSCamera>
{
    [SerializeField] private bool _smooth;
    [SerializeField] private float _smoothSpeed;
    [SerializeField] private Vector3 _followAxes;

    private Transform _target;
    private Vector3 _offset;

    void Update()
    {
        if(_target)
        {
            Vector3 followPos = _target.position + _offset;
            followPos.x *= _followAxes.x;
            followPos.y *= _followAxes.y;
            followPos.z *= _followAxes.z;
            if(_smooth)
            {
                transform.position = Vector3.Lerp(transform.position, followPos, _smoothSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = followPos;
            }
            
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void SetOffset(Vector3 offset)
    {
        _offset = offset;
    }

    public Transform GetTarget()
    {
        return _target;
    }
}
