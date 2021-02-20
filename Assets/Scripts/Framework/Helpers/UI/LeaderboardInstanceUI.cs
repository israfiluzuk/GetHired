using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardInstanceUI : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _pointText;
    [SerializeField] private Color _uniqueTextColor;

    // Start is called before the first frame update
    public void SetIcon(Sprite sprite)
    {
        _image.sprite = sprite;
    }

    public void SetPoints(int points)
    {
        _pointText.text = points.ToString();
    }

    public void SetNameText(string text)
    {
        _nameText.text = text;
    }

    public void SetSiblingIndex(int index)
    {
        transform.SetSiblingIndex(index);
    }

    public void SetUnique(bool unique)
    {
        if (unique)
        {
            _pointText.color = _uniqueTextColor;
        }
        else
        {
            _pointText.color = Color.white;
        }
    }
}
