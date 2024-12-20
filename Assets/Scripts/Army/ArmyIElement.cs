using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArmyElement : MonoBehaviour, IArmyElement
{
	public ArmyManager ArmyManager { get; set; }
	[SerializeField] Health m_Health;
	public float Health { get => m_Health.Value; set => m_Health.Set(value); }

	public void Die()
	{
		ArmyManager.ArmyElementHasBeenKilled(gameObject);
		Destroy(gameObject);
	}
}
