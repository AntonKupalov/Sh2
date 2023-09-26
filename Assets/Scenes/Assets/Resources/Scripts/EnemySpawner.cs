using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public UnityEvent<Color, int> ChangeEnemiesCountWithColor;
    
    [SerializeField] 
    private EnemyController _enemyPrefab;

    [SerializeField] 
    private int _enemiesCount = 6;
    
    [SerializeField]
    private int _randomRadius = 10;

    private ColorsProvider _colorsProvider;
    
    private Dictionary<Color, int> _enemiesCountsByColor = new();

    public void Initialize(ColorsProvider colorsProvider)
    {
        _colorsProvider = colorsProvider;
        var colors = _colorsProvider.GetAllColors();
        
        // Инициализируем словарь.
        foreach (var color in colors)
        {
            _enemiesCountsByColor.Add(color, 0);
        }

        for (var i = 0; i < _enemiesCount; i++)
        {
            // Создаем объект врага.
            var enemy = Instantiate(_enemyPrefab);

            // Задаем позицию врагу.
            SetEnemyPosition(enemy);
            
            // Передаем врагу цвет.
            var color = _colorsProvider.GetColor();
            enemy.Initialize(color);

            // Увеличиваем на 1 количество врагов данного цвета.
            _enemiesCountsByColor[color] += 1;
            
            // Вызываем событие изменения количества врагов данногоц цвета.
            ChangeEnemiesCountWithColor.Invoke(color, _enemiesCountsByColor[color]);

            // Подписываемся на событие смерти врага.
            enemy.EnemyDiedEvent.AddListener(EnemyDied);
        }
    }

    private void EnemyDied(EnemyController enemyController)
    {
        // Уменьшаем на 1 количество врагов данного цвета.
        _enemiesCountsByColor[enemyController.Color]--;
        
        // Вызываем событие изменения количества врагов данногоц цвета.
        ChangeEnemiesCountWithColor.Invoke(enemyController.Color, _enemiesCountsByColor[enemyController.Color]);
    }

    private void SetEnemyPosition(EnemyController enemyController)
    {
        // Создаем случайную позицию в пределах окружности радиусом _randomRadius
        var randomPosition = Random.insideUnitCircle * _randomRadius;

        // Начальная позиция врага.
        var enemyPosition = enemyController.transform.position;

        // Прибавляем к начальной позиции врага случайную позицию по двум осям.
        enemyPosition.x += randomPosition.x;
        enemyPosition.z += randomPosition.y;
        
        enemyController.transform.position = enemyPosition;
    }
}