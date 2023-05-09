using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skill Data", order = 1)]
    public class SkillData : ScriptableObject
    {
        public Sprite skillIcon;
        public string skillName;
        public string skillDescription;
        public int skillManaCost;
        public float skillCoolDown;

        //! skillEffect.. Maybe particle?
        public string skillEffect;

        public enum skillType
        {
            None,
            Skill,
            Talent
        }
        public skillType SkillType = skillType.None;

        [SerializeField] private bool isCooldown = false;

        public IEnumerator CoolDown(float cdValue)
        {
            Debug.Log($"Log [SkillData]: Entering CoolDown Coroutine");
            isCooldown = true;
            yield return new WaitForSeconds(skillCoolDown);
            isCooldown = false;
        }

        public bool IsCoolDown => isCooldown;
    }
}