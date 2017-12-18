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

		//damage the first enemy
		t_opponentTeam.TakeDamage (0, myCurrentAttributes.DMG, myCurrentAttributes.ACC);

		//play particle
		ParticleSystem t_particle =
			PoppingParticlePoolManager.Instance.GetFromPool (Hang.PoppingParticlePool.ParticleType.MageAttack);
		t_particle.transform.position = this.transform.position;
		t_particle.Play();
	}
}
