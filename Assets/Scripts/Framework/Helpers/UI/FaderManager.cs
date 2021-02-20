using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class FaderManager : MonoBehaviour
{
    public Image faderImage;
    public float fadeTime = 0.25f;

    public static FaderManager Instance;
    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public IEnumerator CloseTheater()
    {
        faderImage.raycastTarget = true;
        faderImage.DOFade(1f, fadeTime);
        yield return new WaitForSeconds(fadeTime);
    }

    public IEnumerator OpenTheater(float delay = 0f)
    {
        faderImage.DOFade(0f, fadeTime).SetDelay(delay);
        yield return new WaitForSeconds(fadeTime + delay);
        faderImage.raycastTarget = false;
    }
}
