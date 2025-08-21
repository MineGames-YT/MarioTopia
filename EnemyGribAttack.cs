using UnityEngine;
using UnityEngine.AI;

public class EnemyGribAttack : MonoBehaviour
{
    public CapsuleCollider colliderDieEnemy;
    public CapsuleCollider colliderEnemyCapsule;
    public BoxCollider colliderEnemyBox;

    public NavMeshAgent NavMeshObject;
    public EnemyAI AIscript;

    public GameObject ObjectGrib;


    public MeshFilter MeshCurrent;
    public Mesh MeshGribDie;

    public float MaxTimerDie;
    public float CurrentTimerDie;

    public GameObject[] DisableObjects;

    public bool isDie;

    private void Start()
    {
        isDie = false;
    }

    void DieEvent()
    {
        if (isDie)
        {
            CurrentTimerDie -= Time.deltaTime;

            if (CurrentTimerDie <= 0)
            {
                Destroy(ObjectGrib);
                CurrentTimerDie = 0;
            }
        }
    }

    private void Update()
    {
        DieEvent();
    }

    private void OnTriggerStay(Collider enemy)
    {
        if (enemy.CompareTag("Player"))
        {
            foreach (GameObject obj in DisableObjects)
            {
                obj.SetActive(false);
            }

            NavMeshObject.enabled = false;
            AIscript.enabled = false;
            colliderEnemyCapsule.enabled = false;
            colliderEnemyBox.enabled = true;
            CurrentTimerDie = MaxTimerDie;
            isDie = true;
            colliderDieEnemy.enabled = false;
            MeshCurrent.mesh = MeshGribDie;
        }
    }
}
