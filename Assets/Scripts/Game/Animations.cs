using Animancer;
using System;
using UnityEngine;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(AnimancerComponent))]

public class Animations : MonoBehaviour
{
    [Header("Animations list [Can't edit]")]

    public AnimationReferencer.MyAnimation[] animations;
    private AnimancerComponent _animancer;
    public AnimancerComponent animancer
    {
        get
        {
            if (_animancer == null)
            {
                _animancer = GetComponent<AnimancerComponent>();
            }
            return _animancer;
        }
    }
    public Action endFunctionAction;
    private bool isAnimationEnded;

    protected virtual void Awake()
    {
        int animationCount = AnimationReferencer.Instance.animations.Length;
        animations = new AnimationReferencer.MyAnimation[animationCount];
        for (int i = 0; i < animationCount; i++)
        {
            animations[i] = AnimationReferencer.Instance.animations[i];
        }
    }

    public bool isParent;
    public void PlayAnim(AnimationType clip, float fade = 0.3f, bool isMixamo = false, float speed = 1, Action endAnimation = null)
    {
        if (isMixamo)
        {
            if (animancer.Animator.avatar != null)
                fade = 0;
            animancer.Animator.avatar = null;
        }
        else
        {
            if (animancer.Animator.avatar == null)
                fade = 0;
            if (isParent)
            {
                animancer.Animator.avatar = AnimationReferencer.Instance.human;
            }
        }
        var state = animancer.Play(FindAnim(clip), fade);
        state.Speed = speed;
        isAnimationEnded = false;
        if (endAnimation != null)
        {
            endFunctionAction = endAnimation;
            state.Events.OnEnd = OnEndEvent;
        }
    }

    private AnimationClip FindAnim(AnimationType type)
    {
        for (int i = 0; i < animations.Length; i++)
        {
            if (animations[i].animationType == type)
            {
                return animations[i].animation;
            }
        }
        Debug.LogError("Not found " + type + " animation!");
        return null;
    }

    private void OnEndEvent()
    {
        if (!isAnimationEnded)
        {
            isAnimationEnded = true;
            endFunctionAction();
        }
    }
}
