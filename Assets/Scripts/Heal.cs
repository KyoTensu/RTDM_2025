using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Heal : MonoBehaviour
{
    protected List<IArmyElement> m_ArmyElements = new List<IArmyElement>();
    
    public void HealArmy()
    {
        m_ArmyElements.ForEach(element => element.Health = 40);
    }
}
