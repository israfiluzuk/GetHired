using Lean.Touch;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSInputManager : LocalSingleton<TPSInputManager>
{
    [SerializeField] private TPSCharacter _tpsCharacter;

    private void Start()
    {
        LeanTouch.OnFingerDown += LeanTouch_OnFingerDown;
        LeanTouch.OnFingerUp += LeanTouch_OnFingerUp;
        LeanTouch.OnFingerUpdate += LeanTouch_OnFingerSet;
    }

    private void LeanTouch_OnFingerDown(LeanFinger obj)
    {
        
    }

    private void LeanTouch_OnFingerUp(LeanFinger obj)
    {
        _tpsCharacter.SetInput(Vector3.zero);
    }

    

    private void LeanTouch_OnFingerSet(LeanFinger obj)
    {
        _tpsCharacter.SetInput(obj.SwipeScaledDelta.normalized);
    }
}
