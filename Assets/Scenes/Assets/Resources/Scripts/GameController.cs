using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] 
    private ColorsProvider _colorsProvider;

    [SerializeField] 
    private EnemySpawner _enemySpawner;

    [SerializeField] 
    private SphereController _sphereController;

    [SerializeField] 
    private EnemiesView _enemiesView;

    private void Awake()
    {
        _enemiesView.Initialize(_colorsProvider);
        _enemySpawner.Initialize(_colorsProvider);
        _sphereController.Initialize(_colorsProvider);
    }
}