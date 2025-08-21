using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [Space(2)]
    [Header("Sensivity")]
    [Space(2)]
    public float sensitivity = 2.0f;

    [Space(2)]
    [Header("LockedHead")]
    [Space(2)]
    public float minY = -30f;
    public float maxY = 30f;

    [Space(2)]
    [Header("FrameRate")]
    [Space(2)]
    public int FrameRatelimiter = 144;

    [Space(2)]
    [Header("Smoothness")]
    [Space(2)]
    public float headSmoothness = 0.1f;
    public float bodySmoothness = 0.1f;

    [Space(2)]
    [Header("Objects")]
    [Space(2)]
    public Transform playerBody;
    public Transform cameraTransform;

    [Space(2)]
    [Header("InventoryRyka")]
    [Space(2)]
    public GameObject RightRyka;
    public GameObject LeftRyka;
    public float RykiRotation;

    [Space(2)]
    [Header("Information")]
    [Space(2)]
    public bool isRotateRyks;
    public bool isRotateAllRyks;
    public bool isStartPos;
    public bool isRotate = true;
    public float rotationX = 0f;
    private Quaternion targetHeadRotation;
    private Quaternion targetBodyRotation;


    void Start()
    {
        Application.targetFrameRate = FrameRatelimiter;
        Cursor.lockState = CursorLockMode.Locked;
        targetHeadRotation = cameraTransform.localRotation;
        targetBodyRotation = playerBody.rotation;
        sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1);
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        rotationX -= mouseY;
        RykiRotation -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);
        RykiRotation = Mathf.Clamp(RykiRotation, minY, maxY);

        if (isRotateRyks && isRotate)
        {
            isStartPos = true;
            RightRyka.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.x, RykiRotation);
            LeftRyka.transform.localEulerAngles = new Vector3(0f, 1.1f, -0.4f);
            LeftRyka.transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
        }
        else if (isRotateAllRyks && isRotate)
        {
            isStartPos = true;
            RightRyka.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.x, RykiRotation);
            LeftRyka.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.x, RykiRotation);
        }
        else if (isStartPos && !isRotateRyks && !isRotateAllRyks && isRotate)
        {
            isStartPos = false;
            RightRyka.transform.localEulerAngles = new Vector3(0f, 1.1f, 0.4f);
            RightRyka.transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
            LeftRyka.transform.localEulerAngles = new Vector3(0f, 1.1f, -0.4f);
            LeftRyka.transform.localRotation = Quaternion.EulerRotation(0, 0, 0);
        }



        if (isRotate)
        {
            Quaternion bodyRotation = playerBody.rotation * Quaternion.Euler(0f, mouseX, 0f);
            targetBodyRotation = Quaternion.Slerp(targetBodyRotation, bodyRotation, bodySmoothness);
            playerBody.rotation = targetBodyRotation;
        }
        Quaternion headRotation = Quaternion.Euler(0f, 0f, rotationX);
        targetHeadRotation = Quaternion.Slerp(targetHeadRotation, headRotation, headSmoothness);
        cameraTransform.localRotation = targetHeadRotation;
        
    }
}
