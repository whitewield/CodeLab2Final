using UnityEngine;
using System.Collections;
using Global;

[CreateAssetMenu(fileName = "CardInfo", menuName = "CodeLab2/CardInfo", order = 1)]
public class SO_CardInfo : ScriptableObject {
	public CardAttributes myAttributes = new CardAttributes { HP = 16, DMG = 3, ACC = 0.8f, CD = 2 };
}