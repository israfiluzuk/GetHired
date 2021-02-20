using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatioBarVertical : MonoBehaviour
{
    [SerializeField] private Text _percentText;

    private Image _image;
    void Awake()
    {
        _image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        _percentText.text = "%" + (int)(_image.fillAmount * 100f);
    }

    public void SetRatio(float ratio)
    {
        _image.fillAmount = ratio;
    }
}
