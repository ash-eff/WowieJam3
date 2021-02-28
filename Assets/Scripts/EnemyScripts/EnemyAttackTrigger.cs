using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public EnemyController enemyController;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(enemyController.isAttacking)
            if(enemyController.stateMachine.currentState != enemyController.enemyAttackState)
                if (other.CompareTag("Player"))
                    enemyController.stateMachine.ChangeState(enemyController.enemyAttackState);

    }
}
