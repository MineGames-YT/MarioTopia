using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
//----------------------------------------------------------------------------
    [Space(2)]
    [Header("Speed")]
    [Space(2)]
    [Range(0, 20)]
    public float moveSpeed = 6f;
    public float shiftSpeed = 3f;
    public float accelerationTime = 0.2f;
    public float decelerationTime = 0.2f;
    public ParticleSystem GrassParticleRight;
    public ParticleSystem GrassParticleLeft;
//----------------------------------------------------------------------------
    [Space(2)]
    [Header("GroundCheck")]
    [Space(2)]
    public float groundCheckDistance = 0.1f;
    public Rigidbody rb;
    public Transform groundCheck;
    //----------------------------------------------------------------------------
    [Space(2)]
    [Header("Running")]
    [Space(2)]
    [Range(0, 12)]
    public float maxMoveSpeed = 12;
    public float maxTimeRecoveryToMax = 50;
    public float sprintSpeedMultiplier = 1.5f;
    public float MaxRecoveryTime = 2f;
    public GameObject RecoveryIcon;
//----------------------------------------------------------------------------
    [Space(2)]
    [Header("KeyCodes")]
    [Space(2)]
    public KeyCode moveForwardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode shiftKey = KeyCode.LeftControl;
    //----------------------------------------------------------------------------
    [Space(2)]
    [Header("Information")]
    [Space(2)]
    public bool isSprinting;
    public bool isShifting;
    public bool OneSpeedPoison;
    public bool isSpeedPoison;
    public bool isRunning;
    public bool IsWalking;
    public float currentMoveSpeed;
    public float currentRunTime;
    public float recoveryTimer;
    public float CurrentTimerPoison;
    public Animator anim;
    public Animator animations;
    public PlayerJump playerjumpscript;
    public PlayerBubble playerbubblescript;
    public PlayerEat playerEat;
    private Vector3 targetVelocity;
    private Vector3 currentVelocity;
//----------------------------------------------------------------------------
    [Space(2)]
    [Header("Poisons")]
    [Space(2)]
    [Range(0, 5)]
    public float speedPoisonCount;
    public float MaxspeedTimerPoison;
    public Image poisonCircle;
//----------------------------------------------------------------------------
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentVelocity = Vector3.zero;
        currentMoveSpeed = moveSpeed;В
        currentRunTime = playerbubblescript.maxRunTime;
        OneSpeedPoison = true;
        CurrentTimerPoison = MaxspeedTimerPoison;
    }
    void Update()
    {
        Move();
        HandleRunning();

        if (targetVelocity == Vector3.zero)
        {
            anim.SetBool("isIdle", true);
        }
        else
        {
            anim.SetBool("isIdle", false);
        }

        if (Input.GetKey(shiftKey))
        {
            isSprinting = false;
            isShifting = true;
            anim.SetBool("isDowning", true);
        }
        else
        {
            isSprinting = true;
            isShifting = false;
            anim.SetBool("isDowning", false);
        }

        if (isSpeedPoison)
        {
            CurrentTimerPoison -= Time.deltaTime;
            poisonCircle.fillAmount = CurrentTimerPoison / MaxspeedTimerPoison;
            animations.SetBool("SpeedEffectOnBool", true);
            animations.SetBool("SpeedEffectActiveBool", true);
            if (CurrentTimerPoison <= MaxspeedTimerPoison && OneSpeedPoison)
            {
                OneSpeedPoison = false;
            }
            if (CurrentTimerPoison <= 20)
            {
                animations.SetBool("SpeedEffectFoneBool", true);
            }

            if (CurrentTimerPoison <= 0)
            {
                animations.SetBool("SpeedEffectOnBool", false);
                animations.SetBool("SpeedEffectActiveBool", false);
                animations.SetBool("SpeedEffectFoneBool", false);
                currentMoveSpeed = moveSpeed;
                OneSpeedPoison = true;
                CurrentTimerPoison = MaxspeedTimerPoison;
                isSpeedPoison = false;
            }
        }
    }
    void Move()
    {
        targetVelocity = Vector3.zero;
        if (Input.GetKey(moveRightKey)) targetVelocity += transform.forward;
        if (Input.GetKey(moveLeftKey)) targetVelocity -= transform.forward;
        if (Input.GetKey(moveForwardKey)) targetVelocity -= transform.right;
        if (Input.GetKey(moveBackwardKey)) targetVelocity += transform.right;

        if (targetVelocity != Vector3.zero)
        {
            targetVelocity.Normalize();
            // ���� ����� �������� ���� ��������, ���������� ��������
            if (!isSpeedPoison)
            {
                currentMoveSpeed = moveSpeed; // ���������� �� ��������� ��������
            }
            // ���������, ������������ �� ������� ����
            if (isRunning && currentRunTime > 0)
            {
                currentMoveSpeed = moveSpeed + sprintSpeedMultiplier; // ����������� �������� ����

                // ������������ ������������ ��������
                if (currentMoveSpeed > maxMoveSpeed)
                {
                    currentMoveSpeed = maxMoveSpeed;
                }
            }
            else if (isShifting) // ���� ����� ���������, ������������� �������� �����
            {
                currentMoveSpeed = shiftSpeed; // ������������� �������� ��� ����������
            }
            else
            {
                // ���� ������� ���� �� ������������, ���������� �������� �� ��������
                currentMoveSpeed = moveSpeed;
            }
            // ��������� ������ ����� ��������
            if (CurrentTimerPoison <= MaxspeedTimerPoison && !OneSpeedPoison)
            {
                currentMoveSpeed += speedPoisonCount; // ����������� �������� �� ����������� �����
            }

            targetVelocity *= currentMoveSpeed;
        }
        else
        {
            // ���� ��� ��������, ���������� �������� �� ��������
            currentMoveSpeed = moveSpeed; // ����� � �������� ��������
        }

        if (targetVelocity != Vector3.zero)
        {
            IsWalking = true;
            if (!anim.GetBool("isJumping") && !anim.GetBool("isDownJumping"))
            {
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
            IsWalking = false;
        }

        float accelerationRate = targetVelocity.magnitude > currentVelocity.magnitude ? accelerationTime : decelerationTime;
        currentVelocity = Vector3.Lerp(currentVelocity, targetVelocity, Time.deltaTime / accelerationRate);

        rb.MovePosition(rb.position + currentVelocity * Time.deltaTime);
    }
    private void HandleRunning()
    {
        if (currentVelocity.magnitude > 0 || currentVelocity.magnitude < 0)
        {
            if (Input.GetKey(sprintKey) && targetVelocity != Vector3.zero && isSprinting)
            {
                isRunning = true;
                currentRunTime -= Time.deltaTime;
                recoveryTimer = 0f;

                if (currentRunTime < 0)
                {
                    currentRunTime = 0;
                }
            }
            else
            {
                isRunning = false;

                if (currentRunTime >= 0 || currentRunTime <= 0)
                {
                    if (recoveryTimer >= 2f && playerEat.isReloadEnergy)
                    {
                        currentRunTime += Time.deltaTime * (playerbubblescript.maxRunTime / maxTimeRecoveryToMax);
                        currentRunTime = Mathf.Clamp(currentRunTime, 0, playerbubblescript.maxRunTime);
                        recoveryTimer = 2f;
                    }
                    else if (currentRunTime < playerbubblescript.maxRunTime)
                    {
                        recoveryTimer += Time.deltaTime;

                        if (recoveryTimer >= 2)
                        {
                            recoveryTimer = 2;
                        }
                    }
                }
            }
        }
        else
        {
            isRunning = false;
        }

        if (currentRunTime >= playerbubblescript.maxRunTime)
        {
            recoveryTimer = 0;
        }
    }
    public void ParticleCallLeft()
    {
        GrassParticleLeft.Play();
    }
    public void ParticleCallRight()
    {
        GrassParticleRight.Play();
    }
    private void OnCollisionStay(Collision groundCheck)
    {  
        if (groundCheck.gameObject.CompareTag("Grass"))
        {
            GrassParticleLeft.startColor = new Color(0.35f, 0.12f, 0f);
            GrassParticleRight.startColor = new Color(0.35f, 0.12f, 0f);
        }
        if (groundCheck.gameObject.CompareTag("Dirt"))
        {
            GrassParticleLeft.startColor = new Color(0f, 1, 0f);
            GrassParticleRight.startColor = new Color(0f, 1, 0f);
        }
        if (groundCheck.gameObject.CompareTag("Stone"))
        {
            GrassParticleLeft.startColor = new Color(0.5f, 0.5f, 0.5f);
            GrassParticleRight.startColor = new Color(0.5f, 0.5f, 0.5f);
        }
        if (groundCheck.gameObject.CompareTag("Sand"))
        {
            GrassParticleLeft.startColor = new Color(1, 1, 0f);
            GrassParticleRight.startColor = new Color(1, 1, 0f);
        }
    }
}