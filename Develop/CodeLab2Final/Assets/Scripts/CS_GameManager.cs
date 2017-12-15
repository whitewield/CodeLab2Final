using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_GameManager : MonoBehaviour {
	
	private static CS_GameManager instance = null;
	public static CS_GameManager Instance {
		get { 
			return instance;
		}
	}

	[SerializeField] Transform[] myField_Left_Cards;
	[SerializeField] Transform myField_Left_Deck;
	[SerializeField] Transform[] myField_Light_Cards;
	[SerializeField] Transform myField_Light_Deck;

	void Awake () {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
		} else {
			instance = this;
		}
//		DontDestroyOnLoad(this.gameObject);
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
