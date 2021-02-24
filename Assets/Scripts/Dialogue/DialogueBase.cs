using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Ali.Helper.UI.Dialogue
{
    public abstract class DialogueBase : MonoBehaviour
    {
        [SerializeField] protected Text _contentText;
        [SerializeField] protected int _letterDelayFrame = 1;
        [SerializeField] protected float _showDuration = 0.3f;

        protected bool _interacted = false;
        private Coroutine _animateContentTextCo;

        public virtual void Reset()
        {
            _interacted = false;
        }

        public virtual void AnimateContentText()
        {
            if (_animateContentTextCo != null)
            {
                StopCoroutine(_animateContentTextCo);
            }
            StartCoroutine(AnimateContentTextProcess());
        }

        IEnumerator AnimateContentTextProcess()
        {
            string contentText = _contentText.text;
            _contentText.text = "";
            for (int i = 0; i < contentText.Length; i++)
            {
                _contentText.text += contentText[i];
                for (int j = 0; j < _letterDelayFrame; j++)
                {
                    yield return new WaitForEndOfFrame();
                }
            }
        }

        public virtual IEnumerator WaitForInteract()
        {
            yield return new WaitWhile(() => _interacted == false);
            yield return null;
        }

        public void SetContentText(string text)
        {
            _contentText.text = text;
        }

        public void SetContentFontSize(int fontSize)
        {
            _contentText.fontSize = fontSize;
        }
        public abstract IEnumerator Show();
        public abstract IEnumerator Hide();
    }
}