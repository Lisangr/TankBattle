using UnityEngine;
public class HealAndDamagePlayer : MonoBehaviour
{
    public int HP;
    public int maxHP;

    public delegate void DeathAction();
    public static event DeathAction OnPlayerDeath;

    public void TakeDamage(int damage)
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            OnPlayerDeath?.Invoke();
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