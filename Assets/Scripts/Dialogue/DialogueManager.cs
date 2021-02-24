using Ali.Helper;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ali.Helper.UI.Dialogue
{
    public class DialogueManager : LocalSingleton<DialogueManager>
    {
        [SerializeField] private DialogueQuestion _questionDialogue;
        [SerializeField] private DialogueRaw _rawDialogue;

        private DialogueBase _currentDialogue;
        private bool _activeForInteraction = false;
        protected override void Awake()
        {
            base.Awake();
        }

        public IEnumerator WaitForInteract()
        {
            yield return _currentDialogue.WaitForInteract();
        }

        public IEnumerator ShowQuestion(string question, int correctChoiceIndex, params string[] choices)
        {
            _questionDialogue.gameObject.SetActive(true);
            _activeForInteraction = false;
            _questionDialogue.SetContentText(question);
            _questionDialogue.SetCorrectAnswer(correctChoiceIndex);
            _questionDialogue.SetChoicesTexts(choices);
            _currentDialogue = _questionDialogue;
            yield return _currentDialogue.Show();
            _activeForInteraction = true;
        }

        public IEnumerator ShowRaw(string content)
        {
            _rawDialogue.gameObject.SetActive(true);
            _activeForInteraction = false;
            _rawDialogue.SetContentText(content);
            _currentDialogue = _rawDialogue;
            yield return _currentDialogue.Show();
            _activeForInteraction = true;
        }

        public IEnumerator HideCurrentDialogue()
        {
            yield return _currentDialogue.Hide();
            _currentDialogue.Reset();
            DisableAllPanels();
        }

        public void SetContentFontSize(int fontSize)
        {
            _currentDialogue.SetContentFontSize(fontSize);
        }

        public bool IsQuestionAnswerCorrect()
        {
            return _questionDialogue.IsAnswerCorrect();
        }

        public int GetChoiceIndex()
        {
            return _questionDialogue.GetChoicedIndex();
        }

        void DisableAllPanels()
        {
            _questionDialogue.gameObject.SetActive(false);
            _rawDialogue.gameObject.SetActive(false);
        }
    }
}