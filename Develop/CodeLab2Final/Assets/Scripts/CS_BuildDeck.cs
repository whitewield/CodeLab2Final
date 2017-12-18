using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Global;

public class CS_BuildDeck : MonoBehaviour {
	[SerializeField] TextMesh myText_Count;
	[SerializeField] CS_DeckManager myDeckManager;

	void Awake () {
		if (myDeckManager == null)
			myDeckManager = GameObject.Find (Constants.NAME_PLAYER_DECK_MANAGER).GetComponent<CS_DeckManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		myText_Count.text = myDeckManager.GetDeckCount ().ToString ("0");
	}

	public void StartGame () {
		UnityEngine.SceneManagement.SceneManager.LoadScene ("Game");
	}
}
