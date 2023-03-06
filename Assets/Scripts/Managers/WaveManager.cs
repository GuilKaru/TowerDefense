using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using Unity.VisualScripting;

[Serializable]
public struct WaveDetails
{
    //Enemies in every wave (Level Builder)
    public List<WaveEnemies> waveEnemies;
}

[Serializable]
public struct WavesRoad
{
    public List<WaveDetails> Waves;
    [Header("Spawn Point of Enemies")]
    public Transform spawnPoint;
    public Transform EnemiesPlaceholder;
    public EnemyWaypoints enemyWaypoints;
}
public class WaveManager : MonoBehaviour
{

    [Header("WaveUI")]
    public TextMeshProUGUI currentWave;
    public TextMeshProUGUI totalWaves;

    [Header("Wave Stats")]
    private int wavesIndex = 0;
    [SerializeField] private float timeBetweenWaves = 5f;
    public float waitTime = 1f;
    private float waveCD = 5f;
    private int totalNumWaves;

    [SerializeField] private List<WavesRoad> wavesRoad;

    public static int EnemiesAlive = 0;

    private void Start()
    {
        for(int i = 0; i < wavesRoad.Count; i++)
        {
            totalNumWaves += wavesRoad[i].Waves.Count;
        }
        totalWaves.text = wavesRoad[0].Waves.Count.ToString();
    }

    private void Update()
    {
        if (GameManager.gameEnded) return;

        if (EnemiesAlive > 0) return;

        if (waveCD <= 0f && wavesIndex < totalNumWaves)
        {
            StartCoroutine(SpawnWave(wavesIndex));
            waveCD = timeBetweenWaves;
            return;
        }

        waveCD -= Time.deltaTime;

        if (wavesIndex + 1 <= wavesRoad[0].Waves.Count)
        {
            currentWave.text = (wavesIndex + 1).ToString();
        }

        if ((wavesIndex == wavesRoad[0].Waves.Count) && (EnemiesAlive == 0))
        {
            GameManager.gameWon = true;
        }
    }

    IEnumerator SpawnWave(int waveIdx)
    {
        if (GameManager.gameEnded)
        {
            yield return null;
        }
        else
        {
            for(int k = 0; k < wavesRoad.Count; k++)
            {
                StartCoroutine(SpawnNewWave(waveIdx, k));
            }


            yield return new WaitUntil(() => EnemiesAlive == 0);
            wavesIndex++;
        }
    }

    IEnumerator SpawnNewWave(int waveIdx, int k)
    {
        for(int i = 0; i < wavesRoad[k].Waves[waveIdx].waveEnemies.Count; i++)
        {
            for(int j = 0; j < wavesRoad[k].Waves[waveIdx].waveEnemies[i].enemiesAmount; j++)
            {
                EnemiesAlive++;
                Transform Enemy = Instantiate(wavesRoad[k].Waves[waveIdx].waveEnemies[i].enemyPrefab, wavesRoad[k].spawnPoint.position,
                                                wavesRoad[k].spawnPoint.rotation, wavesRoad[k].EnemiesPlaceholder);
                EnemyMovement enemyMovement = Enemy.GetComponent<EnemyMovement>();
                enemyMovement.allWaypoints = wavesRoad[k].enemyWaypoints.waypoints;
                yield return new WaitForSeconds(wavesRoad[k].Waves[waveIdx].waveEnemies[i].spawnRate);
            }
        }
    }
}
