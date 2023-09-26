using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    public UnityEvent<EnemyController> EnemyDiedEvent;
    public Color Color => _color;

    [SerializeField] 
    private Renderer _renderer;
    private Color _color;

    public void Initialize(Color color)
    {
        _renderer.material.color = color;
        _color = color;
    }

    private void OnCollisionEnter(Collision collision)
    {
        var player = collision.gameObject.GetComponent<Player>();
        
        // Если столкнувшийся с врагом объект - это Player.
        if (player)
        {
            // Если цвет врага совпадает с цветом игрока.
            if (player.Color == _color)
            {
                EnemyDiedEvent.Invoke(this);
                
                // Разрушаем врага.
                Destroy(gameObject);
            }
        }
    }
}