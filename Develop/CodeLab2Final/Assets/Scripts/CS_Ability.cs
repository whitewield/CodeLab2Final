using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Ability : MonoBehaviour {
	[SerializeField] protected float myDuration;
	protected float myEndTime;
	protected bool isInitialized;

	protected CS_TeamManager myOpponentTeam;
	protected int myTargetIndex;
	protected int myDamage;
	protected float myAcc;

	// Use this for initialization
//	void Start () {
//	}

	public void Init (CS_TeamManager g_opponentTeam, int g_targetIndex, int g_dmg, float g_acc) {
		myEndTime = myDuration + Time.timeSinceLevelLoad;
		myOpponentTeam = g_opponentTeam;
		myTargetIndex = g_targetIndex;
		myDamage = g_dmg;
		myAcc = g_acc;
		isInitialized = true;
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		if (!isInitialized)
			return;

		if (Time.timeSinceLevelLoad > myEndTime) {
			myOpponentTeam.TakeDamage (myTargetIndex, myDamage, myAcc);
			this.gameObject.SetActive (false);
			Destroy (this.gameObject);
		}
	}
}
