using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.UI
{
    public class StatusInfo : MonoBehaviour
    {
        [SerializeField]
        private StatusInfoChild statusInfoChild;

        public void Initialize()
        {
            SkillManager skillManager = GetComponentInParent<UIManager>().SkillManager;

            //! TODO: Spawn statuses in skill manager
            //! TODO: Set default value
        }
    }
}