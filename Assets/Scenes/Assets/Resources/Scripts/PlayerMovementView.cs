using TMPro;
using UnityEngine;

public class PlayerMovementView : MonoBehaviour
{
    [SerializeField] 
    private TextMeshProUGUI _playerMovementCountLabel;

    public void SetPlayerMovementCount(int count)
    {
        _playerMovementCountLabel.text = count.ToString();
    }
}