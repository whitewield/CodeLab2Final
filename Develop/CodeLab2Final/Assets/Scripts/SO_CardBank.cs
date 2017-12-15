using UnityEngine;
using System.Collections;
using Global;

[CreateAssetMenu(fileName = "CardBank", menuName = "CodeLab2/CardBank", order = 1)]
public class SO_CardBank : ScriptableObject {
	public Card[] myCards;

	public Sprite GetSprite (CardType g_type) {
		foreach (Card f_info in myCards) {
			if (f_info.myType == g_type) {
				return f_info.myPrefab.GetComponent<SpriteRenderer> ().sprite;
			}
		}
		return null;
	}

	public GameObject GetPrefab (CardType g_type) {
		foreach (Card f_info in myCards) {
			if (f_info.myType == g_type) {
				return f_info.myPrefab;
			}
		}
		return null;
	}
}
