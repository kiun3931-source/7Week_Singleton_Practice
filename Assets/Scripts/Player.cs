using UnityEngine;

public class Player : MonoBehaviour
{
    public readonly IdleState Idle = new IdleState();
    public readonly RunState Run = new RunState();
    public readonly JumpState Jump = new JumpState();

    private IPlayerState currentState;

    private void Start()
    {
        ChangeState(Idle);
    }

    private void Update()
    {
        currentState.Update(this);   // 지금 상태에게 할 일을 맡김
    }

    public void ChangeState(IPlayerState next)
    {
        if (currentState == next) return;

        string from = currentState?.GetType().Name ?? "없음";
        Debug.Log($"[Player] 상태 변경: {from} → {next.GetType().Name}");

        currentState?.Exit(this);
        currentState = next;
        currentState.Enter(this);
    }
}
