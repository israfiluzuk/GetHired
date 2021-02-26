using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : LocalSingleton<GameManager>
{

    [SerializeField] Boss bossPlayer;
    [SerializeField] Candidate candidatePlayer;
    [SerializeField] Transform mainCamera;
    [SerializeField] Transform cameraParent;
    [SerializeField] Transform chair;

    [SerializeField] List<Transform> cameraPositions;
    // Start is called before the first frame update
    void Start()
    {
        BossSeatedIdle();
        CandidateToSit();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            mainCamera.SetParent(cameraParent);
            mainCamera.localPosition = cameraPositions[1].transform.localPosition;
            mainCamera.localRotation = cameraPositions[1].transform.localRotation;
            BossSittingIdle();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            CameraShake();
        }
    }
    internal void BossSeatedIdle()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .148f, 9.972f);
        StartCoroutine(bossPlayer.SeatedIdle());
    }
    internal void BossSittingIdle()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .148f, 9.972f);
        StartCoroutine(bossPlayer.BossSittingIdle());
    }
    internal void BossSlapping()
    {
        bossPlayer.transform.DOLocalMove(new Vector3(8.6f, .148f, 10.35f), .3f);
        StartCoroutine(bossPlayer.Slapping());
        chair.DOMove(new Vector3(8.78f, -0.063f, 10.624f), .5f);
    }
    internal void BossSittingSecond()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .148f, 9.972f);
        StartCoroutine(bossPlayer.BossSittingSecond());
    }
    internal void CandidateSeatedIdle()
    {
        StartCoroutine(candidatePlayer.SittingIdle());
    }

    internal void CandidateToSit()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.ToSit());
    }

    public void CandidateNervous()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.NervousSitting());
    }
    public void BoredBoss()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .2f, 10.1f);
        StartCoroutine(bossPlayer.BoredSitting());
    }
    public void CandidateSpeakingProcess()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.FemaleSpeaking());
    }

    public void SitToStand(bool value)
    {
        if (value)
        {
            bossPlayer.transform.DOLocalMove(new Vector3(8.6f, .148f, 10.35f), .3f);
            StartCoroutine(bossPlayer.SitToStand());
        }
        else
        {
            candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 8.14f);
            StartCoroutine(candidatePlayer.SitToStand());
        }
    }

    public void CandidateStumble()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 8.14f);
        StartCoroutine(candidatePlayer.Stumble());
    }

    public void Pointing()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.Pointing());
    }
    public void Writing()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .146f, 10.1f);
        StartCoroutine(bossPlayer.Writing());
    }

    public void CameraShake()
    {
        mainCamera.DOShakeRotation(1, 5);
    }

    public void Typing()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .19f, 9.972f);
        bossPlayer.transform.DORotate(new Vector3(11.4f, 180, 0), .3f);
        StartCoroutine(bossPlayer.Typing());
    }


}
