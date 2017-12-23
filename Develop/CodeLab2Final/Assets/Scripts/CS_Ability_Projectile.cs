using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Ability_Projectile : CS_Ability {
	[SerializeField] protected AnimationCurve myHeightOverTime;
	private float myProcess;
	private float myTimeMultiplier;
	private Vector3 myStartPos;
	private Vector3 myEndPos;

	// Use this for initialization
//	void Start () {
//		
//	}

	public void InitCurve (Vector3 g_startPos, Vector3 g_endPos) {
		myTimeMultiplier = 1 / myDuration;
		myProcess = 0;
		myStartPos = g_startPos;
		myEndPos = g_endPos;
		this.transform.position = g_startPos;
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();

		myProcess += Time.deltaTime * myTimeMultiplier;

		Vector3 t_pos = myStartPos + (myEndPos - myStartPos) * myProcess;
		t_pos.y = myHeightOverTime.Evaluate (myProcess) * Global.Constants.HEIGHT_ABILITY;

		//rotate arrow

		Vector3 t_direction = t_pos - this.transform.position;
		if (t_direction.sqrMagnitude != 0)
			this.transform.right = t_direction;

		this.transform.position = t_pos;
	}
}
