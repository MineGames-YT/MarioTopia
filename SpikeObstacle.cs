using UnityEngine;

public class SpikeObstacle : MonoBehaviour
{
    public int damageAmount = 10; // Количество урона, которое будет нанесено

    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, является ли объект игроком
        if (other.CompareTag("Player"))
        {
            // Получаем компонент здоровья у игрока
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Наносим урон
            }
        }
    }
}