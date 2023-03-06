using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy enemy;
    public Transform wpTarget;
    public Transform[] allWaypoints;
    private int waypointIndex = 0;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        wpTarget = allWaypoints[0];
    }

    private void Update()
    {
        //Move Enemies in the direction of the Waypoints
        if (GameManager.gameEnded) return;
        Vector3 direction = wpTarget.position - transform.position;
        transform.Translate(direction.normalized * enemy.speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, wpTarget.position) <= 0.5f)
        {
            ChangeWaypoint();
        }
    }

    //Change waypoint if you reach the last one
    private void ChangeWaypoint()
    {
        if(waypointIndex >= allWaypoints.Length -1)
        {
            EndOfPath();
            return;
        }
        waypointIndex++;
        wpTarget = allWaypoints[waypointIndex];
    }

    void EndOfPath()
    {
        //End of path, damage player and kill enemie
        PlayerStats.Lives--;
        WaveManager.EnemiesAlive--;
        Destroy(gameObject);
    }
}
