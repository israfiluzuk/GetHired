using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ali.Helper.UI.Dialogue
{
    public class DialogueRaw : DialogueBase
    {
        [SerializeField] private RectTransform _dialoguePanel;
        [SerializeField] private Button _arrowButton;
        public override IEnumerator Hide()
        {
            _arrowButton.DOKill(true);
            yield return _dialoguePanel.transform.DOScale(_dialoguePanel.transform.localScale * 0.3f, _showDuration / 2f).WaitForCompletion();
            _dialoguePanel.gameObject.SetActive(false);
        }

        public override IEnumerator Show()
        {
            _arrowButton.transform.DOScale(_arrowButton.transform.localScale * 1.2f, 0.6f).SetLoops(-1, LoopType.Yoyo);
            _dialoguePanel.gameObject.SetActive(true);
            _dialoguePanel.DOKill(true);
            _dialoguePanel.transform.localScale *= 0.2f;
            yield return _dialoguePanel.transform.DOScale(_dialoguePanel.transform.localScale * 5f, _showDuration).WaitForCompletion();
        }

        public void OnArrowClick()
        {
            _interacted = true;
        }

        private void OnDestroy()
        {
            _arrowButton.transform.DOKill();
        }

    }
}