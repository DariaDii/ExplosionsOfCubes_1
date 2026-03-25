using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private float _splitChance = 100f;

    public Rigidbody Rigidbody => _rigidBody;
    public Renderer Renderer => _renderer;
    public float SplitChance => _splitChance;

    public void Initialize(float newSplitChance)
    {
        _splitChance = newSplitChance;
    }
}