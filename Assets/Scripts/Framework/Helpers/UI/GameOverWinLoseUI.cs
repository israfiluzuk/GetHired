using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWinLoseUI : MonoBehaviour
{
    [SerializeField] private RectTransform _winPanel;
    [SerializeField] private RectTransform _losePanel;
    [SerializeField] private Image _fadeImage;
    [SerializeField] private float _panelShowDuration;

    [Header("Win Stars")]
    [SerializeField] private Image[] _starImages;
    [SerializeField] private Vector3 _starPunchVector;
    [SerializeField] private float _starPunchDuration;

    private int _starCount = 0;
    private bool _panelShown = false;

    public event Action OnNextButtonClickEvent;
    public event Action OnTryAgainButtonClickEvent;

    public void OnNextButtonClick()
    {
        OnNextButtonClickEvent?.Invoke();
    }

    public void OnTryAgainButtonClick()
    {
        OnTryAgainButtonClickEvent?.Invoke();
    }

    public void SetStarCount(int starCount)
    {
        int count = Mathf.Min(starCount, _starImages.Length);
        _starCount = count;
        
    }

    public void Show(bool win)
    {
        if(_panelShown)
        {
            return;
        }
        _panelShown = true;
        if(_fadeImage)
        {
            _fadeImage.raycastTarget = true;
            _fadeImage.DOFade(0.3f, _panelShowDuration);
        }
        
        if (win)
        {
            _winPanel.DOAnchorPosY(0, _panelShowDuration).OnComplete(() => StartCoroutine(StarAnimations())); 
        }
        else
        {
            _losePanel.DOAnchorPosY(0, _panelShowDuration);
        }
    }

    IEnumerator StarAnimations()
    {
        for (int i = 0; i < _starCount; i++)
        {
            _starImages[i].gameObject.SetActive(true);
            _starImages[i].rectTransform.DOPunchScale(_starPunchVector, _starPunchDuration, 7);
            yield return new WaitForSeconds(0.25f);
        }
    }

}
