using UnityEngine;

public class GradientGameBoy : MonoBehaviour
{
    public float GradientSpeed = 0.1f;

    [SerializeField]
    private Gradient _gradient;
    [SerializeField]
    private float _gradientTime = 0;
    public MeshRenderer _spriteRend;

    void Update()
    {
        _gradientTime += GradientSpeed * Time.deltaTime;
        _gradientTime %= 1f;

        _spriteRend.material.color = _gradient.Evaluate(_gradientTime);
        _spriteRend.material.SetColor("_EmissionColor", _gradient.Evaluate(_gradientTime));
    }
}
