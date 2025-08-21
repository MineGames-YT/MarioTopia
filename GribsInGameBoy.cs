using UnityEngine;

public class GribsInGameBoy : MonoBehaviour
{

    [Space(2)]
    [Header("EyesController")]
    [Space(2)]
    public bool EyesTickBool;
    public int minEyesTick;
    public int maxEyesTick;
    public float EyesTick;
    public Animator anim;
    private void Update()
    {
        EyesTickAnim();
    }
    public void EyesTickAnim()
    {
        if (EyesTickBool)
        {
            EyesTick = Random.Range(minEyesTick, maxEyesTick);
            anim.SetTrigger("isEyes");
            EyesTickBool = false;
        }

        if (!EyesTickBool)
        {
            EyesTick -= Time.deltaTime;

            if (EyesTick <= 0)
            {
                EyesTick = 0;
                EyesTickBool = true;
            }
        }
    }
}
