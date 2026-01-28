using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int hp;

    public bool IsDead { get; private set; }

    public void TakeDamage(int damage)
    {
        if (IsDead) return;

        hp -= damage;

        if(hp <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        IsDead = true;
    }
}
