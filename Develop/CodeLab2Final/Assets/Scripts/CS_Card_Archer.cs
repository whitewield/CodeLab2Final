using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Card_Archer : CS_BaseCard {

	public override void Action () {
		CS_TeamManager t_opponentTeam = CS_GameManager.Instance.GetOpponentTeamManager (myTeamManager);
		if (t_opponentTeam == null)
			return;

		int t_enemyCount = t_opponentTeam.GetBattleCardsCount ();
		if (t_enemyCount == 0)
			return;

		//get a random enemy
		int t_targetIndex = Random.Range (0, t_enemyCount);
		t_opponentTeam.TakeDamage (t_targetIndex, myCurrentAttributes.DMG, myCurrentAttributes.ACC);
	}
}
