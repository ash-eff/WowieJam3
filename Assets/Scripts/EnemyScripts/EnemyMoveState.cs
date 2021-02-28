using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ash.MyUtils;
using Ash.StateMachine;
using UnityEngine;

public class EnemyMoveState : State<EnemyController>
{
    private float timer;
    private Vector3 dir;
    
    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("MOVE");
        timer = 1.5f;
        dir = MyUtils.GetVectorFromAngle(Random.Range(0, 360f));
    }

    public override void ExitState(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            if (Random.value > .1f)
            {
                timer = Random.Range(1f, 2f);
                dir = MyUtils.GetVectorFromAngle(Random.Range(0, 360f));
            }
            else
            {
                enemy.stateMachine.ChangeState(enemy.enemyIdleState);
            }
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
