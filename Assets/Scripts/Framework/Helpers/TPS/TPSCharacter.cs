using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacter : MonoBehaviour
{
    [SerializeField] private TPSCharacterAnimator _animator;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private bool _mapLimited;
    [SerializeField] private Vector3 _minMapLimit;
    [SerializeField] private Vector3 _maxMapLimit;


    private bool _moveEnabled = true;
    private Vector2 _input;
    private Rigidbody _rigidbody;

    private float _counter = 0f;

    public event Action<Collider> OnTriggerTouchedEnter;
    public event Action<Collision> OnCollisionTouchedEnter;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateVelocity();
        UpdateAnimation();
        UpdateRotation();
        ClampPosition();
    }



    void UpdateVelocity()
    {
        if (_moveEnabled)
        {
            float velY = _rigidbody.velocity.y;
            _rigidbody.velocity = new Vector3(_input.x, 0f, _input.y) * _moveSpeed * Time.deltaTime;
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, velY, _rigidbody.velocity.z);
        }
        else
        {
            _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, 0f);
        }

    }

    void UpdateAnimation()
    {
        if (_rigidbody.velocity.sqrMagnitude < 0.05f)
        {
            _animator.Idle();
        }
        else
        {
            _animator.Walk();
        }
    }

    void UpdateRotation()
    {
        if (_input.sqrMagnitude > 0.01f && _moveEnabled)
        {
            _animator.transform.eulerAngles = new Vector3(0f, GameUtility.DirectionToAngle(_input), 0f);
        }
    }

    void ClampPosition()
    {
        if (_mapLimited)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, _minMapLimit.x, _maxMapLimit.x), Mathf.Clamp(transform.position.y, _minMapLimit.y, _maxMapLimit.y), Mathf.Clamp(transform.position.z, _minMapLimit.z, _maxMapLimit.z));
        }
    }

    public Vector3 GetDirection()
    {
        return _animator.transform.forward;
    }

    public void SetMoveActive(bool value)
    {
        _moveEnabled = value;
    }

    public void SetInput(Vector2 input)
    {
        _input = input;
    }

    public void SetAnimation(string paramName, bool value)
    {
        _animator.SetAnimationParameter(paramName, value);
    }

    public void SetAnimationTrigger(string paramName)
    {
        _animator.SetAnimationTriggerParameter(paramName);
    }

    public void OnTriggerEnter(Collider other)
    {
        OnTriggerTouchedEnter?.Invoke(other);
    }

    public void OnCollisionEnter(Collision other)
    {
        OnCollisionTouchedEnter?.Invoke(other);
    }
}
