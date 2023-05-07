using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG
{
	public class SkillManager : MonoBehaviour
	{
		public Stats stat;

        public Action OnInitialize;
        public Action OnStatChange;

        private void Start()
        {
            Initialize();
        }

		private void Initialize()
        {
            OnInitialize?.Invoke();
        }

        private void UpdateStat()
        {
            OnStatChange?.Invoke();
        }
    }
}