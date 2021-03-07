using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ali.Helper.UI.Dialogue;

public class DialogueSystem : LocalSingleton<DialogueSystem>
{
    public static int ScenarioIndex = 0; 

    public static void SetScenarioIndex(int index)
    {
        ScenarioIndex = index; 
    }


    IEnumerator Start()
    {
        yield return new WaitForSeconds(.1f);
        switch (ScenarioIndex)
        {
            case 0:
                yield return FifthInverviewQuestionAnswer();
                break;
            case 1:
                yield return KillerScenerio();
                break;
            default:
                yield return null;
                break;
        }


    }
    //-------------------------------------


    IEnumerator KillerScenerio()
    {
        yield return new WaitForSeconds(10);
        yield return DialogueManager.Instance.ShowQuestion("What are you going to do?", 0, "Hire", "Kick out!");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        //GameManager.Instance.BossPositionBack();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(GameManager.Instance.HappyMan());
            StartCoroutine(GameManager.Instance.TextAppear(GameManager.Instance.hiredTextPng, Vector3.one));
            GameManager.Instance.coolEmoji.Play();
            GameManager.Instance.ThumbsUp();
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(GameManager.Instance.TextAppear(GameManager.Instance.failTextPng, Vector3.one));
            GameManager.Instance.angryEmoji.Play();
            yield return new WaitForSeconds(1.5f);
            GameManager.Instance.CandidateNervous();
            StartCoroutine(GameManager.Instance.Jumping());
        }
    }



    //-------------------------------------
    //first question - tell me about yourself
    IEnumerator IntroductionProccess()
    {
        yield return new WaitForSeconds(1.58f);
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Tell me about yourself?", 0, "Start", "Hmmm...");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(IntroducingAnswering());
        }
        else
        {
            GameManager.Instance.CandidateNervous();
            yield return new WaitForSeconds(1f); 
            StartCoroutine(ProblemQuestion());
        }
    }
    //second question - Are you OK?
    IEnumerator ProblemQuestion()
    {
        yield return new WaitForSeconds(1.58f);
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Are you OK? Take your time. It's fine.", 0, "I just need to calm...", "Hide your concern and speak");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(GettingCalmQuestion());
        }
        else
        {
            yield return new WaitForSeconds(1f); 
            StartCoroutine(IntroducingAnswering());
        }
    }

    //third question - What about now
    IEnumerator GettingCalmQuestion()
    {
        yield return new WaitForSeconds(1.58f);
        yield return DialogueManager.Instance.ShowQuestion("BOSS: What about now?", 0, "I feel better.", "No! I need some time.");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.CandidateSeatedIdle();
            yield return new WaitForSeconds(1);
            StartCoroutine(IntroducingAnswering());
        }
        else
        {
            yield return new WaitForSeconds(1f); 
            StartCoroutine(GettingCalmQuestion());
        }
    }

    //forth question - Introduction
    IEnumerator IntroducingAnswering()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSpeakingProcess();
        yield return DialogueManager.Instance.ShowQuestion("CANDIDATE: I am .......", 0, "Enough!", "Speak more. Maybe hobbies.");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            StartCoroutine(SecondInverviewQuestion());
        }
        else
        {
            yield return new WaitForSeconds(4f);
            GameManager.Instance.BoredBoss();
            StartCoroutine(IntroductionAnsweringSecondPart());
        }
    }
    
    //fifth question - Introduction second part
    IEnumerator IntroductionAnsweringSecondPart()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSpeakingProcess();
        yield return DialogueManager.Instance.ShowQuestion("CANDIDATE: My hobbies are ....", 0, "Stop it!", "Next question?");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.CandidateSeatedIdle();
            GameManager.Instance.BossSeatedIdle();
            StartCoroutine(SecondInverviewQuestion());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(SecondInverviewQuestion());
            yield return new WaitForSeconds(1f);
            GameManager.Instance.BossSeatedIdle();
        }
    }
    //fifth question - Where do you see yourself in five years
    IEnumerator SecondInverviewQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Where do you see yourself in five years?", 0, "In your position", "I want to improve my skills...");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(.3f);
            GameManager.Instance.Pointing();
            yield return new WaitForSeconds(1f);
            GameManager.Instance.Writing();
            yield return new WaitForSeconds(1f);
            StartCoroutine(DecisionQuestionForBoss());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            yield return new WaitForSeconds(2f);
            StartCoroutine(ThirdInverviewQuestion());
        }
    }
    
    //What are you going to do question - 
    IEnumerator DecisionQuestionForBoss()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("Arrogant! What are you going to do with her?", 0, "Go on.", "Slap!");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.Writing();
            yield return new WaitForSeconds(1f);
            StartCoroutine(ThirdInverviewQuestion());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            yield return new WaitForSeconds(1f);
            GameManager.Instance.SitToStand(true);
            yield return new WaitForSeconds(.5f);
            GameManager.Instance.SitToStand(false);
            yield return new WaitForSeconds(2f);
            GameManager.Instance.BossSlapping();
            yield return new WaitForSeconds(1.2f);
            GameManager.Instance.CameraShake();
            GameManager.Instance.CandidateStumble();
            yield return new WaitForSeconds(1);
            GameManager.Instance.TellOff();
        }
    }

    //sixth question - Why are you leaving your current job?
    IEnumerator ThirdInverviewQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Why are you leaving your current job?", 0, "Actually I don't have now.", "Blame your previous company!");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            GameManager.Instance.Typing();
            yield return new WaitForSeconds(2);
            StartCoroutine(ForthInverviewQuestion());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            GameManager.Instance.Typing();
            yield return new WaitForSeconds(2);
            StartCoroutine(ForthInverviewQuestion());
        }
    }


    //sixth question - What are your salary expectations?
    IEnumerator ForthInverviewQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("BOSS: What are your salary expectations?", 0, "5000 dollar", "14000 dollar");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            GameManager.Instance.BossSittingSecond();
            yield return new WaitForSeconds(2f);
            GameManager.Instance.Writing();
            yield return new WaitForSeconds(2f);
            StartCoroutine(FifthInverviewQuestion());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            yield return new WaitForSeconds(2f);
            GameManager.Instance.CandidateSeatedIdle();
            GameManager.Instance.Typing();
            yield return new WaitForSeconds(2f);
            StartCoroutine(FifthInverviewQuestion());
        }
    }

    //sixth question - Do you have any questions for me?
    IEnumerator FifthInverviewQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Do you have any questions for me?", 0, "Yes. What about overtime works?", "No. Thanks.");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            yield return new WaitForSeconds(1f);
            StartCoroutine(FifthInverviewQuestionAnswer());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();

        }
    }

    
    //seventh question - Sixth question Answer
    IEnumerator FifthInverviewQuestionAnswer()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("BOSS: We pay %50 extra per hour", 0, "That's good. Thanks", "Just 50% extra?");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            GameManager.Instance.ThumbsUp();
            yield return new WaitForSeconds(2f);
            //StartCoroutine(BossDecideWomanHiring());
            StartCoroutine(GameManager.Instance.TextAppear(GameManager.Instance.hiredTextPng, Vector3.one));
            GameManager.Instance.WomanSittingHappy();
            GameManager.Instance.coolEmoji.Play();
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.CandidateSpeakingProcess();
            yield return new WaitForSeconds(2f);
            StartCoroutine(BossDecideWomanHiring());
            StartCoroutine(GameManager.Instance.TextAppear(GameManager.Instance.failTextPng, Vector3.one));
            GameManager.Instance.sadEmoji.Play();
        }
    }//seventh question - Sixth question Answer
    IEnumerator BossDecideWomanHiring()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("Do you want to hire her?", 0, "YES", "NO");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.WomanSittingHappy();
            GameManager.Instance.ThumbsUp();
            StartCoroutine(GameManager.Instance.TextAppear(GameManager.Instance.hiredTextPng, Vector3.one));
            GameManager.Instance.coolEmoji.Play();
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.SadCandidate();
            StartCoroutine(GameManager.Instance.TextAppear(GameManager.Instance.failTextPng, Vector3.one));
            GameManager.Instance.sadEmoji.Play();

        }
    }


}
