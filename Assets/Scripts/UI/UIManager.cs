using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

namespace RPG.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        [SerializeField] private Tooltips tooltips;


        [Header("Status")]
        [SerializeField]
        private SkillManager skillManager;
        [SerializeField]
        private StatusInfo statusInfoUI;

        [SerializeField]
        private Image currentHPImage;
        [SerializeField]
        private Image maxHPImage;
        [SerializeField]
        private TextMeshProUGUI hpText;
        [SerializeField]
        private Image currentManaImage;
        [SerializeField]
        private Image maxManaImage;
        [SerializeField]
        private TextMeshProUGUI manaText;

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
            else
                Destroy(gameObject);

            if (skillManager == null)
                skillManager = GameObject.Find("Manager").GetComponent<SkillManager>();

            skillManager.OnInitialize += SetupInitialUI;
            skillManager.OnStatChange += StatChange;
        }

        private void SetupInitialUI()
        {
            hpText.text = skillManager.stat.currentHP.ToString() + "/" + skillManager.stat.maxHP.ToString();
            manaText.text = skillManager.stat.currentMana.ToString() + "/" + skillManager.stat.maxMana.ToString();

            currentHPImage.fillAmount = (float)skillManager.stat.currentHP / (float)skillManager.stat.maxHP;
            currentManaImage.fillAmount = (float)skillManager.stat.currentMana / (float)skillManager.stat.maxMana;

            maxHPImage.rectTransform.sizeDelta = new Vector2(skillManager.stat.maxHP, 50);
            maxManaImage.rectTransform.sizeDelta = new Vector2(skillManager.stat.maxMana, 50);

            statusInfoUI.Initialize();
        }

        public void ShowTooltip(string value) => tooltips.ShowTooltip(value);

        public void HideTooltip() => tooltips.HideTooltip();

        private void StatChange()
        {
            throw new NotImplementedException();
        }


        public SkillManager SkillManager => skillManager;
    }
}