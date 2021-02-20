using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPoint : MonoBehaviour
{
    public int Point = 100;
    public TextMeshPro Text;

    private void Awake()
    {
        Text.text = Point.ToString();
    }

    private void Update()
    {
        Text.transform.eulerAngles = new Vector3(90f, 0f, 0f);
    }

    public void DisableText()
    {
        Text.enabled = false;
    }

}
