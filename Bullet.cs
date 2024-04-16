using UnityEngine;
public class Bullet : MonoBehaviour
{
    public int damage = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<HealAndDamageEnemy>().TakeDamage(damage);
            DestroyBullet();
        }
    }
    void DestroyBullet()
    {
        Destroy(this.gameObject);
    }
}