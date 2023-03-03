using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[Serializable]
public struct WaveDetails
{
    //Enemies in every wave (Level Builder)
    public List<WaveEnemies> waveEnemies;
}
public class WaveManager : MonoBehaviour
{
    [Header("Spawning Points")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform EnemiesPlaceholder;

    [Header("WaveUI")]
    public TextMeshProUGUI currentWave;
    public TextMeshProUGUI totalWaves;

    [Header("Wave Stats")]
    private int wavesIndex = 0;
    [SerializeField] private float timeBetweenWaves = 5f;
    public float waitTime = 1f;
    private float waveCD = 5f;

    [SerializeField] private List<WaveDetails> Waves;

    public static int EnemiesAlive = 0;

/*    private void Start()
    {
        totalWaves.text = Waves.Count.ToString();
    }

    private void Update()
    {
        //if (GameManager.gameEnded) return;

        if (EnemiesAlive > 0) return;

        if(waveCD <= 0f && wavesIndex < Waves.Count)
        {
            StartCoroutine(SpawnWave(wavesIndex));
            waveCD = timeBetweenWaves;
            return;
        }

        waveCD -= Time.deltaTime;

        if(wavesIndex + 1 <= Waves.Count)
        {
            currentWave.text = (wavesIndex + 1).ToString();
        }

        if((wavesIndex == Waves.Count) && (EnemiesAlive == 0))
        {
            //GameManager.gameWon = true;
        }
    }

    IEnumerator SpawnWave(int waveIdx)
    {
        if(GameManager.gameEnded)
        {
            yield return null;
        }
        else
        {
            for(int i = 0; i < Waves[waveIdx].waveEnemies.Count; i++)
            {
                for(int j = 0; j < Waves[waveIdx].waveEnemies[i].enemiesAmount; j++)
                {
                    EnemiesAlive++;
                    Transform Enemy = Instantiate(Waves[waveIdx].waveEnemies[i].enemyPrefab, spawnPoint.position,
                                                    spawnPoint.rotation, EnemiesPlaceholder);
                    yield return new WaitForSeconds(Waves[wavesIndex].waveEnemies[i].spawnRate);
                }
            }
            yield return new WaitUntil(() => EnemiesAlive == 0);
            wavesIndex++;
        }
    }*/
}
