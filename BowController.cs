using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject arrowPrefab; // Префаб стрелы
    public Transform shootPoint; // Точка, откуда будет вылетать стрела
    public float maxChargeTime = 2f; // Максимальное время зарядки
    public float minArrowSpeed = 10f; // Минимальная скорость стрелы
    public float maxArrowSpeed = 30f; // Максимальная скорость стрелы
    public float arrowLifeTime = 5f; // Время жизни стрелы
    public float reloadTime = 1f; // Время перезарядки после выстрела

    public Animator animator;
    public bool isCharging = false;
    public float chargeStartTime;
    public bool canShoot = true;
    public PlayerEnergy playerEnergy;
    public float EnergySpendAttack1;

    private void Start()
    {
        isCharging = false;
        chargeStartTime = 0;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1) && canShoot && playerEnergy.isAttacking)
        {
            StartCharging();
        }

        if (Input.GetMouseButtonUp(1) && isCharging && playerEnergy.isAttacking)
        {
            playerEnergy.recoveryTimer = 1;
            playerEnergy.EnergyMinus = EnergySpendAttack1;
            playerEnergy.SpendEnergy();
            ShootArrow();
        }
    }

    private void StartCharging()
    {
        isCharging = true;
        chargeStartTime = Time.time;
        animator.SetBool("Charge", true); // Запускаем анимацию натягивания тетивы
    }

    private void ShootArrow()
    {
        isCharging = false;
        canShoot = false;

        float chargeDuration = Time.time - chargeStartTime;
        float speed = Mathf.Lerp(minArrowSpeed, maxArrowSpeed, chargeDuration / maxChargeTime);

        // Создаем стрелу и настраиваем ее ориентацию
        GameObject arrow = Instantiate(arrowPrefab, shootPoint.position, shootPoint.rotation);

        // Получаем Rigidbody стрелы и задаем скорость
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();
        arrowRb.linearVelocity = shootPoint.forward * speed;

        Destroy(arrow, arrowLifeTime); // Уничтожаем стрелу через заданное время

        animator.SetBool("Charge", false); // Запускаем анимацию натягивания тетивы

        Invoke("ResetShooting", reloadTime); // Перезарядка
    }

    private void ResetShooting()
    {
        canShoot = true;
    }
}