using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ash.StateMachine;
using UnityEngine;

public class EnemyAttackState : State<EnemyController>
{
    
    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("ATTACK");
        enemy.Attack();
    }

    public override void ExitState(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {
    }

    public override void FixedUpdateState(EnemyController enemy)
    {
        
    }
}
