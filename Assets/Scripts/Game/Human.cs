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
    }
    public IEnumerator SittingIdle()
    {
        PlayAnim(AnimationType.SittingIdle,.3f,true);
        yield return new WaitForSeconds(.5f);
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
        yield return new WaitForSeconds(1f);
        StartCoroutine(SittingIdle());
    }
}
