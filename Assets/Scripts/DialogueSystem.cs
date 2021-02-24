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
                yield return IntroductionProccess();
                break;
            default:
                yield return null;
                break;
        }


    }

    //first question - tell me about yourself
    IEnumerator IntroductionProccess()
    {
        yield return new WaitForSeconds(1.58f);
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Welcome. Can you tell me about yourself?", 0, "Start", "Hmmm...");
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
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Are you OK? Take your time. It's fine.", 0, "I just need to calm...", "Hide your concern and Start speaking");
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
        GameManager.Instance.SpeakingProcess();
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
            yield return new WaitForSeconds(1f);
            GameManager.Instance.BoredBoss();
            StartCoroutine(IntroductionAnsweringSecondPart());
        }
    }
    
    //fifth question - Introduction second part
    IEnumerator IntroductionAnsweringSecondPart()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.SpeakingProcess();
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
        }
    }
    //fifth question - Introduction
    IEnumerator SecondInverviewQuestion()
    {
        yield return new WaitForSeconds(1.5f);
        GameManager.Instance.CandidateSeatedIdle();
        yield return DialogueManager.Instance.ShowQuestion("BOSS: Where do you see yourself in five years?", 0, "In your position", "I want to improve my skills in this area.");
        yield return DialogueManager.Instance.WaitForInteract();
        yield return new WaitForSeconds(0.3f);
        yield return DialogueManager.Instance.HideCurrentDialogue();
        if (DialogueManager.Instance.GetChoiceIndex() == 0)
        {
            yield return new WaitForSeconds(0.3f);
            GameManager.Instance.Pointing();
        }
        else
        {
            yield return new WaitForSeconds(1f);
            GameManager.Instance.SpeakingProcess();
        }
    }


}
