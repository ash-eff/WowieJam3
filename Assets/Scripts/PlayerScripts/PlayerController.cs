using System;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public bool clampPlayer = true;
    public LayerMask enemyLayer;
    public float punchReach = 1f;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 7f;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private GameObject punchTrigger;
    
    [SerializeField] private float rateOfAttack;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackResetTime = 4f;

    private Vector2 velocity = Vector2.zero;
    private CameraController cam;
    private float lastAttack = 0;
    private float lastPunch = 0;
    public int punchNumber = 0;
    public int MaxPunchesAvailable = 2;

    private float attackResetTimer = 0f;
    
    private bool facingRight = true;
    private bool canMove = true;
    private bool canAttack = true;
    private Vector2 movePos;
    private Vector2 facingDirection;

    private float currentSpeed;
    private PlayerInputs playerInputs;
    private static readonly int PunchTrigger = Animator.StringToHash("Punch");
    private static readonly int UpperCutTrigger = Animator.StringToHash("UpperCut");
    private static readonly int SpinKickTrigger = Animator.StringToHash("Hadouken");
    //private static readonly int HadoukenTrigger = Animator.StringToHash("Hadouken");
    
    private void OnEnable()
    {
        playerInputs.Enable();
    }

    private void OnDisable()
    {
        playerInputs.Disable();
    }
    
    private void Awake()
    {
        currentSpeed = speed;
        playerInputs = new PlayerInputs();
        playerInputs.Player.Move.performed += cxt => SetMovement(cxt.ReadValue<Vector2>());
        playerInputs.Player.Move.canceled += cxt => ResetMovement();
        playerInputs.Player.XPunch.performed += cxt => XPunch();
        playerInputs.Player.YPunch.performed += cxt => SpecialOne();
        playerInputs.Player.BPunch.performed += cxt => SpecialTwo();
        playerInputs.Player.JumpKick.performed += cxt => JumpKick();
        cam = FindObjectOfType<CameraController>();
    }

    private void Update()
    {
        //canMove = !(Time.time < attackCooldown + lastPunch);
        
        if (canAttack)
            currentSpeed = speed;
        else
            currentSpeed = 0;

        var dir = velocity.normalized;
        if (dir.x > 0)
            facingRight = true;
        else if(dir.x < 0 )
            facingRight = false;

        if (attackResetTimer > 0)
            attackResetTimer -= Time.deltaTime;
        else
        {
            attackResetTimer = 0;
            punchNumber = 0;
        }

        if(canMove)
            Flip();
    }

    private void FixedUpdate()
    {
        movePos = rb2d.position + velocity * (currentSpeed * Time.fixedDeltaTime);

        movePos.x = Mathf.Clamp(movePos.x, cam.GetMinXBounds, cam.GetMaxXBounds);
        movePos.y = Mathf.Clamp(movePos.y, cam.GetMinYBounds, cam.GetMaxYBounds);
        
        rb2d.MovePosition(movePos);
    }

    private void Flip()
    {
        playerSprite.transform.localScale = facingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        facingDirection = new Vector2(playerSprite.transform.localScale.x, 0);
    }
    
    private void SetMovement(Vector2 movement) => velocity = movement;
    private void ResetMovement() => velocity = Vector2.zero;

    public void CanAttack()
    {
        canAttack = true;
    }
    
    private void XPunch()
    {
        if (canAttack)
        {
            canAttack = false;
            attackResetTimer = attackResetTime;

            punchNumber++;
            if (punchNumber > MaxPunchesAvailable)
                punchNumber = 1;

            RaycastHit2D hit = Physics2D.Raycast(transform.position, facingDirection , punchReach, enemyLayer);
            
            
            if (hit)
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log(hit.collider);
                    hit.collider.GetComponent<EnemyController>().TakeDamage(1); 
                }
            }

            Debug.DrawRay(transform.position, facingDirection * punchReach, Color.green, .15f);
            
            switch (punchNumber)
            {
                //case 3:
                //anim.SetTrigger(UpperCutTrigger);
                //break;

                // case 6:
                //anim.SetTrigger(SpinKickTrigger);
                //break;

                default:
                    anim.SetTrigger(PunchTrigger);
                    break;
            }
        }
    }

    private void JumpKick()
    {
        // stop movement and attacking
        // jump either up and kick
        // oir to the direction the player presses on x axis and kick
        
       // if (Time.time > rateOfAttack + lastAttack)
       // {
       //     anim.SetTrigger(HadoukenTrigger);
//
       //     lastAttack = Time.time;
       // }
    }

   private void SpecialOne()
   {
       // if combo bar is filled 
       
       // stop movement and fighting and perform ability
       
       Debug.Log("Performing Special One");
   }

   private void SpecialTwo()
   {
        // if combo bar is filled 
        
        // stop movement and fight and perform ability
        
        Debug.Log("Performing Special Two");
   }

   public void HitEnemy()
   {
       Debug.Log("Hit an enemy");
   }

   public void ActivatePunchTrigger()
   {
       punchTrigger.SetActive(true);
   }

   public void DeactivatePunchTrigger()
   {
       punchTrigger.SetActive(false);
   }
}
