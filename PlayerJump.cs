using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJump : MonoBehaviour
{

    [Space(2)]
    [Header("Jump")]
    [Space(2)]
    [Range(0, 10)]
    public int maxJumps = 3;
    [Range(0, 25)]
    public float jumpForceMax = 10f;

    [Space(2)]
    [Header("GroundCheck")]
    [Space(2)]
    [Range(0, 5)]
    public float jumpCooldown = 0.3f;
    public float IsGroundTimerMax = 0.1f;
    public Vector3 groundCheckSize = new Vector3(0.7f, 0.15f, 0.7f);
    public Rigidbody rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    [Space(2)]
    [Header("KeyCodes")]
    [Space(2)]
    public KeyCode jumpKey = KeyCode.Space;

    [Space(2)]
    [Header("Poisons")]
    [Space(2)]
    public float MaxPoisonTimer;
    public Image poisonCircle;
    [Space(2)]
    [Header("Information")]
    [Space(2)]
    public bool isJumpingPoison;
    public bool OneJumpPoison;
    public bool isGrounded;
    public bool IsGroundDone;
    
    public float jumpForceCurrent;
    public int currentJumps = 0;
    public int AllJumps = 0;

    public float CurrentPoisonTimer;
    public float jumpTimer = 0f;
    public float IsGroundTimer;

    public Animator anim;
    public Animator CanvasAnim;

    public PlayerMovement player;
    void Start()
    {
        OneJumpPoison = true;
        jumpForceCurrent = jumpForceMax;
        IsGroundTimer = IsGroundTimerMax;
        rb = GetComponent<Rigidbody>();
        currentJumps = maxJumps;
        CurrentPoisonTimer = MaxPoisonTimer;
    }
    private void Update()
    {
        HandleJump();
        UpdateAnimation();
        CheckGround();

        if (isGrounded)
        {
            jumpTimer = 0;
        }

        if (isGrounded && currentJumps < maxJumps && !IsGroundDone)
        {
            currentJumps = maxJumps;
            AllJumps = 0;
            jumpTimer = 0;
        }

        if (!isGrounded && currentJumps < maxJumps && IsGroundDone)
        {
            jumpTimer -= Time.deltaTime;
            if (jumpTimer <= 0)
            {
                jumpTimer = 0;
            }
        }

        if (isGrounded)
        {
            if (IsGroundTimer > 0)
            {
                IsGroundDone = false;
            }

            IsGroundTimer -= Time.deltaTime;

            if (IsGroundTimer <= 0)
            {
                IsGroundTimer = 0;
            }
            if (IsGroundTimer <= 0)
            {
                IsGroundDone = true;
            }
        }
        if (!isGrounded)
        {
            IsGroundTimer = IsGroundTimerMax;
            if (IsGroundTimer <= 0)
            {
                IsGroundTimer = 0;
            }

        }

        if (isJumpingPoison)
        {
            CurrentPoisonTimer -= Time.deltaTime;
            poisonCircle.fillAmount = CurrentPoisonTimer / MaxPoisonTimer;
            CanvasAnim.SetBool("JumpEffectOnBool", true);
            CanvasAnim.SetBool("JumpEffectActiveBool", true);
            if (CurrentPoisonTimer <= MaxPoisonTimer && OneJumpPoison)
            {
                OneJumpPoison = false;
                Physics.gravity = new Vector3(0, -24f, 0);
                jumpForceCurrent *= 1.2f;
            }

            if (CurrentPoisonTimer <= 20)
            {
                CanvasAnim.SetBool("JumpEffectFoneBool", true);
            }

            if (CurrentPoisonTimer <= 0)
            {
                CanvasAnim.SetBool("JumpEffectOnBool", false);
                CanvasAnim.SetBool("JumpEffectActiveBool", false);
                CanvasAnim.SetBool("JumpEffectFoneBool", false);
                OneJumpPoison = true;
                Physics.gravity = new Vector3(0, -25f, 0);
                jumpForceCurrent = jumpForceMax;
                CurrentPoisonTimer = MaxPoisonTimer;
                isJumpingPoison = false;
            }
        }
    }
    private void HandleJump()
    {

        if (Input.GetKeyDown(jumpKey) && currentJumps > 0 && jumpTimer <= 0f && AllJumps <= maxJumps - 1 && IsGroundDone && player.currentRunTime > 1)
        {
            player.currentRunTime -= 0.5f;
            IsGroundDone = true;
            AllJumps += 1;
            currentJumps -= 1;
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForceCurrent, rb.linearVelocity.z);
            jumpTimer = jumpCooldown;

            if (currentJumps == 3)
            {
                CanvasAnim.Play("CurrentJumpsAnim");
            }
            if (currentJumps == 2)
            {
                CanvasAnim.Play("CurrentJumpsAnim");
            }
            if (currentJumps == 1)
            {
                CanvasAnim.Play("CurrentJumpsAnim");
            }
            if (currentJumps == 0)
            {
                CanvasAnim.Play("CurrentJumpsAnim");
            }

        }
        
    }
    private void UpdateAnimation()
    {
        if (rb.linearVelocity.y > 0.01 && !isGrounded)
        {
            anim.SetBool("isJumping", true);
            anim.SetBool("isDownJumping", false);
            anim.SetBool("isRunning", false);
        }
        else if (rb.linearVelocity.y < -0.01 && !isGrounded)
        {
            anim.SetBool("isDownJumping", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isJumping", false);
            anim.SetBool("isDownJumping", false);
        }
    }
    void CheckGround()
    {
        isGrounded = Physics.OverlapBox(groundCheck.position, groundCheckSize / 2, Quaternion.identity, groundLayer).Length > 0;
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(groundCheck.position, groundCheckSize);
    }
}
