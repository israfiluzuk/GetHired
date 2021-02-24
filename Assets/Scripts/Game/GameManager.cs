using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : LocalSingleton<GameManager>
{

    [SerializeField] Boss bossPlayer;
    [SerializeField] Candidate candidatePlayer;

    [SerializeField] List<Transform> cameraPositions;
    // Start is called before the first frame update
    void Start()
    {
        BossSeatedIdle();
        CandidateToSit();
    }

    internal void BossSeatedIdle()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .148f,9.972f);
        StartCoroutine(bossPlayer.SeatedIdle());
    }
    internal void CandidateSeatedIdle()
    {
        StartCoroutine(candidatePlayer.SittingIdle());
    }

    internal void CandidateToSit()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.5f);
        StartCoroutine(candidatePlayer.ToSit());
    }
    
    public void CandidateNervous()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.5f);
        StartCoroutine(candidatePlayer.NervousSitting());
    }
    public void BoredBoss()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .2f, 10.1f);
        StartCoroutine(bossPlayer.BoredSitting());
    }
    public void SpeakingProcess()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.5f);
        StartCoroutine(candidatePlayer.FemaleSpeaking());
    }
    
    public void Pointing()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.5f);
        StartCoroutine(candidatePlayer.Pointing());
    }

}
