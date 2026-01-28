using System;
using UnityEngine;

// 입력 데이터를 관리하고 이벤트를 전파하는 컨트롤러
public class InputController : MonoBehaviour
{
    // 이벤트 정의
    public event Action<Vector2> OnMoveEvent;  // 이동 입력
    public event Action<bool> OnJumpEvent;     // 점프 입력 상태
    public event Action<bool> OnAttackEvent;   // 공격 입력 상태

    // 이벤트 호출 메서드
    public void CallMoveEvent(Vector2 direction) => OnMoveEvent?.Invoke(direction);
    public void CallJumpEvent(bool isPressed) => OnJumpEvent?.Invoke(isPressed);
    public void CallAttackEvent(bool isPressed) => OnAttackEvent?.Invoke(isPressed);
}
