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
	public struct Card {
		public CardType myType;
		public GameObject myPrefab;
	}

	public enum CardType {
		Knight,
		Mage,
		Archer
	}

	public enum Direction {
		Forward,
		Back
	}

	public class Constants {
		public const int NUMBER_BATTLECARDS = 3;

		public const string NAME_PLAYER_DECK_MANAGER = "PlayerDeckManager";

		public const float SPEED_CARD_MOVE = 5;
	}
}
