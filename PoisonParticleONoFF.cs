using UnityEngine;

public class PoisonParticleONoFF : MonoBehaviour
{
    public ParticleSystem particleObject;

    public void particleAuraStop()
    {
        particleObject.Stop();
    }

    public void particleAuraPlay()
    {
        particleObject.Play();
    }
}
