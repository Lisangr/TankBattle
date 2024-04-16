using UnityEngine;
public class HealAndDamageEnemy : MonoBehaviour
{
    public int HP;
    public int maxHP;

    public delegate void DeathAction();
    public static event DeathAction OnEnemyDeath;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            OnEnemyDeath?.Invoke();
        }
    }
    public void TakeHeal(int bonusHP)
    {
        HP += bonusHP;

        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }
}