using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public static float difficultyMultiplier;
    public float speed = 10;
    public float health = 100 * difficultyMultiplier;

    private Transform target;
    private int waypointIndex = 0;

    public bool Tank;
    public bool Speedy;
    public bool Boss;

    // Start is called before the first frame update
    void Start()
    {
        target = WaypointScript.Waypoints[0];
        if (Tank)
            health = health * 2;
        if (Speedy)
        {
            speed = 15;
            health = health / 2;
        }
        if (Boss)
        {
            speed = 5;
            health = 2500;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4)
        {
            GetNextWayPoint();
            Quaternion lookRotation = Quaternion.LookRotation((target.position - gameObject.transform.position).normalized);
            transform.rotation = lookRotation;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log(difficultyMultiplier);
    }

    void GetNextWayPoint()
    {
        if (waypointIndex >= WaypointScript.Waypoints.Length - 1) 
        {
            Destroy(gameObject);
            HealthScript.Health = HealthScript.Health - (health / 2);
            return;
        }

        waypointIndex++;
        target = WaypointScript.Waypoints[waypointIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            health = health - TowerScript.damage;
        }
    }
}
