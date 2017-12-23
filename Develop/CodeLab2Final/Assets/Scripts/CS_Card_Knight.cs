using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Global;

public class CS_Card_Knight : CS_BaseCard {

	public override void Action () {
		if (myTeamManager.GetIndex ((CS_BaseCard)this) != 0 && myTeamManager.SwapCards((CS_BaseCard)this, Direction.Forward)) {
			//if it's not the first card and successfully move forward, return

			return;
		}

		CS_TeamManager t_opponentTeam = CS_GameManager.Instance.GetOpponentTeamManager (myTeamManager);
		if (t_opponentTeam == null)
			return;

		int t_enemyCount = t_opponentTeam.GetBattleCardsCount ();
		if (t_enemyCount == 0)
			return;

		//damage the first enemy 
		CS_Ability t_ability = Instantiate (myAbilityPrefab).GetComponent<CS_Ability> ();
		t_ability.transform.position = this.transform.position;
		t_ability.Init (t_opponentTeam, 0, myCurrentAttributes.DMG, myCurrentAttributes.ACC);

//		//play particle
//		ParticleSystem t_particle =
//			PoppingParticlePoolManager.Instance.GetFromPool (Hang.PoppingParticlePool.ParticleType.MageAttack);
//		t_particle.transform.position = this.transform.position;
//		t_particle.Play();
	}
}
