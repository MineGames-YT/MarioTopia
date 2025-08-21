using UnityEngine;

public class WaterWeapon : MonoBehaviour
{
    public GameObject waterBallPrefab; // ������ ������� ����
    public float shootForce = 10f; // ���� ��������
    public GameObject giantExplosionPrefab; // ������ ����������� ������
    public float maxTimerReload = 2.3f;
    public float currentTimerReload;
    public bool isReload;

    public float maxAmmo = 120;
    public float currentAmmo;

    public float WaitTimeToAttack;
    public float currentWaitTimeToAttack;

    public Animator anim;
    public PlayerEnergy playerEnergy;
    public float EnergySpendAttack1;
    private void Start()
    {
        currentAmmo = maxAmmo / 2;
    }

    void Update()
    {
        // �������� ������� ������
        if (Input.GetMouseButton(0) && currentAmmo != 0 && !isReload && playerEnergy.isAttacking && currentWaitTimeToAttack <= 0)
        {
            currentWaitTimeToAttack = WaitTimeToAttack;
            playerEnergy.recoveryTimer = 1;
            playerEnergy.EnergyMinus = EnergySpendAttack1;
            playerEnergy.SpendEnergy();
            ShootWaterBall();
        }

        if (Input.GetMouseButton(0) && currentWaitTimeToAttack > 0)
        {
            anim.SetBool("WaterWeaponAttackBool", false);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("WaterWeaponAttackBool", false);
        }

        if(currentAmmo <= 0 )
            anim.SetBool("WaterWeaponAttackBool", false);

        Reload();

        if (currentWaitTimeToAttack <= WaitTimeToAttack && currentWaitTimeToAttack > 0)
        {
            currentWaitTimeToAttack -= Time.deltaTime;
            if (currentWaitTimeToAttack <= 0)
            {
                currentWaitTimeToAttack = 0;
            }
        }

        if (isReload == true)
        {
            currentTimerReload -= Time.deltaTime;
            if (currentTimerReload <= 0)
            {
                isReload = false;
            }
        }
    }

    void ShootWaterBall()
    {
        
        anim.SetBool("WaterWeaponReloadBool", false);
        anim.SetBool("WaterWeaponAttackBool", true);
        currentAmmo -= 1;
        if (currentAmmo <= 0)
        {
            currentAmmo = 0;
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            isReload = true;
            currentTimerReload = maxTimerReload;
            currentAmmo = maxAmmo;
            anim.SetBool("WaterWeaponReloadBool", true);
        }

        if (Input.GetKeyDown(KeyCode.R) && currentAmmo != maxAmmo)
        {
            currentAmmo = maxAmmo;
            anim.SetBool("WaterWeaponReloadBool", false);
        }
    }
}
