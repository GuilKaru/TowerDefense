using UnityEngine;

public class Tower : MonoBehaviour
{

    [Header("Turret Rotation")]
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private Transform rotatingBase;
    [SerializeField] private Transform tiltingCannon;

    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;

    [Header("Turret Stats")]
    public float range = 15f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    private string enemyTag = "Enemy";

    private Transform towerTarget;
    private Enemy enemyTarget;

    private void Start()

    {
        InvokeRepeating("TargetUpdate", 0f, 0.5f);
    }
    
    private void TargetUpdate()
    {
        if (GameManager.gameEnded) return;

        //FindEnemies to lock
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach(GameObject enemy in enemies)
        { //Attack the nearest enemy
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= range) 
        {
            towerTarget = nearestEnemy.transform;
            enemyTarget = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            towerTarget = null;
        }
    }

    private void Update()
    {
        if (GameManager.gameEnded) return;

        //Line renderer if needed for lasers
        if (towerTarget == null) return;

        TargetLockOn();
        CannonLockOn();

        if(fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    private void TargetLockOn()
    {
        //Rotate the base of the tower only in the Y axis.
        Vector3 dir = towerTarget.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotateBase = Quaternion.Lerp(rotatingBase.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        rotatingBase.rotation = Quaternion.Euler(0f, rotateBase.y, 0f);
        
    }

    private void CannonLockOn()
    {
        //Rotate the cannon to target the enemie and not tilt the base of the tower.
        Vector3 dir = towerTarget.position - tiltingCannon.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotateCannon = Quaternion.Lerp(tiltingCannon.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        tiltingCannon.rotation = Quaternion.Euler(rotateCannon);
    }

    private void Shoot()
    {
        //Fire the bullet and give the enemy target to the bullet
        GameObject ActiveBullet = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = ActiveBullet.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Chase(towerTarget);
        }
    }

    //Show the range of the tower in Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
