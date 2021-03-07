using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Human : Animations
{
    private Rigidbody _rb;

    public bool IsHumanKiller = false;
    protected Rigidbody rb
    {
        get
        {
            if (_rb == null)
            {
                _rb = GetComponent<Rigidbody>();
            }
            return _rb;
        }
    }


    public IEnumerator SeatedIdle()
    {
        PlayAnim(AnimationType.SeatedIdle, .3f, true);
        yield return new WaitForSeconds(.5f);
        transform.DORotate(new Vector3(6, 180, 0), .3f);
        transform.DOLocalMove(new Vector3(8.6f, .148f, 9.972f), .1f);
    }
    public IEnumerator BossSittingIdle()
    {
        PlayAnim(AnimationType.BossSit2, .3f, true);
        yield return new WaitForSeconds(.5f);
        transform.DORotate(new Vector3(0, 180, 0), .3f);
        transform.DOLocalMove(new Vector3(8.6f, .148f, 9.972f), .1f);
    }
    public IEnumerator SittingIdle()
    {
        PlayAnim(AnimationType.SittingIdle, .3f, true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator BossSittingSecond()
    {
        PlayAnim(AnimationType.BossSit2, .3f, true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator SitToStand()
    {
        PlayAnim(AnimationType.SitToStand, .3f, true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator Stumble()
    {
        PlayAnim(AnimationType.Stumbling, .3f, true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator TellOff()
    {
        PlayAnim(AnimationType.TellOff, .3f, true);
        yield return new WaitForSeconds(2);
        PlayAnim(AnimationType.Standing, .3f, true);
    }

    public IEnumerator Slapping()
    {
        yield return new WaitForSeconds(.5f);
        PlayAnim(AnimationType.Slapping, .3f, true);
        transform.DOLocalMove(new Vector3(8.4f, .1f, 9.94f), .1f);
        yield return new WaitForSeconds(2);
        PlayAnim(AnimationType.Standing, .5f, true);
    }
    public IEnumerator ToSit()
    {
        PlayAnim(AnimationType.Tosit, .3f, true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SittingIdle());
    }
    public IEnumerator NervousSitting()
    {
        PlayAnim(AnimationType.NervousSit1, .3f, true);
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator BoredSitting()
    {
        PlayAnim(AnimationType.BoredSitting, .3f, true);
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator FemaleSpeaking()
    {
        PlayAnim(AnimationType.FemaleMeetingSitting, .3f, true);
        yield return new WaitForSeconds(1f);
    }
    internal IEnumerator Pointing()
    {
        PlayAnim(AnimationType.Pointing, .3f, true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(FemaleSitting());
    }
    internal IEnumerator WomanVictory()
    {
        yield return new WaitForSeconds(.5f);
        PlayAnim(AnimationType.SittingHappy, .3f, true);
    }
    internal IEnumerator ThumbsUp()
    {
        PlayAnim(AnimationType.ThumbsUp, .3f, true);
        yield return new WaitForSeconds(2f);
        StartCoroutine(FemaleSitting());
    }
    internal IEnumerator FemaleSitting()
    {
        PlayAnim(AnimationType.FemaleSitting1, .3f, true);
        yield return new WaitForSeconds(1f);
    }
    internal IEnumerator Writing()
    {
        PlayAnim(AnimationType.Writing, .3f, true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(SeatedIdle());
    }
    internal IEnumerator Typing()
    {
        PlayAnim(AnimationType.Typing, .3f, true);
        yield return new WaitForSeconds(3f);
        StartCoroutine(SeatedIdle());
    }

    internal IEnumerator HeadAttacked()
    {
        yield return new WaitForSeconds(.2f);
        GameManager.Instance.CameraShake();
        yield return new WaitForSeconds(.38f);
        PlayAnim(AnimationType.HeadAttacked,.3f,true);
    }

    public IEnumerator Jumping()
    {
        if (GameManager.Instance.isKillerActive)
        {
            yield return new WaitForSeconds(.5f);
            PlayAnim(AnimationType.JumpingUp, .3f, true,1.38f);
            yield return new WaitForSeconds(.58f);
            transform.DOJump(new Vector3(8.19f, .86f, 8.845f), .2f,1,.9f);
            yield return new WaitForSeconds(.7f);
            PlayAnim(AnimationType.Kicking, .5f, true);
            yield return new WaitForSeconds(.45f);
            //GameManager.Instance.mainCamera.transform.DOShakePosition(.4f,2,1);
        }

    }

    public IEnumerator HappyMan()
    {
        yield return new WaitForSeconds(.58f);
        PlayAnim(AnimationType.MaleHappy, .4f, true);
    }
}
