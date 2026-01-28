using UnityEngine;
using UnityEngine.EventSystems;
// 입력된 방향에 따라 플레이어의 물리적 이동 처리
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed; // 이동 속도

    private Vector2 moveDirection = Vector2.zero; // 현재 이동 입력 방향

    private Rigidbody2D rb;
    private InputController inputController;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
    }
    private void Start()
    {
        // 이동 입력 이벤트 구독
        inputController.OnMoveEvent += SetMoveDirection;
    }
    private void FixedUpdate()
    {
        Move();
    }
    
    private void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }
    // 움직임 메서드
    private void Move()
    {
        rb.linearVelocity = new Vector2(
            moveDirection.x * moveSpeed,
            rb.linearVelocity.y);

        Rotation();
    }
    // 회전 메서드
    private void Rotation()
    {
        // 입력 방향의 x 가 0보다 클 경우(오른쪽)
        if (moveDirection.x > 0)
        {
            transform.localScale = new Vector3(
                Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z);
        }
        // 입력 방향의 x 가 0보다 작을 경우(왼쪽)
        else if (moveDirection.x < 0)
        {
            transform.localScale = new Vector3(
                -Mathf.Abs(transform.localScale.x),
                transform.localScale.y,
                transform.localScale.z);
        }
    }
}
