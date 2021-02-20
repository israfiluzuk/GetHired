using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SmoothNumberText : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private int _targetPoints = 0;
    private int _points = 0;
    private Tweener _smoothTween;
    private Text _textComponent;

    private void Awake()
    {
        _textComponent = GetComponent<Text>();
    }

    public void SetPoints(int points)
    {
        _targetPoints = points;
        _smoothTween?.Kill();
        _smoothTween = DOTween.To(() => _points, x => _points = x, _targetPoints, _speed).SetSpeedBased().OnUpdate(UpdateText);
    }

    void UpdateText()
    {
        if(_textComponent)
        {
            _textComponent.text = _points.ToString();
        }
        
    }
}
