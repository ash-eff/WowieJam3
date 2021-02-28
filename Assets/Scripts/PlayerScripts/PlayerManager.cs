using System;
using System.Collections;
using System.Collections.Generic;
using Ash.MyUtils;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private GameManager gameManger;
    [SerializeField] private float radiusAroundPlayer;
    [SerializeField] private SpriteRenderer playerSprite;
    public Material matWhite;
    public Material matDefault;
    public Transform front;
    public Transform back;

    public Vector2 GetAreaAroundPlayer => transform.position * radiusAroundPlayer;
    
    //public UnityEvent<BattleGround> OnEnteredBattleGrounds;
//
    private void Awake()
    {
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material; 
        matDefault = playerSprite.material;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BattleGrounds"))
        {
            BattleGround currentBG = other.GetComponent<BattleGround>();
            gameManger.EnterBattleGrounds(currentBG);
            other.GetComponent<BattleGround>().DeactiveTrigger();
        }

        if (other.CompareTag("EnemyPunchTrigger"))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage(int damage)
    {
        //health -= damage;
        playerSprite.material = matWhite;
        //if (health <= 0)
        //{
        //    OnEnemyDeath.Invoke(this);
        //    Destroy(gameObject);
        //}
        Invoke("SwapMaterialToDefault", .1f);
    }
    
    private void SwapMaterialToDefault()
    {
        playerSprite.material = matDefault;
    }
    
}
