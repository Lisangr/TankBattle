using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyController : MonoBehaviour
{
    public Transform player;
    private Transform patrolRoute;
    public Rigidbody bulet;
    public float speedBullet = 500f;
    public Transform shootPoint;
    public List<Transform> locations;
    public TextMeshProUGUI life_state;

    private int locationIndex = 0;
    private NavMeshAgent agent;
    private bool playerExitedTrigger = false;
    private HealAndDamageEnemy healAndDamage;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("Player").transform;
        healAndDamage = GetComponent<HealAndDamageEnemy>();
        patrolRoute = GameObject.Find("PatrolRoute").transform;
        InitializePatrolRoute();
    }
    void Update()
    {
        if (agent.isOnNavMesh && agent.remainingDistance < 2f && !agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }

        life_state.text = healAndDamage.HP.ToString();
    }
    void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
            return;
        
        agent.destination = locations[locationIndex].position;// Устанавливаем пункт назначения для агента
        locationIndex = (locationIndex + 1) % locations.Count;
    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
        // Алгоритм Фишера-Йетса для случайной перестановки точек
        for (int i = locations.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            Transform temp = locations[i];
            locations[i] = locations[randomIndex];
            locations[randomIndex] = temp;
            //дополнительная проверка
            if (Vector3.Distance(temp.position, locations[i].position) < 1f)
            {
                locations.Remove(locations[i]);
                i--;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerExitedTrigger = false;
            StartCoroutine(ShootCoroutine());
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerExitedTrigger = true;
            StopAllCoroutines();
        }
    }
    IEnumerator ShootCoroutine()
    {
        while (!playerExitedTrigger)
        {
            agent.SetDestination(player.position);
            yield return StartCoroutine(Shoot());
        }
    }
    public IEnumerator Shoot()
    {
        yield return new WaitForSeconds(2f);
        Rigidbody clone = Instantiate(bulet, shootPoint.position, transform.rotation);
        clone.velocity = transform.forward * speedBullet * Time.deltaTime;

    }
}