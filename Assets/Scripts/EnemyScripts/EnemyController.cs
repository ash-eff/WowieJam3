using System;
using System.Collections;
using System.Collections.Generic;
using Ash.StateMachine;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public StateMachine<EnemyController> stateMachine;
    public LayerMask playerLayer;
    public Rigidbody2D rb2d;
    public GameManager gameManager;
    public Animator anim;
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private EnemyManager enemyManager;
    public bool isAttacking = false;
    public GameObject attackIndicator;
    public PlayerManager player;
    public CameraController cam;
    public Collider2D attackCollider;
    
    public TextMeshProUGUI stateText;
    public Transform target;
    public Vector2 movePos;
    private bool facingRight = true;
    private Vector2 facingDirection;
    public bool canAttack = false;
    public int health;
    public Material matWhite;
    public Material matDefault;

    public bool attackFront = false;
    
    [NonSerialized] public readonly EnemyIdleState enemyIdleState = new EnemyIdleState();
    [NonSerialized] public readonly EnemyAttackState enemyAttackState = new EnemyAttackState();
    [NonSerialized] public readonly EnemyMoveState enemyMoveState = new EnemyMoveState();
    [NonSerialized] public readonly EnemyChaseState enemyChaseState = new EnemyChaseState();
    [NonSerialized] public readonly EnemyRetreatState enemyRetreatState = new EnemyRetreatState();

    
    public UnityEvent<EnemyController> OnEnemyDeath;
    public float DistanceToPlayer => (player.transform.position - transform.position).magnitude;

    public void SetAttackingPosition(bool attackingFront)
    {
        if (attackingFront)
        {
            attackFront = true;
            target = player.front;
        }
        else
        {
            attackFront = false;
            target = player.back;
        }
    }

    private void Awake()
    {
        player = FindObjectOfType<PlayerManager>();
        enemyManager = FindObjectOfType<EnemyManager>();
        gameManager = FindObjectOfType<GameManager>();
        cam = FindObjectOfType<CameraController>();
        if (OnEnemyDeath == null) OnEnemyDeath = new UnityEvent<EnemyController>();
        OnEnemyDeath.AddListener(enemyManager.EnemyDead);
        matWhite = Resources.Load("WhiteFlash", typeof(Material)) as Material; 
        matDefault = enemySprite.material;
        stateMachine = new StateMachine<EnemyController>(this);
        stateMachine.ChangeState(enemyMoveState);
    }

    private void Update()
    {
        stateMachine.Update();
        var directionToPlayer = (player.transform.position - transform.position).normalized;
        if (directionToPlayer.x >= 0)
            facingRight = true;
        else if(directionToPlayer.x < 0 )
            facingRight = false;
        
        Flip();

        if (isAttacking)
            attackIndicator.SetActive(true);
        else
            attackIndicator.SetActive(false);

        if (stateMachine.currentState == enemyIdleState)
            stateText.text = "IDLE";
        
        if (stateMachine.currentState == enemyAttackState)
                stateText.text = "ATTACK";
        
        if (stateMachine.currentState == enemyMoveState)
            stateText.text = "MOVE";
        
        if (stateMachine.currentState == enemyChaseState)
            stateText.text = "CHASE";   
        
        if (stateMachine.currentState == enemyRetreatState)
            stateText.text = "RETREAT";  
        
    }

    private void FixedUpdate() => stateMachine.FixedUpdate();

    private void Flip()
    {
        enemySprite.transform.localScale = facingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        facingDirection = new Vector2(enemySprite.transform.localScale.x, 0);
    }

    public void TakeDamage(int damage)
    {
        if(!isAttacking)
            enemyManager.ReplaceSomeoneInQueue(this);
        
        health -= damage;
        enemySprite.material = matWhite;
        if (health <= 0)
        {
            OnEnemyDeath.Invoke(this);
            Destroy(gameObject);
        }
        Invoke("SwapMaterialToDefault", .1f);
    }
    
    private void SwapMaterialToDefault()
    {
        enemySprite.material = matDefault;
    }

    public void Attack()
    { 
        StartCoroutine(IeAttack());

        IEnumerator IeAttack()
        {
            for (int i = 0; i < 3; i++)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection , 1, playerLayer);

                if (hit)
                {
                    if (hit.collider.CompareTag("Player"))
                    {
                        hit.collider.GetComponent<PlayerManager>().TakeDamage(1); 
                    }
                }
                
                Debug.DrawRay(transform.position, facingDirection * 1, Color.red, .15f);
                
                anim.SetTrigger("Punch");
                
                yield return new WaitForSeconds(1f);

                if (Random.value > .7)
                {
                    break;
                }
            }
            
            stateMachine.ChangeState(enemyRetreatState);
        }
    }
}
