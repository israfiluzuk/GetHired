using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ali.Helper.UI.Dialogue
{
    public class DialogueQuestion : DialogueBase
    {
        [SerializeField] private RectTransform _questionPanel;
        [SerializeField] private DialogueChoice[] _choices;

        private int _correctAnswerIndex = 0;
        private int _choicedIndex = 0;
        private bool _answeredCorrect = false;

        private void Awake()
        {
            for (int i = 0; i < _choices.Length; i++)
            {
                _choices[i].OnClick += DialogueQuestion_OnClick;
            }
        }

        private void DialogueQuestion_OnClick(int choiceIndex)
        {
            _interacted = true;
            _choicedIndex = choiceIndex;
            _answeredCorrect = _correctAnswerIndex == choiceIndex;
        }

        public void SetChoicesTexts(params string[] choices)
        {
            for (int i = 0; i < _choices.Length; i++)
            {
                _choices[i].SetText(choices[i]);
            }
        }

        public void SetCorrectAnswer(int index)
        {
            _correctAnswerIndex = index;
        }

        public int GetChoicedIndex()
        {
            return _choicedIndex;
        }

        public bool IsAnswerCorrect()
        {
            return _answeredCorrect;
        }

        public override IEnumerator Show()
        {
            _questionPanel.gameObject.SetActive(true);
            _questionPanel.DOKill(true);
            _questionPanel.transform.localScale *= 0.2f;
            yield return _questionPanel.transform.DOScale(_questionPanel.transform.localScale * 5f, _showDuration).WaitForCompletion();
            ShowChoices();
        }

        public override IEnumerator Hide()
        {
            _questionPanel.DOKill(true);
            HideChoices();
            Vector3 scale = _questionPanel.transform.localScale;
            yield return _questionPanel.transform.DOScale(_questionPanel.transform.localScale * 0.3f, _showDuration / 2f).WaitForCompletion();
            _questionPanel.gameObject.SetActive(false);
            _questionPanel.transform.localScale = scale;
        }

        public override void Reset()
        {
            base.Reset();
            for (int i = 0; i < _choices.Length; i++)
            {
                _choices[i].Reset();
            }
        }

        void ShowChoices()
        {
            for (int i = 0; i < _choices.Length; i++)
            {
                _choices[i].Show(_showDuration,i);
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Punch();
            }
        }
        void Punch()
        {
            for (int i = 0; i < _choices.Length; i++)
            {
                _choices[i].Punch(i/2f);
            }
        }

        void HideChoices()
        {
            for (int i = 0; i < _choices.Length; i++)
            {
                _choices[i].Hide();
            }
        }


    }
}