using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private EnemyManager enemyManager;

    public BattleGround currentBattleGround;
    
    public void EnterBattleGrounds(BattleGround battleGround)
    {
        currentBattleGround = battleGround;
        battleGround.ActivateCam();
        StartCoroutine(IeBattleGrounds());

        IEnumerator IeBattleGrounds()
        {
            yield return new WaitForSeconds(1f);

            foreach (EnemyController enemyController in currentBattleGround.enemies)
            {
                enemyManager.SpawnEnemy(enemyController.gameObject, currentBattleGround.GetNextSpawnLocation());
                yield return new WaitForSeconds(.25f);
            }
            
            enemyManager.SelectTwoEnemiesForQueue();
        }
    }
    
    public void LeaveBattleGrounds()
    {
        currentBattleGround.DeactivateCam();
    }
}
