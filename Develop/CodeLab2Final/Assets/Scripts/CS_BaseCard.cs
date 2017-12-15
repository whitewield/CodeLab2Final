using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_BaseCard : MonoBehaviour {
	protected CS_TeamManager myTeamManager;
	[SerializeField] protected SO_CardInfo myCardInfo;
	[SerializeField] protected CardAttributes myCurrentAttributes;
	protected int myCurrentHP;
	protected float myNextActionTime;
	protected bool isInitialized = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!isInitialized)
			return;

		//if current time is bigger than my next action time
		if (myNextActionTime > Time.timeSinceLevelLoad) {
			myNextActionTime += myCurrentAttributes.CD; // update the next action time
			Action (); // take action
		}
	}

	public void Init (CS_TeamManager g_teamManager) {
		myTeamManager = g_teamManager;
		myCurrentAttributes = myCardInfo.myAttributes;
		myCurrentHP = myCurrentAttributes.HP;
		myNextActionTime = myCurrentAttributes.CD + Time.timeSinceLevelLoad;
	}

	public virtual void Action () {
		
	}

	public virtual void TakeDamage (int g_damage, float g_acc) {
		float t_chance = Random.Range (0f, 1f);
		if (t_chance < g_acc) {
			Debug.Log ("hit");
			myCurrentHP -= g_damage;
			if (myCurrentHP <= 0) {
				// check if dead
				myCurrentHP = 0;
				Destroy (this.gameObject);
			}
		} else {
			Debug.Log ("miss");
		}
	}

}
