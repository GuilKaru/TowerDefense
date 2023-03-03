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

        Vector3 dir = enemyTarget.position - transform.position;
        float currentDistance = speed * Time.deltaTime;

        if(dir.magnitude <= currentDistance)
        {
            HitTarget();
        }

        transform.Translate(dir.normalized * currentDistance, Space.World);
    }

    private void HitTarget()
    {
        DamageEnemy(enemyTarget);
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
}
