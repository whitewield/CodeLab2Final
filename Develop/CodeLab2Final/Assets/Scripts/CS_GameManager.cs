using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_GameManager : MonoBehaviour {
	
	private static CS_GameManager instance = null;
	public static CS_GameManager Instance {
		get { 
			return instance;
		}
	}

	[SerializeField] Transform[] myField_Left_Cards;
	[SerializeField] Transform myField_Left_Deck;
	[SerializeField] Transform[] myField_Right_Cards;
	[SerializeField] Transform myField_Right_Deck;

	[SerializeField] GameObject myTeamManagerPrefab;
	private List<CS_TeamManager> myTeamManagers = new List<CS_TeamManager> ();
	[SerializeField] GameObject myAIDeckManagerPrefab;
	[SerializeField] CS_DeckManager[] myDeckManagers = new CS_DeckManager[2];

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

		//create 2 team manager
		for (int i = 0; i < 2; i++) {
			GameObject t_teamObject = Instantiate (myTeamManagerPrefab, this.transform) as GameObject;
			t_teamObject.transform.position = Vector3.zero;
			myTeamManagers.Add (t_teamObject.GetComponent<CS_TeamManager> ());
		}

		myDeckManagers [0] = GameObject.Find (Constants.NAME_PLAYER_DECK_MANAGER).GetComponent<CS_DeckManager> ();

		myTeamManagers [0].Init (myDeckManagers [0], myField_Left_Cards, myField_Left_Deck);

		myDeckManagers [1] = Instantiate (myAIDeckManagerPrefab, Vector3.zero, Quaternion.identity).GetComponent<CS_DeckManager> ();
		((CS_AIDeckManager)myDeckManagers [1]).Generate_Deck ();

		myTeamManagers [1].Init (myDeckManagers [1], myField_Right_Cards, myField_Right_Deck);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public CS_TeamManager GetOpponentTeamManager (CS_TeamManager g_teamManager) {
		return myTeamManagers [1 - myTeamManagers.IndexOf (g_teamManager)];
	}
}
