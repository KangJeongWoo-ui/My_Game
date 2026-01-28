using UnityEngine;
using UnityEngine.InputSystem;

// Input System의 InputValue를 실제 로직 이벤트로 변환
public class PlayerInputController : InputController
{
    // 이동 입력 처리
    public void OnMove(InputValue value)
    {
        // x 축 이동만 유효하도록 처리 (횡 스크롤)
        Vector2 raw = value.Get<Vector2>();

        Vector2 moveInput = new Vector2(raw.x, 0f);
        CallMoveEvent(moveInput);
    }
    // 점프 입력 처리
    public void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            CallJumpEvent(true);
        }
    }
    // 공격 입력 처리
    public void OnAttack(InputValue value)
    {
        CallAttackEvent(value.isPressed);
    }
}
