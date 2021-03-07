using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : LocalSingleton<GameManager>
{

    [SerializeField] Boss bossPlayer;
    [SerializeField] Candidate candidatePlayer;
    [SerializeField] Killer killer;
    public Transform mainCamera;
    [SerializeField] Transform cameraParent;
    [SerializeField] Transform chair;
    [SerializeField] Transform chairPosTwo;
    [SerializeField] Transform bossPosTwo;
    [SerializeField] Transform bossNormal;
    [SerializeField] Transform paperCV;
    [SerializeField] Transform paperCVUpPos;
    public Transform hiredTextPng;
    public Transform failTextPng;
    [SerializeField] GameObject choosingPanel;
    [SerializeField] GameObject blackPanel;
    [SerializeField] Button bossButton;
    [SerializeField] Button candidateButton;
    public ParticleSystem coolEmoji;
    public ParticleSystem sadEmoji;
    public ParticleSystem angryEmoji;
    public Transform paperCVFirstPos;
    public bool isKillerActive = false;

    [SerializeField] List<Transform> cameraPositions;
    // Start is called before the first frame update
    void Start()
    {
        coolEmoji.Stop();
        sadEmoji.Stop();
        angryEmoji.Stop();
        blackPanel.transform.localScale = Vector3.zero;
        choosingPanel.transform.localScale = Vector3.zero;
        BossSeatedIdle();
        CandidateToSit();
        if (isKillerActive)
            killer.PlayAnim(AnimationType.Standing, .3f, true);
        paperCVFirstPos.position = paperCV.position;

        bossButton.onClick.AddListener(() => ButtonClicked());
        candidateButton.onClick.AddListener(() => ButtonClicked());

    }

    public void ButtonClicked()
    {
        BossCandidatePanel(choosingPanel, Vector3.zero, false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            mainCamera.localPosition = cameraPositions[1].transform.localPosition;
            mainCamera.localRotation = cameraPositions[1].transform.localRotation;
            BossSeatedIdle();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            TellOff();
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            paperCV.DOMove(paperCVUpPos.position, .5f);
            paperCV.DORotate(new Vector3(75, 0, 0), .5f);
            BossSeatedIdle();
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(Jumping());
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            BossCandidatePanel(choosingPanel, Vector3.one, true);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(TextAppear(hiredTextPng, Vector3.one));
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            StartCoroutine(TextAppear(failTextPng, Vector3.one));
        }
        if (Input.GetKeyDown(KeyCode.B))
            coolEmoji.Play();
        if (Input.GetKeyDown(KeyCode.H))
            sadEmoji.Play();
    }

    public void LocateCamera(List<Transform> newCamTransform)
    {

    }

    public IEnumerator Jumping()
    {
        StartCoroutine(killer.Jumping());
        yield return new WaitForSeconds(2f);
        StartCoroutine(bossPlayer.HeadAttacked());
    }
    public IEnumerator HappyMan()
    {
        yield return new WaitForSeconds(.58f);
        StartCoroutine(killer.HappyMan());
    }

    public void BossPositionBack()
    {
        chair.position = chairPosTwo.position;
        bossNormal.position = bossPosTwo.position;
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
        if (!isKillerActive)
        {
            candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
            StartCoroutine(candidatePlayer.NervousSitting());
        }
    }
    public void BoredBoss()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .2f, 10.1f);
        StartCoroutine(bossPlayer.BoredSitting());
    }
    public void ThumbsUp()
    {
        bossPlayer.transform.localPosition = new Vector3(8.6f, .2f, 10.1f);
        StartCoroutine(bossPlayer.ThumbsUp());
    }
    public void SadCandidate()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.BoredSitting());
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

    public void TellOff()
    {
        bossPlayer.transform.DOLocalMove(new Vector3(8.6f, .148f, 10.1f), .3f);
        StartCoroutine(bossPlayer.TellOff());
    }

    public void Pointing()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.Pointing());
    }
    public void WomanSittingHappy()
    {
        candidatePlayer.transform.localPosition = new Vector3(8.19f, .1f, 7.93f);
        StartCoroutine(candidatePlayer.WomanVictory());
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

    //-- Hired and Fail Animations.

    public void BossCandidatePanel(GameObject gameObject, Vector3 vectorValue, bool blackPanelValue)
    {
        blackPanel.SetActive(blackPanelValue);
        blackPanel.transform.localScale = Vector3.one;
        gameObject.transform.DOScale(vectorValue, .58f).SetEase(Ease.OutBounce);
        //iTween.ScaleTo(gameObject, iTween.Hash(vectorValue, .4f, iTween.EaseType.easeInOutBounce));
    }


    public IEnumerator TextAppear(Transform transform, Vector3 vectorValue)
    {
        transform.DOScale(vectorValue, .58f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(1.58f);
        StartCoroutine(TextAppear(transform, Vector3.zero));
    }


}
