using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "Attributes", menuName = "CodeLab2/Attributes", order = 1)]
public class SO_Attributes : ScriptableObject {
	/// <summary>
	/// Hit Point.
	/// </summary>
	public int HP = 8;

	/// <summary>
	/// Damage.
	/// </summary>
	public int DMG = 2;

	/// <summary>
	/// Accuracy
	/// </summary>
	public float ACC = 0.8f;

	/// <summary>
	/// Cool Down.
	/// </summary>
	public float CD = 3;
}