using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    private Transform wpTarget;
    private int waypointIndex = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        wpTarget = EnemyWaypoints.waypoints[0];
    }

    private void Update()
    {
        //Move Enemies in the direction of the Waypoints
        if (GameManager.gameEnded) return;

        Vector3 direction = wpTarget.position - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, wpTarget.position) <= 0.5f)
        {
            ChangeWaypoint();
        }
    }

    //Change waypoint if you reach the last one

    private void ChangeWaypoint()
    {
        if(waypointIndex >= EnemyWaypoints.waypoints.Length -1)
        {
            EndOfPath();
            return;
        }
        waypointIndex++;
        wpTarget = EnemyWaypoints.waypoints[waypointIndex];
    }

    void EndOfPath()
    {
        PlayerStats.Lives--;
        WaveManager.EnemiesAlive--;
        Destroy(gameObject);
    }
}
