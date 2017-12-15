using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_DeckManager : MonoBehaviour {
	[SerializeField] protected int DeckSize;
	[SerializeField] protected SO_CardBank myBank;
	protected List<GameObject> myDeck;
	protected void Start(){
		DontDestroyOnLoad(this.gameObject);
	}
	//Add One card into deck
	protected bool AddCard(CardType cardType){
		int num = myDeck.Count;

		//If the deck has enough cards then return false
		if(num >= DeckSize){
			return false;
		}

		myDeck.Add(myBank.GetPrefab(cardType));
		return true;
	}
	//Clear the Deck
	public void ClearDeck(){
		myDeck.Clear();
	}
	//Pop out a card from the deck
	public GameObject PopCard(){
		if(IF_DeckIsEmpty()){
			return null;
		}
		GameObject card = myDeck[0];
		myDeck.RemoveAt(0);
		return card;
	}
	//Check if the deck is empty
	public bool IF_DeckIsEmpty(){
		return myDeck.Count == 0;
	}
}
