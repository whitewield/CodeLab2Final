using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


public class CS_Button : MonoBehaviour {

//	[SerializeField] bool doPositionChange = false;
	[SerializeField] protected SpriteRenderer myButtonSpriteRenderer;
	protected Color myNormalColor;
	[SerializeField] protected Color myOverColor;
	[SerializeField] protected Color myPressedColor;
	protected bool isMouseDown;

	//my event
	[Serializable]
	public class PT_ButtonEvent : UnityEvent { }

	[SerializeField]
	private PT_ButtonEvent onClick = new PT_ButtonEvent();
	public PT_ButtonEvent onClickEvent { get { return onClick; } set { onClick = value; } }

	protected virtual void Awake () {
		if (myButtonSpriteRenderer == null)
			myButtonSpriteRenderer = this.GetComponent<SpriteRenderer> ();
		myNormalColor = myButtonSpriteRenderer.color;
	}

	public virtual void OnMouseDown () {
		myButtonSpriteRenderer.color = myPressedColor;
		isMouseDown = true;
		onClickEvent.Invoke ();
	}

	public void OnMouseUp () {
		isMouseDown = false;
		myButtonSpriteRenderer.color = myNormalColor;
	}

	public void OnMouseOver () {
		if (isMouseDown)
			return;
		myButtonSpriteRenderer.color = myOverColor;
	}

	public void OnMouseExit () {
		if (isMouseDown)
			return;
		myButtonSpriteRenderer.color = myNormalColor;
	}
}
///add a collider to the object as well so the OnPointerClick can work

