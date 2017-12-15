using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Global {

	[System.Serializable]
	public struct CardAttributes {
		/// <summary>
		/// Hit Point.
		/// </summary>
		public int HP;

		/// <summary>
		/// Damage.
		/// </summary>
		public int DMG;

		/// <summary>
		/// Accuracy
		/// </summary>
		public float ACC;

		/// <summary>
		/// Cool Down.
		/// </summary>
		public float CD;
	}

	[System.Serializable]
	public struct CardInfo {
		public CardType myType;
		public GameObject myPrefab;
	}

	public enum CardType {
		Knight,
		Mage,
		Archer
	}

	public class Constants {
		public const int NUMBER_BATTLECARDS = 3;
	}
}
