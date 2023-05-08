using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG
{
    public class SkillManager : MonoBehaviour
    {
        [Header("Stat")]
        public Stats stat;

        [Header("Skill")]
        [SerializeField] private List<SkillData> SkillDataList;

        public Action OnInitialize;
        public Action OnStatChange;

        private void Start()
        {
            Initialize();
        }

        private void Update()
        {
            //! TODO: Add error checking
            if (Input.GetKeyUp(KeyCode.Q))
            {
                TriggerSkill(SkillDataList[0]);
            }
            if (Input.GetKeyUp(KeyCode.W))
            {
                TriggerSkill(SkillDataList[1]);
            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                TriggerSkill(SkillDataList[2]);
            }
            if (Input.GetKeyUp(KeyCode.R))
            {
                TriggerSkill(SkillDataList[3]);
            }
        }

        private void Initialize()
        {
            OnInitialize?.Invoke();
        }

        private void UpdateStat()
        {
            OnStatChange?.Invoke();
        }

        private void TriggerSkill(SkillData skillData)
        {
            if (!SkillDataList.Contains(skillData))
            {
                Debug.LogError("LogError [SkillManager]: Trigger skill method doesn't contain skill data");
            }
            else if (SkillDataList.Contains(skillData))
            {
                Debug.Log($"Log [SkillManager]: Trigger skill contain skill data {skillData.skillName}");
                int index = SkillDataList.IndexOf(skillData);
                Debug.Log($"Log [SkillManager]: Index trigger is {index}");

                //! Check if we are in cooldown
                if (!CheckIfCooldown(skillData, index))
                {
                    StartCoroutine(SkillDataList[index].CoolDown(skillData.skillCoolDown));
                }
            }
        }

        private bool CheckIfCooldown(SkillData skillData, int skillIndex)
        {
            if (SkillDataList[skillIndex].IsCoolDown)
            {
                return true;
            }
            return false;
        }


        public List<SkillData> SkillList => SkillDataList;
    }
}