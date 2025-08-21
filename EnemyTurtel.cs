using UnityEngine;
using UnityEngine.AI;

public class EnemyTurtel : MonoBehaviour
{
    [Space(2)]
    [Header("MovingToPlayer")]
    [Space(2)]
    [SerializeField] private int _raysCount;
    [SerializeField] private int _distance;
    [SerializeField] private float radiusStopping;
    [SerializeField] private float _angle;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Transform _target;
    [SerializeField] private NavMeshAgent _ai;

    [Space(2)]
    [Header("Patrolling")]
    [Space(2)]

    public float stopDurationMin = 1f; // ����������� ����������������� ���������
    public float stopDurationMax = 3f; // ������������ ����������������� ���������
    public float stoppingDistance = 0.5f; // ����������, �� ������� ���� ��������������� � �����
    public Transform[] patrolPoints;


    [Space(2)]
    [Header("Information")]
    [Space(2)]
    public int currentPatrolIndex = 0; // ������ ������� ����� ��������������
    public float stopTimer; // ������ ���������
    public bool isStopping = false; // ���� ���������
    public bool isStopingInPlayer;
    public Vector3 position;
    public Animator anim;

    private void Start()
    {
        PlayerMovement player = FindObjectOfType<PlayerMovement>();
        _target = player.transform;
    }

    void Update()
    {
        UpdateAnimation();

        if (Vector3.Distance(transform.position, _target.position) < radiusStopping && RayToScan())
        {
            StopAndLookAtPlayer();
        }
        else
        {
            ResumePatrol();
        }

        if (Vector3.Distance(transform.position, _target.position) < _distance)
        {
            if (RayToScan())
            {
                anim.SetBool("isEating", false);
                isStopping = false;
                stopTimer = 0;
                _ai.enabled = true;
                _ai.SetDestination(_target.position);
            }
        }
        if (isStopping)
        {
            StopPatrol();
        }
        else if (!isStopping && _ai.remainingDistance < stoppingDistance)
        {
            StartStop();
        }
    }


    private void UpdateAnimation()
    {
        // ��������� �������� NavMeshAgent � ��������� �������� ��������
        if (_ai.velocity.magnitude > 0.1f) // ���� �������� ������ 0.1, �������, ��� ���� ��������
        {
            anim.SetBool("isWalking", true); // �������� �������� ������
        }
        else
        {
            anim.SetBool("isWalking", false); // ��������� �������� ������
        }
    }


    public void StopAndLookAtPlayer()
    {
        isStopingInPlayer = true;
        _ai.isStopped = true;
    }

    public void ResumePatrol()
    {
        isStopingInPlayer = false;
        _ai.isStopped = false;
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        position = transform.position + _offset;
        if (Physics.Raycast(position, dir, out hit, _distance))
        {
            if (hit.transform == _target)
            {
                result = true;
                Debug.DrawLine(position, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(position, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(position, dir * _distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;

        for (int i = 0; i < _raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);

            j += +_angle * Mathf.Deg2Rad / _raysCount;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            if (GetRaycast(dir)) a = true;

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }

    private void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        _ai.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }

    private void StartStop()
    {
        anim.SetBool("isEating", true);
        isStopping = true;
        stopTimer = Random.Range(stopDurationMin, stopDurationMax);
        _ai.isStopped = true;
        _ai.Stop();
    }

    private void StopPatrol()
    {
        stopTimer -= Time.deltaTime;
        if (stopTimer <= 0)
        {
            anim.SetBool("isEating", false);
            stopTimer = 0;
            isStopping = false;
            _ai.isStopped = false;
            GoToNextPatrolPoint();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // ����������� ����� ��������������
        foreach (var point in patrolPoints)
        {
            if (point != null)
            {
                Gizmos.DrawSphere(point.position, 0.5f);
            }
        }

        // ����������� ����� ������������
        Vector3 position = transform.position + _offset;
        float j = 0;

        for (int i = 0; i < _raysCount; i++)
        {
            var x = Mathf.Sin(j);
            var y = Mathf.Cos(j);
            j += +_angle * Mathf.Deg2Rad / _raysCount;

            Vector3 dir = transform.TransformDirection(new Vector3(x, 0, y));
            Gizmos.DrawRay(position, dir * _distance);

            if (x != 0)
            {
                dir = transform.TransformDirection(new Vector3(-x, 0, y));
                Gizmos.DrawRay(position, dir * _distance);
            }
        }

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(transform.position, radiusStopping);
    }
}
