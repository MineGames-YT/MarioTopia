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


    public float strikeRadius = 10f; // ������ �����
    public float pushForce = 10f; // ���� ������������

    public void Strike()
    {
        isColliders = false;
        // �������� ��� ���������� � ������� �����
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, strikeRadius);

        foreach (Collider collider in hitColliders)
        {
            // ���������, �������� �� ������ ������
            if (collider.CompareTag("Enemy")) // ���������, ��� � ����� ������ ���������� ��� "Enemy"
            {
                Rigidbody enemyRigidbody = collider.GetComponent<Rigidbody>();
                NavMeshAgent NavMeshEnemy = collider.GetComponent<NavMeshAgent>();

                if (NavMeshEnemy != null)
                {
                    NavMeshEnemy.speed = 1.5f;
                }

                if (enemyRigidbody != null)
                {

                    // ��������� ����������� �� ������ � �����
                    Vector3 direction = (collider.transform.position - transform.position).normalized;
                    direction.Normalize(); // ����������� ������ �����������

                    // ��������� ���� ������������
                    enemyRigidbody.AddForce(direction * pushForce, ForceMode.Impulse);
                }
            }
        }
    }
}
