using UnityEngine;

public class Player : MonoBehaviour
{
    public Color Color { get; private set; }
    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    public void SetColor(Color color)
    {
        _renderer.material.color = color;
        Color = color;
    }
}