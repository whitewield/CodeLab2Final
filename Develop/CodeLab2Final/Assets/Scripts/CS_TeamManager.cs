using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_TeamManager : MonoBehaviour {
	private CS_BaseCard[] myBattleCards = new CS_BaseCard[Constants.NUMBER_BATTLECARDS];
	private CS_DeckManager myDeckManager;
	private Transform[] myField_Cards;
	private Transform myField_Deck;
	private bool isInitialized = false;
	// Use this for initialization
	void Start () {
		
	}

	public void Init (CS_DeckManager g_deckManager, Transform[] g_field_cards, Transform g_field_deck) {
		myDeckManager = g_deckManager;
		myField_Cards = g_field_cards;
		myField_Deck = g_field_deck;

		isInitialized = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isInitialized)
			return;
		//move card forward
		for (int i = 0; i < myBattleCards.Length - 1; i++) {
			if (myBattleCards [i] == null) {
				myBattleCards [i] = myBattleCards [i + 1];
				myBattleCards [i + 1] = null;
			}
		}

		//fill the last card
		if (myBattleCards [myBattleCards.Length - 1] == null && myDeckManager.IF_DeckIsEmpty() == false) {
			GameObject t_cardObject = Instantiate (myDeckManager.PopCard (), this.transform) as GameObject;
			t_cardObject.transform.position = myField_Deck.position;
			CS_BaseCard t_card = t_cardObject.GetComponent<CS_BaseCard> ();
			t_card.Init (this);
			myBattleCards [myBattleCards.Length - 1] = t_card;
		}

		UpdatePosition ();
	}

	private void UpdatePosition () {
		for (int i = 0; i < myBattleCards.Length; i++) {
			if (myBattleCards [i] != null) {
				myBattleCards [i].transform.position = Vector3.Lerp (
					myBattleCards [i].transform.position, 
					myField_Cards [i].position, 
					Time.deltaTime * Constants.SPEED_CARD_MOVE
				);
			}
		}
	}

	public int GetBattleCardsCount () {
		int t_count = 0;
		foreach (CS_BaseCard f_card in myBattleCards) {
			if (f_card != null) {
				t_count++;
			}
		}
		return t_count;
	}

	public void TakeDamage (int g_cardIndex, int g_damage, float g_acc) {
		myBattleCards [g_cardIndex].TakeDamage (g_damage, g_acc);
	}
		
}
