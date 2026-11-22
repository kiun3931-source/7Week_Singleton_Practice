using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerState
{
    void Enter(Player player);
    void Update(Player player);
    void Exit(Player player);
}

public class IdleState : IPlayerState
{
    public void Enter(Player player) => Debug.Log("[Idle] 가만히 서 있습니다.");

    public void Update(Player player)
    {
        var kb = Keyboard.current;
        if (kb.leftArrowKey.isPressed || kb.rightArrowKey.isPressed)
            player.ChangeState(player.Run);
        else if (kb.spaceKey.wasPressedThisFrame)
            player.ChangeState(player.Jump);
    }

    public void Exit(Player player) => Debug.Log("[Idle] 대기 종료");
}

public class RunState : IPlayerState
{
    public void Enter(Player player) => Debug.Log("[Run] 달리기 시작!");

    public void Update(Player player)
    {
        var kb = Keyboard.current;
        float dir = 0;
        if (kb.leftArrowKey.isPressed) dir = -1;
        if (kb.rightArrowKey.isPressed) dir = 1;

        if (dir == 0)
            player.ChangeState(player.Idle);          // 방향키를 떼면 대기
        else if (kb.spaceKey.wasPressedThisFrame)
            player.ChangeState(player.Jump);          // 달리다가 점프
        else
            player.transform.Translate(dir * 5f * Time.deltaTime, 0, 0);
    }

    public void Exit(Player player) => Debug.Log("[Run] 달리기 멈춤");
}

public class JumpState : IPlayerState
{
    private float timer;

    public void Enter(Player player)
    {
        timer = 0.5f;                                 // 0.5초 동안 공중에 있다고 가정
        Debug.Log("[Jump] 점프!");
    }

    public void Update(Player player)
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            Debug.Log("[Jump] 공중에서는 다시 점프할 수 없습니다.");

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            var kb = Keyboard.current;
            bool moving = kb.leftArrowKey.isPressed || kb.rightArrowKey.isPressed;
            player.ChangeState(moving ? player.Run : player.Idle);   // 착지
        }
    }

    public void Exit(Player player) => Debug.Log("[Jump] 착지");
}