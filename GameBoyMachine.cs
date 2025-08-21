using UnityEngine;
using UnityEngine.PlayerLoop;

public class GameBoyMachine : MonoBehaviour
{
    public Animator anim;
    public bool isPlayerInZone;
    public bool PressFdone;
    public float timerMaxWait;
    public float curentTimer;

    public GameObject cameramenu;
    public FoneTextGameBoy textfone;
    public bool inAvtomat;
    public bool isArrowHelpAnim;

    private void Start()
    {
        inAvtomat = true;

        PlayerPrefs.GetFloat("isArrowHelpingGameBoy");
        if (PlayerPrefs.GetFloat("isArrowHelpingGameBoy") == 0)
        {
            anim.SetBool("ArrowAnimIs", true);
            isArrowHelpAnim = true;
        }

        PlayerPrefs.GetFloat("isArrowHelpingGameBoy");
        if (PlayerPrefs.GetFloat("isArrowHelpingGameBoy") == 1)
        {
            anim.SetBool("ArrowAnimIs", false);
            isArrowHelpAnim = false;
        }
    }

    public void CloseArrowHelping()
    {
        PlayerPrefs.SetFloat("isArrowHelpingGameBoy", 1);
        anim.SetBool("ArrowAnimIs", false);
        isArrowHelpAnim = false;
    }

    private void Update()
    {
        if (!inAvtomat)
        {
            curentTimer -= Time.deltaTime;
            PressFdone = false;
            if (curentTimer <= 0)
            {
                curentTimer = 0;
                inAvtomat = true;
            }
        }

        if (isPlayerInZone && PressFdone && inAvtomat && curentTimer <= 0)
        {
            curentTimer = timerMaxWait;
            textfone.enabled = false;
            anim.SetBool("FoneClose", true);
            anim.SetBool("MenuOpen", true);
            Camera playercam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            Canvas CanvasPlayer = GameObject.FindGameObjectWithTag("CanvasPlayer").GetComponent<Canvas>();
            InventoryBigUI inv1 = FindObjectOfType<InventoryBigUI>();
            InventoryMiniUI inv2 = FindObjectOfType<InventoryMiniUI>();
            InventoryTexts texts = FindObjectOfType<InventoryTexts>();
            InventoryPickUp pick = FindObjectOfType<InventoryPickUp>();
            PlayerJump JumpPlayerScript = FindObjectOfType<PlayerJump>();
            PlayerMovement PlayerScript = FindObjectOfType<PlayerMovement>();
            PlayerCamera PlayerCameraScript = FindObjectOfType<PlayerCamera>();
            PlayerHealth PlayerHealthScript = FindObjectOfType<PlayerHealth>();
            UIplayerInterface interfacePlayer = FindObjectOfType<UIplayerInterface>();
            CanvasPlayer.enabled = false;
            interfacePlayer.enabled = false;
            cameramenu.SetActive(true);
            playercam.enabled = false;
            inv1.enabled = false;
            inv2.enabled = false;
            texts.enabled = false;
            pick.enabled = false;
            JumpPlayerScript.enabled = false;
            PlayerScript.enabled = false;
            PlayerCameraScript.enabled = false;
            PlayerHealthScript.enabled = false;
            anim.SetBool("CloseMenu", false);
            anim.SetBool("ActiveMenu", true);
            isPlayerInZone = false;
            PressFdone = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            anim.SetBool("CloseMenu", true);
            anim.SetBool("ActiveMenu", false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
            
        }
    }

    public void CloseMenu()
    {
        inAvtomat = false;
        textfone.enabled = true;
        Camera playercam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        Canvas CanvasPlayer = GameObject.FindGameObjectWithTag("CanvasPlayer").GetComponent<Canvas>();
        PressFdone = false;
        playercam.enabled = true;
        CanvasPlayer.enabled = true;
        anim.SetBool("CloseMenu", false);
        anim.SetBool("ActiveMenu", false);
        anim.SetBool("FoneClose", false);
        anim.SetBool("MenuOpen", false);
        InventoryBigUI inv1 = FindObjectOfType<InventoryBigUI>();
        InventoryMiniUI inv2 = FindObjectOfType<InventoryMiniUI>();
        InventoryTexts texts = FindObjectOfType<InventoryTexts>();
        InventoryPickUp pick = FindObjectOfType<InventoryPickUp>();
        PlayerJump JumpPlayerScript = FindObjectOfType<PlayerJump>();
        PlayerMovement PlayerScript = FindObjectOfType<PlayerMovement>();
        PlayerCamera PlayerCameraScript = FindObjectOfType<PlayerCamera>();
        PlayerHealth PlayerHealthScript = FindObjectOfType<PlayerHealth>();
        UIplayerInterface interfacePlayer = FindObjectOfType<UIplayerInterface>();
        interfacePlayer.enabled = true;
        inv1.enabled = true;
        inv2.enabled = true;
        texts.enabled = true;
        pick.enabled = true;
        JumpPlayerScript.enabled = true;
        PlayerScript.enabled = true;
        PlayerCameraScript.enabled = true;
        PlayerHealthScript.enabled = true;
    }
}
