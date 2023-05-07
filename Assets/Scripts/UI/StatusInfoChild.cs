using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace RPG.UI
{
    public class StatusInfoChild : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI statusText;
        [SerializeField]
        private TextMeshProUGUI valueText;
        [SerializeField]
        private Button addButton;
        [SerializeField]
        private Button minusButton;

        private void Start()
        {
            addButton.onClick.AddListener (()=> AddValue());
            minusButton.onClick.AddListener(() => MinusValue());
        }

        public void SetValue(string statusString, string valueString)
        {
            statusText.text = statusString;
            valueText.text = valueString;
        }

        /// <summary>
        /// We can add this feature in future
        /// </summary>
        private void AddValue()
        {
        }

        /// <summary>
        /// We can add this feature in future
        /// </summary>
        private void MinusValue()
        {
        }
    }
}