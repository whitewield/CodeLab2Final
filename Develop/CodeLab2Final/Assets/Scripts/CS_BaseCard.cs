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
	[SerializeField] GameObject myInfoDisplayPrefab;
	[SerializeField] Vector3 myInfoDisplayPostion = new Vector3 (0, -2, 0);
	protected TextMesh myTextMesh_Info;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (myCurrentAttributes.CD);

		if (!isInitialized)
			return;

//		Debug.Log (myNextActionTime + "," + Time.timeSinceLevelLoad);

		//if current time is bigger than my next action time
		if (myNextActionTime < Time.timeSinceLevelLoad) {
			myNextActionTime += myCurrentAttributes.CD; // update the next action time
			Action (); // take action
		}

	}

	public void Init (CS_TeamManager g_teamManager) {
		myTeamManager = g_teamManager;
		myCurrentAttributes = myCardInfo.myAttributes;
		myCurrentHP = myCurrentAttributes.HP;
		myNextActionTime = myCurrentAttributes.CD + Time.timeSinceLevelLoad;

		GameObject t_info = Instantiate (myInfoDisplayPrefab, this.transform) as GameObject;
		t_info.transform.localPosition = myInfoDisplayPostion;
		myTextMesh_Info = t_info.GetComponent<TextMesh> ();

		myTextMesh_Info.text = myCurrentHP.ToString ("0");

		isInitialized = true;
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

			//Show HP
			myTextMesh_Info.text = myCurrentHP.ToString ("0");

			//play particle
			ParticleSystem t_particle =
				PoppingParticlePoolManager.Instance.GetFromPool (Hang.PoppingParticlePool.ParticleType.MageHit);
			t_particle.transform.position = this.transform.position;
			t_particle.Play();
		} else {
			Debug.Log ("miss");
		}
	}

}
