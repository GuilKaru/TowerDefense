using UnityEngine;
using System;

[Serializable]
public struct WaveEnemies
{
    [Header("Enemies in Wave")]
    public int enemiesAmount;
    public Transform enemyPrefab;
    public float spawnRate;

}
public class Enemy : MonoBehaviour
{
    [Header("Enemy Stats")]
    public float maxHealth;
    public float speed;
    //public float modifiedSpeed;
    public float currentHealth;
    public float shield = 0;
    public float dmgMitigation = 10;

    [Header("Enemy Money Drop")]
    public int moneyDrop;

    private bool isDead = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if(shield > 0)
        {
            if((shield - (damage - dmgMitigation)) < 0)
            {
                shield = 0;
            }
            else
            {
                shield -= damage - dmgMitigation;
            }
        }
        else
        {
            currentHealth -= damage;
        }

        if(currentHealth <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;

        PlayerStats.Money += moneyDrop;

        WaveManager.EnemiesAlive--;

        Destroy(gameObject);
    }
}
