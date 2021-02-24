using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ali.Helper.UI.Dialogue
{
    public class DialogueChoice : MonoBehaviour
    {
        [SerializeField] private RectTransform _choicePanel;
        [SerializeField] private Text _choiceText;
        [SerializeField] private int _choiceIndex = 0;

        public event System.Action<int> OnClick;

        private bool _alreadyChoiced = false;

        public void OnChoiceClick()
        {
            if (_alreadyChoiced)
            {
                return;
            }
            _alreadyChoiced = true;
            Bounce();
            OnClick?.Invoke(_choiceIndex);
        }

        public void SetText(string text)
        {
            _choiceText.text = text;
        }

        public void Show(float duration,int order)
        {
            _choicePanel.localScale = Vector3.zero;
            _choicePanel.gameObject.SetActive(true);
            StartCoroutine(ShowCoroutine(duration,order));
        }
        float delay = .65f;
        private IEnumerator ShowCoroutine(float duration, int order)
        {
            yield return new WaitForSeconds(delay * (order+1)); 
            _choicePanel.localScale = 0.5f * Vector3.one;
            _choicePanel.DOScale(1, duration); 
        }

        public void Punch(float order)
        {
            _choicePanel.DOPunchScale(Vector3.one * 0.15f, .5f, 1).SetDelay(order);
        }

        public void Hide()
        {
            _choicePanel.gameObject.SetActive(false);
        }

        public void Reset()
        {
            _alreadyChoiced = false;
        }

        void Bounce()
        {
            _choicePanel.DOPunchScale(Vector3.one * 0.1f, 0.3f, 6);
        }

    }
}