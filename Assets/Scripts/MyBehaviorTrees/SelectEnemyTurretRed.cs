using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class SelectEnemyTurretRed : Action
{
    IArmyElement m_ArmyElement;
    public SharedTransform target;
    public SharedFloat minRadius;
    public SharedFloat maxRadius;
    
    public override void OnAwake()
    {
        m_ArmyElement =(IArmyElement) GetComponent(typeof(IArmyElement));
    }

    public override TaskStatus OnUpdate()
    {
        if (m_ArmyElement.ArmyManager == null) return TaskStatus.Running;
        
        target.Value = m_ArmyElement.ArmyManager.GetFurthestEnemy<Turret>(transform.position, maxRadius.Value)?.transform;
        if (target.Value != null) return TaskStatus.Success;
        else return TaskStatus.Failure;
    }
}
