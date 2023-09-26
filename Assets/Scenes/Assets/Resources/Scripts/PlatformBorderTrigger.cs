using UnityEngine;

public class PlatformBorderTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider collider)
    {
        var player = collider.gameObject.GetComponent<PlayerMovementController>();
        
        // Если попавший в триггер объект - это Player.
        if (player)
        {
            // Перемещаем его к начальной точке.
            player.MoveToStartPoint();
        }
    }
}