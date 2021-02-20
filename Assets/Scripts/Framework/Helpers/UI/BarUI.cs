using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : MonoBehaviour
{
    [SerializeField] private Image _barImage;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private bool _hideWhileEmpty = false;
    [SerializeField] private bool _isWorldCanvas = true;
    Tweener barTween;

    private Transform _target;
    private void Awake()
    {
        if(_isWorldCanvas)
        {
            transform.SetParent(GameObject.Find("WorldCanvas").transform);
        }
        
        if (_hideWhileEmpty)
        {
            CheckForEmpty();
        }
    }
    public void SetRatio(float ratio, float speed)
    {
        if(barTween != null)
        {
            barTween.Kill();
        }
        barTween = _barImage.DOFillAmount(ratio, speed).SetSpeedBased().OnUpdate(() => 
        {
            _barImage.color = _gradient.Evaluate(_barImage.fillAmount);
        });
    }

    public void SetRatio(float ratio)
    {
        if (barTween != null)
        {
            barTween.Kill();
        }
        if(_hideWhileEmpty)
        {
            CheckForEmpty();
        }
        
        _barImage.fillAmount = ratio;
        _barImage.color = _gradient.Evaluate(_barImage.fillAmount);
    }

    private void Update()
    {
        if(_target)
        {
            transform.position = _target.position;
        }
    }

    void CheckForEmpty()
    {
        if (Mathf.Approximately(_barImage.fillAmount, 0f))
        {
            GameUtility.ChangeAlphaImage(GetComponent<Image>(), 0f);
            GameUtility.ChangeAlphaImage(_barImage, 0f);
        }
        else
        {
            GameUtility.ChangeAlphaImage(GetComponent<Image>(), 1f);
            GameUtility.ChangeAlphaImage(_barImage, 1f);
        }
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public void SetPosition(Vector3 position)
    {
        transform.position = position;
    }
}
