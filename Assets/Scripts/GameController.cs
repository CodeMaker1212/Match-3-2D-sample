using UnityEngine;
using UnityEngine.Events;

public enum RoundResult { Victory, Error}

public class GameController : MonoBehaviour
{
    private const string _pocketTag = "Pocket";
    private const string _targetCellTag = "Target Cell";
    [SerializeField] private ResultScreen _resultScreen;
    [SerializeField] private StartScreen _startScreen;
    private DraggableCube _draggableCube;

    public event UnityAction RoundStarted;
    public event UnityAction CorrectDropping;
    public event UnityAction<RoundResult> RoundOver;

    private void Awake()
    {
        _startScreen.StartButtonClick += StartNewRound;
        _resultScreen.RepeatButtonClick += OnRepeatButtonClick;
        _draggableCube = FindObjectOfType<DraggableCube>();
        _draggableCube.DroppedOn += OnDraggableCubeDroppedOn;
        _draggableCube.Disappeared += OnCubeDisappeared;
    }

    private void StartNewRound() => RoundStarted?.Invoke();

    private void OnRepeatButtonClick() => StartNewRound();

    private void OnDraggableCubeDroppedOn(string objectTag)
    {
        switch (objectTag)
        {
            case _pocketTag: return;
            case _targetCellTag: CorrectDropping?.Invoke(); break;
            default: RoundOver?.Invoke(RoundResult.Error); break;
        }      
    }   

    private void OnCubeDisappeared() => RoundOver?.Invoke(RoundResult.Victory);
}   