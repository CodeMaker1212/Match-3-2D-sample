using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : UIScreen
{
    [SerializeField] private Button _startButton;

    public event UnityAction StartButtonClick;

    private void Awake() => _startButton.onClick.AddListener(OnStartButtonClick);

    private void OnStartButtonClick()
    {
        StartButtonClick?.Invoke();
        Disable();
    }
}