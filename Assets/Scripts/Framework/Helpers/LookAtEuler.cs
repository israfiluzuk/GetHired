using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtEuler : MonoBehaviour
{

    private Transform _target;

    private void Start()
    {
        _target = Camera.main.transform;
    }

    void Update()
    {
        if(_target)
        {
            Quaternion lookRotation = Quaternion.LookRotation(transform.position - _target.position);
            transform.eulerAngles = new Vector3(lookRotation.eulerAngles.x, lookRotation.eulerAngles.y, transform.eulerAngles.z);
        }
    }
}
