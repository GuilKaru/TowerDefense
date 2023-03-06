using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform enemyTarget;

    [Header("Bullet Stats")]
    public float speed = 10f;
    public int damage = 10;
    public float explosionRadius = 0f;

    [Header("Effects")]
    public GameObject hitEffect;

    public void Chase(Transform _enemyTarget)
    {
        enemyTarget = _enemyTarget;
    }

    private void Update()
    {
        if(enemyTarget == null)
        {
            Destroy(gameObject);
            return;
        }
        //Direction of the enemy to target
        Vector3 dir = enemyTarget.position - transform.position;
        float currentDistance = speed * Time.deltaTime;

        if(dir.magnitude <= currentDistance)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * currentDistance, Space.World);
        transform.LookAt(enemyTarget);
    }

    private void HitTarget()
    {
        //Instantiate particle effect and destroy it in 2 seconds
        GameObject effectIns = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            DamageEnemy(enemyTarget);
        }
    }

    void DamageEnemy(Transform enemy)
    {
        Enemy currentEnemy = enemy.GetComponent<Enemy>();

        if (currentEnemy != null)
        {
            currentEnemy.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

    void Explode()
    {
        //Hit all enemies in a radius
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitObject in hitObjects)
        {
            if(hitObject.tag == "Enemy")
            {
                DamageEnemy(hitObject.transform);
            }
        }
    }

    //Gizmo to see damage area
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
