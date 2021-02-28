using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ash.MyUtils;
using Ash.StateMachine;
using UnityEngine;

public class EnemyChaseState : State<EnemyController>
{
    public override void EnterState(EnemyController enemy)
    {
        Debug.Log("CHASE");
    }

    public override void ExitState(EnemyController enemy)
    {
    }

    public override void UpdateState(EnemyController enemy)
    {

    }

    public override void FixedUpdateState(EnemyController enemy)
    {
        var dir = (enemy.target.position - enemy.transform.position).normalized;
        Vector2 movePos = enemy.transform.position + dir * (3 * Time.fixedDeltaTime);
        enemy.rb2d.MovePosition(movePos);
    }
}
