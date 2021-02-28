using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyManager : MonoBehaviour
{
    public List<EnemyController> activeEnemiesDictionary = new List<EnemyController>();
    public List<EnemyController> attackingEnemies = new List<EnemyController>();

    public GameManager gameManager;
    
    private PlayerController player;
    public UnityEvent OnAllEnemiesDead;

    private void Awake()
    {
        if (OnAllEnemiesDead == null) OnAllEnemiesDead = new UnityEvent();
        player = FindObjectOfType<PlayerController>();
    }

    public void SpawnEnemy(GameObject enemy, Vector2 spawnPos)
    {
        // instantiate
        GameObject enemyObj = Instantiate(enemy, spawnPos, Quaternion.identity);
        // add enemy to dictionary
        AddEnemyToDictionary(enemyObj.GetComponent<EnemyController>());
        enemyObj.GetComponent<EnemyController>().movePos = gameManager.currentBattleGround.GetRandomPosition;
    }

    public void AddEnemyToDictionary(EnemyController enemyController)
    {
        activeEnemiesDictionary.Add(enemyController);
    }
    
    public void SelectTwoEnemiesForQueue()
    {
        activeEnemiesDictionary[0].SetAttackingPosition(false);
        QueueEnemy(activeEnemiesDictionary[0]);
        
        activeEnemiesDictionary[1].SetAttackingPosition(true);
        QueueEnemy(activeEnemiesDictionary[1]);
    }

    public void ReplaceSomeoneInQueue(EnemyController enemyController)
    {
        var attackingFront = attackingEnemies[0].attackFront;
        DeQueueEnemy(attackingEnemies[0]);
        enemyController.SetAttackingPosition(attackingFront);
        QueueEnemy(enemyController);
    }

    private EnemyController GetAvailableEnemyForQueue()
    {
        foreach (var enemy in activeEnemiesDictionary)
        {
            if (attackingEnemies.Contains(enemy)) continue;

            return enemy;
        }

        return null;
    }
    
    public void QueueEnemy(EnemyController enemyController)
    {
        attackingEnemies.Add(enemyController);
        enemyController.isAttacking = true;
        enemyController.stateMachine.ChangeState(enemyController.enemyIdleState);
    }

    public void DeQueueEnemy(EnemyController enemyController)
    {
        attackingEnemies.Remove(enemyController);
        enemyController.isAttacking = false;
        enemyController.stateMachine.ChangeState(enemyController.enemyIdleState);
    }

    public void RemoveEnemyFromDictionary(EnemyController enemyController)
    {
        if(activeEnemiesDictionary.Contains(enemyController))
            activeEnemiesDictionary.Remove(enemyController);
        Destroy(enemyController);
    }

    public void EnemyDead(EnemyController enemyController)
    {
        RemoveEnemyFromDictionary(enemyController);
        if(activeEnemiesDictionary.Count == 0)
            OnAllEnemiesDead.Invoke();
        else
        {
            if (attackingEnemies.Contains(enemyController))
            {
                bool attackingFront = enemyController.attackFront;
                DeQueueEnemy(enemyController);
                EnemyController nextEnemy = GetAvailableEnemyForQueue();
                if (nextEnemy != null)
                {
                    nextEnemy.SetAttackingPosition(attackingFront);
                    QueueEnemy(nextEnemy);
                }

            }
        }
    }
}
