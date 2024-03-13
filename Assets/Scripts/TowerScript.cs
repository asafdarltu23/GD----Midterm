using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class TowerScript : MonoBehaviour
{
    private Transform target;
    public float range;
    public static int damage = 20;
   
    public float fireRate;
    private float coolDown = 0;

    public GameObject attackPrefab;
    public Transform firingPoint;

    private float maxUpgrade = 5;
    private float level = 1;

    public static float upgradeCost = 1000;

    public AudioSource audioPlayer;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0, 0.5f);
        InvokeRepeating("UpdateStats", 0, 0.5f);
        audioPlayer.clip = sound;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (enemyDistance < shortestDistance)
            { 
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else target = null;
    }

    void UpdateStats()
    {
        if (level == 1)
        {
            range = 20;
            damage = 20;
            fireRate = 2;
        }

        if (level == 2)
        {
            range = 20;
            damage = 30;
            fireRate = 3;
        }

        if (level == 3)
        {
            range = 25;
            damage = 40;
            fireRate = 4.5f;
        }

        if (level == 4)
        {
            range = 25;
            damage = 50;
            fireRate = 4.5f;
        }

        if (level == 5)
        {
            range = 30;
            damage = 60;
            fireRate = 6;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            return;
        }

        Quaternion lookRotation = Quaternion.LookRotation((gameObject.transform.position - target.position).normalized);
        transform.rotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);

        if(coolDown <= 0)
        {
            Shoot();
            coolDown = 1 / fireRate;
        }

        coolDown -= Time.deltaTime;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    void Shoot()
    {
        GameObject attackObject = (GameObject)Instantiate(attackPrefab, firingPoint.position, firingPoint.rotation);
        BulletScript bullet = attackObject.GetComponent<BulletScript>();
        audioPlayer.Play();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }

    public void AssaultUpgrade()
    {
        if (level > 1)
            upgradeCost = 1000 * (level * 1.5f);

        if (level < maxUpgrade && MoneyManager.money >= upgradeCost)
          {
            level++;
            MoneyManager.money = MoneyManager.money - upgradeCost;
          }
        else if (level >= maxUpgrade)
        {
            Debug.Log("Maximum Upgrade!");
        }
    }
}
