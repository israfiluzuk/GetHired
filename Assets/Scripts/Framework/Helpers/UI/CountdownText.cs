using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownText : MonoBehaviour
{
    [SerializeField] private int _startNumber = 3;
    private Text _textComponent;

    private int _counter = 0;
    private bool _running = false;

    public event Action OnCountdownReached;
    
    private void Awake()
    {
        _textComponent = GetComponent<Text>();
    }

    public void StartCountdown()
    {
        if(_running)
        {
            return;
        }
        _running = true;
        StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        _counter = _startNumber;
        _textComponent.enabled = true;
        for (int i = _counter; i >= 0; i--)
        {
            if(i == 0)
            {
                _textComponent.text = "GO!";
            }
            else
            {
                _textComponent.text = _counter.ToString();
            }
            
            yield return new WaitForSeconds(1f);
            _counter--;
        }
        OnCountdownReached?.Invoke();
        _textComponent.enabled = false;
        _running = false;
    }
}
