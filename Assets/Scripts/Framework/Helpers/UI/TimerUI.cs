using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerUI : MonoBehaviour
{
    [SerializeField] private Text _timerText;
    [SerializeField] private Image _timerFillImage;

    public event Action OnTimerReached;

    private float _timer = 0f;
    private float _maxTimer = 0f;
    private bool _started = false;
    private void Update()
    {
        if(_started)
        {
            _timer -= Time.deltaTime;
            _timerFillImage.fillAmount = _timer / _maxTimer;
            UpdateText();
            if (_timer <= 0.001f)
            {
                _timer = 0f;
                UpdateText();
                _started = false;
                OnTimerReached?.Invoke();
            }
        }
    }

    public void SetTimer(float timer)
    {
        _maxTimer = timer;
        _timer = timer;
    }

    public void StartTimer()
    {
        _started = true;
    }

    void UpdateText()
    {
        _timerText.text = ((int)(_timer)).ToString();
    }
}
