using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer enemySprite;

    private PlayerManager player;
    private bool facingRight = true;
    public int health;
    public Material matWhite;
    public Material matDefault;

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material; 
        matDefault = enemySprite.material;
    }

    private void Update()
    {
        var directionToPlayer = (player.transform.position - transform.position).normalized;
        if (directionToPlayer.x >= 0)
            facingRight = true;
        else if(directionToPlayer.x < 0 )
            facingRight = false;
        
        Flip();
        
        // idle enemy
        // check if this enemy should attack the player by checking the players enemy queue list
        // this list will show current enemies attacking the player
        // wait until there is an opening in the list by way of one of the enemies on the list dying or swapping states
        // move to front of back of player
        // attack
    }

    private void Flip()
    {
        enemySprite.transform.localScale = facingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        enemySprite.material = matWhite;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Invoke("SwapMaterialToDefault", .1f);
    }
    
    private void SwapMaterialToDefault()
    {
        enemySprite.material = matDefault;
    }
}
