using UnityEngine;

public class MolotWeapon : MonoBehaviour
{
    

    public float reloadTimer = 3f;
    public float currentTimer;
    public float currentTimerHit;
    public int currentAnim;
    public Animator anim;
    public Animator animCanvas;
    public bool canShoot = true;
    public bool canShoot2 = true;
    public bool yesHit;
    public bool yesHit2;
    public PlayerCamera cameraPlayer;
    public PlayerJump jump;
    public PlayerHealth health;
    public PlayerMovement move;
    public InventoryTexts bigInv;
    public InventoryBigUI bigInvUI;
    public InventoryMiniUI miniInvUI;
    public PlayerEnergy playerEnergy;
    public float EnergySpendAttack1;
    public float EnergySpendAttack2;
    private void Start()
    {
        canShoot2 = true;
        canShoot = true;
        currentTimer = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canShoot && playerEnergy.isAttacking)
        {
            playerEnergy.recoveryTimer = 1;
            playerEnergy.EnergyMinus = EnergySpendAttack1;
            playerEnergy.SpendEnergy();
            HitMolot();
        }

        if (Input.GetMouseButtonDown(0) && canShoot2 && playerEnergy.isAttacking)
        {
            playerEnergy.recoveryTimer = 1;
            playerEnergy.EnergyMinus = EnergySpendAttack2;
            playerEnergy.SpendEnergy();
            AttackMolot();
        }

        if (yesHit)
        {
            currentTimer += Time.deltaTime;
        }

        if (yesHit2)
        {
            currentTimerHit -= Time.deltaTime;
            cameraPlayer.isRotateAllRyks = true;
            cameraPlayer.isRotateRyks = false;
        }

        if (currentTimer >= reloadTimer && yesHit)
        {
            
            cameraPlayer.minY = -75;
            cameraPlayer.maxY = 75;
            jump.enabled = true;
            health.enabled = true;
            bigInv.enabled = true;
            move.enabled = true;
            bigInvUI.enabled = true;
            miniInvUI.enabled = true;
            anim.SetBool("MolotAttack", false);
            currentTimer = 0;
            canShoot = true;
            canShoot2 = true;
            yesHit = false;
            yesHit2 = false;
            cameraPlayer.isRotate = true;
        }

        if (currentTimerHit <= 0 && yesHit2)
        {
            currentTimerHit = 0;
            currentAnim = 3;
            currentTimer = 0;
            anim.SetBool("Molot1Bool", false);
            anim.SetBool("Molot2Bool", false);
            canShoot = true;
            canShoot2 = true;
            cameraPlayer.isRotateAllRyks = false;
            cameraPlayer.isRotateRyks = false;
            cameraPlayer.isStartPos = true;
            bigInvUI.enabled = true;
            yesHit = false;
            yesHit2 = false;
        }
    }

    void HitMolot()
    {

        animCanvas.SetBool("DownSlotBool", false);
        animCanvas.SetBool("Slot1Bool", false);
        animCanvas.SetBool("Slot2Bool", false);
        animCanvas.SetBool("Slot3Bool", false);
        animCanvas.SetBool("Slot4Bool", false);
        animCanvas.SetBool("Slot5Bool", false);
        animCanvas.SetBool("Slot6Bool", false);
        cameraPlayer.RightRyka.transform.localEulerAngles = new Vector3(0f, 1.1f, 0.4f);
        cameraPlayer.RightRyka.transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
        cameraPlayer.LeftRyka.transform.localEulerAngles = new Vector3(0f, 1.1f, -0.4f);
        cameraPlayer.LeftRyka.transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
        cameraPlayer.isRotate = false;
        jump.enabled = false;
        health.enabled = false;
        bigInv.enabled = false;
        move.enabled = false;
        bigInvUI.enabled = false;
        miniInvUI.enabled = false;
        cameraPlayer.minY = -45;
        cameraPlayer.maxY = 45;
        canShoot = false;
        anim.SetBool("Molot1Bool", false);
        anim.SetBool("Molot2Bool", false);
        anim.SetBool("MolotAttack", true);
        anim.SetBool("isIdle", true);
        anim.SetBool("isRunning", false);
        anim.SetBool("isJumping", false);
        anim.SetBool("isDownJumping", false);
        yesHit = true;
        yesHit2 = false;
        canShoot2 = false;
        currentTimerHit = 1.5f;
    }

    public void AttackMolot()
    {

        animCanvas.SetBool("DownSlotBool", false);
        animCanvas.SetBool("Slot1Bool", false);
        animCanvas.SetBool("Slot2Bool", false);
        animCanvas.SetBool("Slot3Bool", false);
        animCanvas.SetBool("Slot4Bool", false);
        animCanvas.SetBool("Slot5Bool", false);
        animCanvas.SetBool("Slot6Bool", false);
        bigInvUI.enabled = false;
        currentAnim = Random.Range(0,2);
        if (currentAnim == 0)
        {
            anim.SetBool("Molot2Bool", true);
        }
        if (currentAnim == 1)
        {
            anim.SetBool("Molot1Bool", true);
        }
        cameraPlayer.isRotateAllRyks = true;
        cameraPlayer.isRotateRyks = false;
        anim.SetBool("MolotAttack", false);
        canShoot = false;
        currentTimerHit = 1.5f;
        yesHit = false;
        yesHit2 = true;
        canShoot2 = false;
    }
}
