using UnityEngine;

public class Fire : MonoBehaviour
{
    public Rigidbody bulet;
    public float speed = 500f;

    private float timeBtwShots = .3f;
    private float startTimeBtwShots;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && timeBtwShots <= 0)
        {
            Rigidbody clone = Instantiate(bulet, transform.position, transform.rotation);
            clone.velocity = transform.forward * speed * Time.deltaTime;
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
}

