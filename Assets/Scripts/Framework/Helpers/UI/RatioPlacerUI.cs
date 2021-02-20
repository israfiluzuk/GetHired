using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatioPlacerUI : MonoBehaviour
{
    [SerializeField] private Image _targetImage;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _maxHeight;

    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _image.rectTransform.anchoredPosition = new Vector2(_image.rectTransform.anchoredPosition.x, _maxHeight * _targetImage.fillAmount + _offsetY);
    }

    public void SetImageActive(bool value)
    {
        GameUtility.ChangeAlphaImage(_image, value ? 1f : 0f);
    }
}
