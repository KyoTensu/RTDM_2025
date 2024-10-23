using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.AI;

public class ArmyManagerRed : ArmyManager
{
	[SerializeField] private Button button;
	public override void ArmyElementHasBeenKilled(GameObject go)
	{
		base.ArmyElementHasBeenKilled(go);
		if (m_ArmyElements.Count == 0)
		{
			GUIUtility.systemCopyBuffer = "0\t" +((int)Timer.Value).ToString()+"\t0\t0\t0";
		}
	}
	public void GreenArmyIsDead(string deadArmyTag)
    {
        int nDrones = 0, nTurrets = 0, health = 0;
        ComputeStatistics(ref nDrones, ref nTurrets, ref health);
		GUIUtility.systemCopyBuffer = "1\t" + ((int)Timer.Value).ToString() + "\t"+nDrones.ToString()+"\t"+nTurrets.ToString()+"\t"+health.ToString();
		
		RefreshHudDisplay(); //pour une derni�re mise � jour en cas de victoire
	}
	
	public void HealArmy()
	{
		List<IArmyElement> droneList = m_ArmyElements.FindAll(element => element is Drone);
		foreach (Drone drone in droneList)
		{
			if (drone.Health < 30)
			{
				drone.Health = drone.Health + 20;
				button.enabled = false;
			}
			else
			{
				drone.Health = 50;
			}
		}
		RefreshHudDisplay();
	}

	private void OnGUI()
	{
		if (GUI.Button(new Rect(10, Screen.height - 40, 100, 30), "Heal Army"))
		{
			HealArmy();
		}
	}
}