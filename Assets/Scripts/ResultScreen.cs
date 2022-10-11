using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ResultScreen : UIScreen
{
    private const string _victoryText = "онаедю";
    private const string _errorText = "ньхайю";
    [SerializeField] private Button _repeatButton;
    [SerializeField] private GameController _gameContoller;  
    [SerializeField] private Text _title;

    public event UnityAction RepeatButtonClick;

    private void Awake()
    {       
        _gameContoller.RoundStarted += OnRoundStart;
        _gameContoller.RoundOver += OnRoundOver;
    }

    private void OnRoundStart()
    {
        _repeatButton.onClick.RemoveAllListeners();
        Disable();
    }

    private void OnRoundOver(RoundResult result)
    {
        Enable();
        _repeatButton.onClick.AddListener(RepeatButtonClick);
        _title.text = result == RoundResult.Victory ? _victoryText : _errorText;
    }  
}