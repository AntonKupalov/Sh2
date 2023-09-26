using UnityEngine;
using Random = UnityEngine.Random;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    private int _randomRadius = 10;

    [SerializeField] 
    private Renderer _renderer;
    
    [SerializeField] 
    private ColorsProvider _colorsProvider;

    private Color _color;
    
    private Vector3 _startPosition = Vector3.zero;

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        _color = _renderer.material.color;
    }

    private void Start()
    {
        SetPosition();
        SetColor();
    }

    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.gameObject.GetComponent<Player>();
        
        // Если попавший в триггер объект - это Player.
        if (player)
        {
            // Задаем игроку цвет сферы.
            player.SetColor(_color);

            // Меняем позицию и цвет сферы.
            SetPosition();
            SetColor();
        }
    }
        
    private void SetPosition()
    {
        // Создаем случайную позицию в пределах окружности радиусом _randomRadius
        var randomPosition = Random.insideUnitCircle * _randomRadius;

        // Начальная позиция сферы.
        var position = _startPosition;
        
        // Прибавляем к начальной позиции случайную позицию по двум осям.
        position.x += randomPosition.x;
        position.z += randomPosition.y;
        transform.position = position;
    }
    
    private void SetColor()
    {
        var newColor = _colorsProvider.GetColor();
        
        _renderer.material.color = newColor;
        _color = newColor;
    }
}