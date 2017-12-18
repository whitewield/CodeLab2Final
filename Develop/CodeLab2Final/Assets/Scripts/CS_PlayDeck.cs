using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_PlayDeck : MonoBehaviour {
	[SerializeField] TextMesh myTextMesh;
	[SerializeField] int myIndex;
	private CS_DeckManager myDeckManager;
	void Start () {
		myDeckManager = CS_GameManager.Instance.GetDeckManager (myIndex);
	}

	// Update is called once per frame
	void Update () {
		myTextMesh.text = myDeckManager.GetDeckCount ().ToString ("0");
	}
}
