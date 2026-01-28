using System.Collections;
using UnityEngine;

// 플레이어 공격 및 공격 쿨타임을 관리하는 스크립트
public class PlayerAttack : MonoBehaviour
{
    [Header("Attack Settings")]
    [SerializeField] private GameObject attackRange; // 공격 범위 오브젝트
    [SerializeField] private float attackDuration;   // 공격 판정이 유지되는 시간
    [SerializeField] private float attackCooldown;   // 공격 재사용 대기 시간

    private bool isAttackReady = true; // 현재 공격이 가능한 상태인지 여부

    private ParticleSystem attackParticle;
    private InputController inputController;
    private void Awake()
    {
        inputController = GetComponent<InputController>();
        if (attackRange != null)
        {
            attackParticle = attackRange.GetComponentInChildren<ParticleSystem>();
            attackRange.SetActive(false);
        }
    }
    private void Start()
    {
        // 공격 입력 이벤트 구독
        inputController.OnAttackEvent += OnAttackInput;
    }
    private void OnAttackInput(bool isPressed)
    {
        // 버튼이 눌렸고 공격 가능한 상태일때만 실행
        if(isPressed && isAttackReady)
        {
            StartCoroutine(AttackRoutine());
        }
    }
    private IEnumerator AttackRoutine()
    {
        // 공격 쿨타임 시작: 공격 불가 상태로 전환
        isAttackReady = false;

        attackRange.SetActive(true);
        if(attackParticle != null )
        {
            attackParticle.Stop();
            attackParticle.Play();
        }

        // 공격 판정 유지
        yield return new WaitForSeconds(attackDuration);
        attackRange.SetActive(false);

        // 공격 쿨다운 시간만큼 대기
        yield return new WaitForSeconds(attackCooldown - attackDuration);

        // 공격 쿨타임 종료: 공격 가능 상태로 전환
        isAttackReady = true;
    }
}
