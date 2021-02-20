using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterAnimator : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _walkAnimStateName;
    // Start is called before the first frame update
    public void Idle()
    {
        if(_animator.GetBool(_walkAnimStateName))
        {
            _animator.SetBool(_walkAnimStateName, false);
        }
    }

    public void Walk()
    {
        if (!_animator.GetBool(_walkAnimStateName))
        {
            _animator.SetBool(_walkAnimStateName, true);
        }
    }

    public void SetAnimationParameter(string paramName, bool value)
    {
        if (_animator.GetBool(paramName) != value)
        {
            _animator.SetBool(paramName, value);
        }
    }

    public void SetAnimationTriggerParameter(string paramName)
    {
        _animator.SetTrigger(paramName);
    }

    public void UpdateRotation(Vector3 input)
    {
        if (input.sqrMagnitude > 0.01f)
        {
            _animator.transform.eulerAngles = new Vector3(0f, GameUtility.DirectionToAngle(new Vector2(input.x, input.z)), 0f);
        }
    }

}
