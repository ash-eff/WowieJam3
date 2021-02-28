using System.Collections;
using System.Collections.Generic;
using Ash.StateMachine;
using UnityEngine;

public class EnemyIdleState : State<EnemyController>
{
    private float idleTimer;
    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("IDLE");
        idleTimer = Random.Range(.75f, 1.5f);
    }

    public override void ExitState(EnemyController enemy)
    {
        //enemy.attackCollider.enabled = true;
    }

    public override void UpdateState(EnemyController enemy)
    {
        idleTimer -= Time.deltaTime;
        if(idleTimer < 0)
            if(!enemy.isAttacking)
                enemy.stateMachine.ChangeState(enemy.enemyMoveState);
            else
                enemy.stateMachine.ChangeState(enemy.enemyChaseState);
    }

    public override void FixedUpdateState(EnemyController enemy)
    {
    }
}
