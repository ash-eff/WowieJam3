using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ash.MyUtils;
using Ash.StateMachine;
using UnityEngine;

public class EnemyRetreatState : State<EnemyController>
{
    private float timer;
    private Vector3 dir;
    
    public override void EnterState(EnemyController enemy)
    {
        enemy.attackCollider.enabled = false;
        Debug.Log("RETREAT");
        timer = 1.5f;
        dir = -(enemy.player.transform.position - enemy.transform.position).normalized;
    }

    public override void ExitState(EnemyController enemy)
    {
        enemy.attackCollider.enabled = true;
    }

    public override void UpdateState(EnemyController enemy)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            enemy.stateMachine.ChangeState(enemy.enemyIdleState);
        }
    }

    public override void FixedUpdateState(EnemyController enemy)
    {
        var movePos = (Vector3)enemy.rb2d.position + dir * (3 * Time.fixedDeltaTime);

        movePos.x = Mathf.Clamp(movePos.x, enemy.cam.GetMinXBounds, enemy.cam.GetMaxXBounds);
        movePos.y = Mathf.Clamp(movePos.y, enemy.cam.GetMinYBounds, enemy.cam.GetMaxYBounds);
        
        enemy.rb2d.MovePosition(movePos);
    }
}
