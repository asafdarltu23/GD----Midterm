using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private Transform target;
    public float speed = 10;

    public GameObject effect;

    // Start is called before the first frame update
    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float dist = speed * Time.deltaTime;

        if (dir.magnitude <= dist)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * dist, Space.World);
    }

    void HitTarget()
    {
        GameObject effects = (GameObject)Instantiate(effect, transform.position, transform.rotation);
        Destroy(effects, 0.5f);
        Destroy(gameObject);
    }
}
