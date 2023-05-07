using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace RPG
{
	[Serializable]
	public class Stats
	{
		public int currentLevel = 1;
		public int maxLevel = 20;

		public int currentHP = 0;
		public int maxHP = 100;
		public int currentMana = 0;
		public int maxMana = 100;

		public int maxDamage;
	}
}