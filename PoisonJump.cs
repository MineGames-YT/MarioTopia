using UnityEngine;

public class PoisonJump : MonoBehaviour
{
    public AudioSource poisonCollectSound;
    public ParticleSystem ParticleCollect;
    public GameObject Poison;

    public GameObject Component1;
    public GameObject Component2;
    public GameObject Component3;

    public BoxCollider collider;

    public float MaxPoisonAlive;
    public float PoisonAlive;
    public bool isCollected;


    private void Start()
    {
        PoisonAlive = MaxPoisonAlive;
        isCollected = false;
    }

    private void Update()
    {
        if (isCollected)
        {
            PoisonAlive -= Time.deltaTime;

            if (PoisonAlive <= 0)
            {
                Destroy(Poison);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���������, �������� �� ������ �������
        if (other.CompareTag("Player"))
        {
            collider.enabled = false;

            Component1.SetActive(false);
            Component2.SetActive(false);
            Component3.SetActive(false);
            poisonCollectSound.Play();
            ParticleCollect.Play();
            isCollected = true;

            InventoryMiniUI MiniInventory4 = other.GetComponent<InventoryMiniUI>();
            MiniInventory4.Poison_JumpCurrent ++;
            MiniInventory4.anim.Play("CurrentMiniInv");
            
            PlayerPrefs.SetInt("Poison_Jump", +1);
            PlayerPrefs.Save();
        }
    }
}
