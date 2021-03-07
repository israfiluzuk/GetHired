using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CVController : MonoBehaviour
{
    private void OnMouseDown()
    {
        this.transform.DOMove(GameManager.Instance.paperCVFirstPos.position, .5f);
        this.transform.DORotate(new Vector3(0,0,0), .5f);
        StartCoroutine(CameraBack());
    }

    private  IEnumerator CameraBack()
    {
        yield return new WaitForSeconds(.58f);
        GameManager.Instance.mainCamera.transform.DOMove(new Vector3(5.701f, 2.141f, 7.352f), .5f);
        GameManager.Instance.mainCamera.transform.DORotate(new Vector3(25, 60, 0), .5f);
    }
}
