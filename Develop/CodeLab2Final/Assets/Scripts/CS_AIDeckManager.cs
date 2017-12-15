using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_AIDeckManager : CS_DeckManager {
	// Use this for initialization
	public void Generate_Deck(){
		//Create a Shuffle Deck to draw card 
		List<GameObject> shuffleDeck = new List<GameObject>();
		for(int i= 0;i<myBank.myCards.Length;i++){
			shuffleDeck.Add(myBank.myCards[i].myPrefab);
		}

		//Create a flag to keep track of which card is drawn
		int flag = shuffleDeck.Count;

		//Draw card for as many times as decksize 
		for(int i =0; i<DeckSize;i++){
			int rnd = Random.Range(0,flag);
			myDeck.Add(shuffleDeck[rnd]);

			//Shift the card from deck to the flag location 
			GameObject tempObj = shuffleDeck[rnd];
			shuffleDeck[rnd] = shuffleDeck[flag - 1];
			shuffleDeck[flag - 1] = tempObj;
			flag--;

			//Reset the flag if all the card in shuffldeck has been drawn
			if(flag == 0){
				flag = shuffleDeck.Count;
			}
		}
	}

}
