using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    public bool clampPlayer = true;
    
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private Animator anim;
    [SerializeField] private float speed = 7f;
    [SerializeField] private GameObject playerSprite;
    [SerializeField] private GameObject punchTrigger;

    [SerializeField] private float yMaxRange, yMinRange, xOffset;
    [SerializeField] private float rateOfAttack;
    [SerializeField] private float attackCooldown;
    [SerializeField] private float attackResetTime = 4f;
    
    private Vector2 velocity = Vector2.zero;
    private Camera cam;
    private float xMaxRange, xMinRange;
    private float lastAttack = 0;
    private float lastPunch = 0;
    public int punchNumber = 0;
    public int MaxPunchesAvailable = 2;

    private float attackResetTimer = 0f;
    
    private bool facingRight = true;
    private bool canMove = true;
    
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
        playerInputs = new PlayerInputs();
        playerInputs.Player.Move.performed += cxt => SetMovement(cxt.ReadValue<Vector2>());
        playerInputs.Player.Move.canceled += cxt => ResetMovement();
        playerInputs.Player.XPunch.performed += cxt => XPunch();
        playerInputs.Player.YPunch.performed += cxt => SpecialOne();
        playerInputs.Player.BPunch.performed += cxt => SpecialTwo();
        playerInputs.Player.JumpKick.performed += cxt => JumpKick();
        cam = Camera.main;
        var height = 2 * cam.orthographicSize;
        var width = height * cam.aspect;
        xMaxRange = width / 2f - xOffset;
        xMinRange = -(width / 2f - xOffset);
    }

    private void Update()
    {
        canMove = !(Time.time < attackCooldown + lastPunch);
        
       
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
        if(!canMove) return;
        
        Vector2 movePos = (Vector2) transform.position + velocity.normalized * (speed * Time.deltaTime);

        if (clampPlayer)
            movePos.x = Mathf.Clamp(movePos.x, xMinRange, xMaxRange);

        movePos.y = Mathf.Clamp(movePos.y, yMinRange, yMaxRange);

        rb2d.MovePosition(movePos);
    }

    private void Flip()
    {
        playerSprite.transform.localScale = facingRight ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
    }
    
    private void SetMovement(Vector2 movement) => velocity = movement;
    private void ResetMovement() => velocity = Vector2.zero;

    private void XPunch()
    {
        lastPunch = Time.time;
        if (Time.time > rateOfAttack + lastAttack)
        { 
            attackResetTimer = attackResetTime;
            
            punchNumber++;
            if (punchNumber > MaxPunchesAvailable)
                punchNumber = 1;

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
            
            lastAttack = Time.time;
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
