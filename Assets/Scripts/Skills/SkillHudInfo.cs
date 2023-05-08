using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RPG.UI
{
    public class SkillHudInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private string _contentText;

        public void SetContent(string content)
        {
            _contentText = content;
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