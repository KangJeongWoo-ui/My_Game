using System;
using UnityEngine;

// 트리거 충돌을 통해 플레이어의 지면 접지 상태를 판정
public class GroundCheck : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private GameObject groundCheck; // 지면 체크 오브젝트
    [SerializeField] private bool isGrounded;        // 인스펙터 확인용 변수

    [Header("Gizmo Settings")]
    [SerializeField] private Vector2 boxSize = new Vector2(); // 디버그용 박스 크기

    public event Action OnLanded; // 착지 시점 이벤트
    public bool IsGrounded { get; private set; } // 외부 참조용 접지 상태
    private void Update()
    {
        isGrounded = IsGrounded;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ground 태그를 가진 물체와 접촉시
        if (other.CompareTag("Ground"))
        {
            IsGrounded = true;
            OnLanded?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Ground 태그에서 벗어날 시
        if (other.CompareTag("Ground"))
        {
            IsGrounded = false;
        }
    }

    // 씬 뷰에서 접지 판정 범위 표시
    private void OnDrawGizmos()
    {
        Gizmos.color = isGrounded ? Color.green : Color.red;

        Vector3 pos = groundCheck.transform.position;
        Vector3 size = new Vector3(boxSize.x, boxSize.y, 1.0f);

        Gizmos.DrawWireCube(pos, size);
    }
}
