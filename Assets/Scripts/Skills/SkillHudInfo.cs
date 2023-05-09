using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace RPG.UI
{
    public class SkillHudInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private string _contentText;
        [SerializeField] private Image _skillSprite;
        [SerializeField] private Image _cooldownImage;
        [SerializeField] private float animationTime = 0f;

        public void SetContent(string content)
        {
            _contentText = content;
        }

        public void SetSprite(Sprite sprite)
        {
            _skillSprite.sprite = sprite;
        }

        public IEnumerator SetCoolDown(float cdValue)
        {
            Debug.Log($"LOG [SkillHudInfo]: Entering Coroutine with cd value: {cdValue}");
            animationTime = 0;
            while (animationTime < cdValue)
            {
                animationTime += Time.deltaTime;
                _cooldownImage.fillAmount = animationTime / cdValue;
                yield return null;
            }
            _cooldownImage.fillAmount = 0;
        }

        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            ShowTooltip(_contentText);
        }

        public virtual void OnPointerExit(PointerEventData eventData)
        {
            UIManager.Instance.HideTooltip();
        }

        protected void ShowTooltip(string content)
        {
            UIManager.Instance.ShowTooltip(content);
        }
    }
}