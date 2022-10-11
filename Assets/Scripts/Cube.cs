using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Cube : MonoBehaviour
{
    protected Animator animator;
    protected GameController gameController;

    public virtual event UnityAction Disappeared;

    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        gameController = FindObjectOfType<GameController>();
        gameController.RoundStarted += OnRoundStarted;
        gameController.CorrectDropping += OnCorrectDropping;
    }

    protected virtual void OnRoundStarted() => Appear();

    protected virtual void OnCorrectDropping() => Disappear();

    protected void Appear() => animator.SetTrigger(nameof(Appear));

    protected void Disappear() => animator.SetTrigger(nameof(Disappear));

    protected void OnDisappearanceEnd() => Disappeared?.Invoke();
}