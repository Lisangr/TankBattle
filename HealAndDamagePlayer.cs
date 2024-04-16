using UnityEngine;
public class HealAndDamagePlayer : MonoBehaviour
{
    public int HP; //здоровье
    public int maxHP; // максимальное здоровье

    public delegate void DeathAction();
    public static event DeathAction OnPlayerDeath;

    public void TakeDamage(int damage) //Здоровье - урон
    {
        HP -= damage;

        if (HP <= 0)
        {
            Destroy(this.gameObject);
            OnPlayerDeath?.Invoke();
        }
    }
    public void TakeHeal(int bonusHP) //Здоровье + восстановление
    {
        HP += bonusHP;

        if (HP > maxHP)
        {
            HP = maxHP;
        }
    }
}