using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AnimationType
{
    SeatedIdle,
    SittingIdle,
    Tosit,
    NervousSit1,
    NervousSit2,
    BoredSitting,
    FemaleMeetingSitting,
    MaleMeetingSitting,
    ConfidentSit1,
    ConfidentSit2,
    BossSit1,
    BossSit2,
    CandidateSit1,
    CandidateSit2,
    Speaking1,
    Speaking2,
    Pointing
}

public class AnimationReferencer : LocalSingleton<AnimationReferencer>
{

    [System.Serializable]
    public class MyAnimation
    {
        public AnimationType animationType;
        public AnimationClip animation;
    }

    public MyAnimation[] animations;
    public Avatar human;

}
