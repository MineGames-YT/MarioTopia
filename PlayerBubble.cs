using UnityEngine;
using UnityEngine.UI;

public class PlayerBubble : MonoBehaviour
{
    public Image BarBubble;
    public Animator AnimEnergy;
    public PlayerMovement PlayerScript;
    public float maxRunTime = 5f;
    void Update()
    {
        if (PlayerScript.recoveryTimer > 0)
        {
            AnimEnergy.SetBool("BubbleRecover", true);
        }
        else
        {
            AnimEnergy.SetBool("BubbleRecover", false);
        }
        BarBubble.fillAmount = PlayerScript.currentRunTime / maxRunTime;
    }
}
