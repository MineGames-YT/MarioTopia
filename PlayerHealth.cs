using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
public class PlayerHealth : MonoBehaviour
{

    [Space(2)]
    [Header("Health")]
    [Space(2)]
    public float maxHealth = 100f;

    [Space(2)]
    [Header("Poisons")]
    [Space(2)]
    public float HPPerSec = 2f; //������� �� � �������
    public float countSecReg = 1f; // ������� ������ �� ����� �����������
    public float MaxRegSec = 20f; //������������ ��� �������������
    public Image poisonCircle;
    [Space(2)]
    [Header("Information")]
    [Space(2)]
    public bool isRegen; //����� ��������������
    public float timeElapsed = 0f; //������������� ������ ��� �� �����������
    public float RegSec; // ������� ��� ������������� 
    public float currentHealth;
    public Image healthBar;
    public Animator anim;
    public AudioMixer mixer;
    public AudioSource DieMusic;
    public UIplayerInterface playerInterfaceScript;
    public PlayerEat playerEat;
    private void Update()
    {
        HealRegen();
        UpdateHealthBar();
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }

    public void HealRegen()
    {
        if (isRegen)
        {
            RegSec -= Time.deltaTime;
            timeElapsed += Time.deltaTime;
            poisonCircle.fillAmount = RegSec / MaxRegSec;
            anim.SetBool("HealthEffectOnBool", true);
            anim.SetBool("HealthEffectActiveBool", true);
            if (timeElapsed >= countSecReg)
            {
                timeElapsed = 1;
                currentHealth += HPPerSec;
                timeElapsed = 0;
            }
            if (RegSec <= 20)
            {
                anim.SetBool("HealthEffectFoneBool", true);
            }

            if (RegSec <= 0)
            {
                anim.SetBool("HealthEffectOnBool", false);
                anim.SetBool("HealthEffectActiveBool", false);
                anim.SetBool("HealthEffectFoneBool", false);
                RegSec = 0;
                timeElapsed = 0;
                isRegen = false;
            }
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth;
        }
    }

    void Die()
    {
        mixer.SetFloat("MusicInScene", -80f);
        DieMusic.PlayDelayed(1);
        playerInterfaceScript.allowPausing = false;
        anim.Play("DieAnim");
        Debug.Log("Player has died!");
        // ������ ������ ������ (������������ ������, ���� � �.�.)
    }
}
