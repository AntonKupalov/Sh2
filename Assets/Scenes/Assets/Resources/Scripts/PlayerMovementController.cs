using UnityEngine;
using UnityEngine.Events;

public class PlayerMovementController : MonoBehaviour
{
    public UnityEvent<int> MovementCountIncrease;
    
    [SerializeField] 
    private float _forceValue = 250;
    
    private Rigidbody _rigidbody;
    private Vector3 _startPosition = Vector3.zero;
    private Vector3 _target;
    private int _movementCount;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Если позиция игрока по Y меньше нуля - значит он упал с платформы.
        if (transform.position.y < 0)
        {
            MoveToStartPoint();
        }

        // Создаем луч из позиции мыши.
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            // Если нажата левая кнопка мыши.
            if (Input.GetMouseButtonDown(0))
            {
                // Зануляем скорость.
                _rigidbody.velocity = Vector3.zero;
                
                // Двигаем кубик к заданной точке.
                MoveTowardsSelectedPoint(hitInfo);
            }
        }
    }

    private void MoveTowardsSelectedPoint(RaycastHit hitInfo)
    {
        // Вычисляем направление движения.
        var direction = (hitInfo.point - transform.position).normalized;

        // Придаем игроку силу в указанном направлении.
        _rigidbody.AddForce(new Vector3(direction.x, 0, direction.z) * _forceValue);

        _movementCount++;
        MovementCountIncrease.Invoke(_movementCount);
    }

    public void MoveToStartPoint()
    {
        // Переносим игрока на стартовую точку.
        transform.position = _startPosition;

        // Зануляем ему скорость.
        _rigidbody.velocity = Vector3.zero;
    }
}