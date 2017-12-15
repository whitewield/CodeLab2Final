using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_BaseCard : MonoBehaviour {
	[SerializeField] SO_CardInfo myCardInfo;
	[SerializeField] CardAttributes myCurrentAttributes;
	private int myCurrentHP;
	private float myNextActionTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if current time is bigger than my next action time
		if (myNextActionTime > Time.timeSinceLevelLoad) {
			myNextActionTime += myCurrentAttributes.CD; // update the next action time
			Action (); // take action
		}
	}

	public void Init () {
		myCurrentAttributes = myCardInfo.myAttributes;
		myCurrentHP = myCurrentAttributes.HP;
		myNextActionTime = myCurrentAttributes.CD + Time.timeSinceLevelLoad;
	}

	public virtual void Action () {
		
	}

	public virtual void TakeDamage (int g_damage) {
		myCurrentHP -= g_damage;
		if (myCurrentHP <= 0) {
			// check if dead
			myCurrentHP = 0;
			Destroy (this.gameObject);
		}
	}

}
