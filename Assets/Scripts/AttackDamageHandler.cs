using UnityEngine;
using System.Collections.Generic;
public class AttackDamageHandler : MonoBehaviour
{
    [SerializeField] private int attackPower;

    private List<Collider2D> hit = new List<Collider2D>();
    private void OnEnable()
    {
        hit.Clear();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            if (!hit.Contains(collision))
            {
                IDamageable damageable = collision.GetComponent<IDamageable>();

                damageable.TakeDamage(attackPower);

                hit.Add(collision);
            }
        }
    }
}
