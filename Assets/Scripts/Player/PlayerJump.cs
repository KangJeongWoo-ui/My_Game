using UnityEngine;

// 플레이어 점프 관련 스크립트
public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    [SerializeField] private float jumpForce;  // 점프 힘
    [SerializeField] private int maxJumpCount; // 허용되는 최대 점프 횟수

    private int currentJumpCount;              // 현재 남은 점프 가능 횟수

    private Rigidbody2D rb;
    private InputController inputController;
    private GroundCheck groundCheck;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        inputController = GetComponent<InputController>();
        groundCheck = GetComponentInChildren<GroundCheck>();
    }
    private void OnEnable()
    {
        // 착지 시 점프 횟수 리셋 이벤트 등록
        groundCheck.OnLanded += ResetJumpCount;
    }
    private void Start()
    {
        ResetJumpCount();

        // 점프 입력 이벤트 구독
        inputController.OnJumpEvent += OnJumpInput;
    }
    // 점프 물리력을 가하는 메서드
    private void OnJumpInput(bool isPressed)
    {
        if (isPressed && currentJumpCount != 0)
        {
            // 수직 속도를 초기화 하여 중력 영향을 상쇄
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            currentJumpCount--;
        }
    }
    private void ResetJumpCount()
    {
        currentJumpCount = maxJumpCount;
    }
}
