using UnityEngine;
using TMPro;

namespace RPG.UI
{
    public class Tooltips : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI tooltipText;
        [SerializeField] private RectTransform backgroundRectTransform;

        public void ShowTooltip(string tooltipString)
        {
            tooltipText.text = tooltipString;
            gameObject.SetActive(true);

            Vector2 backgroundSize = new Vector2(tooltipText.preferredWidth + (2 * 2f), tooltipText.preferredHeight + (2 * 2f));
            backgroundRectTransform.sizeDelta = backgroundSize;
        }

        public void HideTooltip()
        {
            gameObject.SetActive(false);
        }

        private void Update()
        {
            transform.position = Input.mousePosition;
        }
    }
}