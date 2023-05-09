using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public class SkillHUDList : MonoBehaviour
    {
        [SerializeField] private List<SkillHudInfo> _skillInfoList = new List<SkillHudInfo>();

        private void Awake()
        {
            if (_skillInfoList.Count == 0)
            {
                foreach (Transform child in transform)
                {
                    SkillHudInfo info = child.GetComponent<SkillHudInfo>();
                    _skillInfoList.Add(info);
                }
            }
        }

        public void Initialize()
        {
            if (_skillInfoList != null)
            {
                Debug.Log("LOG [SkillHUDList]: Initialize script");
                for (int i = 0; i < UIManager.Instance.SkillManager.SkillList.Count; i++)
                {
                    _skillInfoList[i].SetContent(UIManager.Instance.SkillManager.SkillList[i].skillName);
                    _skillInfoList[i].SetSprite(UIManager.Instance.SkillManager.SkillList[i].skillIcon);
                }
            }
        }

        public List<SkillHudInfo> skillHudInfos => _skillInfoList;
    }
}