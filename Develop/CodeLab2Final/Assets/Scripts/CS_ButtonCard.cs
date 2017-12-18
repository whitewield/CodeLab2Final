using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_ButtonCard : CS_Button {
	[SerializeField] CardType myType;
	[SerializeField] CS_DeckManager myDeckManager;

	protected override void Awake () {
		base.Awake ();

		if (myDeckManager == null)
			myDeckManager = GameObject.Find (Constants.NAME_PLAYER_DECK_MANAGER).GetComponent<CS_DeckManager> ();
	}

	public override void OnMouseDown () {
		myButtonSpriteRenderer.color = myPressedColor;
		isMouseDown = true;
//		onClickEvent.Invoke ();

		myDeckManager.AddCard (myType);
	}
}
