using UnityEngine;

// 피해를 받을 수 있는 대상이 구현해야 하는 인터페이스
// 공격자가 공격 성공 시 IDamageable 을 찾아 TakeDamage를 호출
public interface IDamageable
{
    public void TakeDamage(int damage);
}
