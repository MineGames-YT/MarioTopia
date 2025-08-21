using UnityEngine;
using UnityEngine.AI;

public class DeleteMolotGrass : MonoBehaviour
{
    public float timerToDelete;
    public float currentimer;
    public bool isColliders;

    private void Update()
    {
        currentimer += Time.deltaTime;

        if (currentimer >= timerToDelete)
        {
            currentimer = timerToDelete;
            Destroy(gameObject);
        }
    }


    public float strikeRadius = 10f; // Радиус удара
    public float pushForce = 10f; // Сила отталкивания

    public void Strike()
    {
        isColliders = false;
        // Получаем все коллайдеры в радиусе удара
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, strikeRadius);

        foreach (Collider collider in hitColliders)
        {
            // Проверяем, является ли объект врагом
            if (collider.CompareTag("Enemy")) // Убедитесь, что у ваших врагов установлен тег "Enemy"
            {
                Rigidbody enemyRigidbody = collider.GetComponent<Rigidbody>();
                NavMeshAgent NavMeshEnemy = collider.GetComponent<NavMeshAgent>();

                if (NavMeshEnemy != null)
                {
                    NavMeshEnemy.speed = 1.5f;
                }

                if (enemyRigidbody != null)
                {

                    // Вычисляем направление от игрока к врагу
                    Vector3 direction = (collider.transform.position - transform.position).normalized;
                    direction.Normalize(); // Нормализуем вектор направления

                    // Применяем силу отталкивания
                    enemyRigidbody.AddForce(direction * pushForce, ForceMode.Impulse);
                }
            }
        }
    }
}
