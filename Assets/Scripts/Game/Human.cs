using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Human : Animations
{
    private Rigidbody _rb;
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
        PlayAnim(AnimationType.SeatedIdle,.3f,true);
        yield return new WaitForSeconds(.5f);
        transform.DORotate(new Vector3(6, 180, 0),.3f);
        transform.DOLocalMove(new Vector3(8.6f, .148f, 9.972f), .1f);
    }
    public IEnumerator BossSittingIdle()
    {
        PlayAnim(AnimationType.BossSit2,.3f,true);
        yield return new WaitForSeconds(.5f);
        transform.DORotate(new Vector3(0, 180, 0),.3f);
        transform.DOLocalMove(new Vector3(8.6f, .148f, 9.972f), .1f);
    }
    public IEnumerator SittingIdle()
    {
        PlayAnim(AnimationType.SittingIdle,.3f,true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator BossSittingSecond()
    {
        PlayAnim(AnimationType.BossSit2,.3f,true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator SitToStand()
    {
        PlayAnim(AnimationType.SitToStand,.3f,true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator Stumble()
    {
        PlayAnim(AnimationType.Stumbling,.3f,true);
        yield return new WaitForSeconds(.5f);
    }
    public IEnumerator Slapping()
    {
        yield return new WaitForSeconds(.5f);
        PlayAnim(AnimationType.Slapping,.3f,true);
        transform.DOLocalMove(new Vector3(8.4f,.1f,9.94f),.1f);
        yield return new WaitForSeconds(2);
        PlayAnim(AnimationType.Standing,.3f,false);
    }
    public IEnumerator ToSit()
    {
        PlayAnim(AnimationType.Tosit,.3f,true);
        yield return new WaitForSeconds(1f);
        StartCoroutine(SittingIdle());
    }
    public IEnumerator NervousSitting()
    {
        PlayAnim(AnimationType.NervousSit1,.3f,true);
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator  BoredSitting()
    {
        PlayAnim(AnimationType.BoredSitting,.3f,true);
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator  FemaleSpeaking()
    {
        PlayAnim(AnimationType.FemaleMeetingSitting,.3f,true);
        yield return new WaitForSeconds(1f);
    }
    internal IEnumerator Pointing()
    {
        PlayAnim(AnimationType.Pointing, .3f, true);
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
}
