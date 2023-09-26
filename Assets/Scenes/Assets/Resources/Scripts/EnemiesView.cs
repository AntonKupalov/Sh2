using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemiesView : MonoBehaviour
{
    [SerializeField] 
    private Image[] _enemiesColors;
    
    [SerializeField] 
    private TextMeshProUGUI[] _enemiesCountLabel;

    public void Initialize(ColorsProvider colorsProvider)
    {
        var colors = colorsProvider.GetAllColors();
            
        for (var i = 0; i < colors.Length; i++)
        {
            var color = colors[i];
            _enemiesColors[i].color = color;
        }
    }

    public void SetCountOfEnemiesWithColor(Color color, int count)
    {
        for (var i = 0; i < _enemiesColors.Length; i++)
        {
            if (color == _enemiesColors[i].color)
            {
                _enemiesCountLabel[i].text = count.ToString();
                break;
            }
        }
    }
}