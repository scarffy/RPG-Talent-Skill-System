using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public class SkillHUDList : MonoBehaviour
    {
        private List<SkillHudInfo> SkillInfoList = new List<SkillHudInfo>();

        private void Awake()
        {
            if (SkillInfoList.Count == 0)
            {
                foreach (Transform child in transform)
                {
                    SkillHudInfo info = child.GetComponent<SkillHudInfo>();
                    SkillInfoList.Add(info);
                }
            }
        }

        public void Initialize()
        {
            if (SkillInfoList != null)
            {
                for (int i = 0; i < UIManager.Instance.SkillManager.SkillList.Count; i++)
                {
                    SkillInfoList[i].SetContent(UIManager.Instance.SkillManager.SkillList[i].skillName);
                }
            }
        }
    }
}