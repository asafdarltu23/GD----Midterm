using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveScript : MonoBehaviour
{
    public enum SpawnState { Spawning, Waiting, Counting };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemy = new Transform[4];
        public int enemyCount;
        public float rate;
    }

    public Wave[] waves = new Wave[15];
    private int nextWave = 0;
    public float waveTimeLimit = 5; //Low for testing
    public float countdown = 5;

    public Transform spawnPoint;

    private SpawnState state = SpawnState.Counting;

    private float checkCountdown = 1;

    public TextMeshProUGUI waveText;
    public GameObject completeText;

    public GameObject VictoryScreen;
    public GameObject BackgroundMusic;
    public GameObject VictoryMusic;

    private void Start()
    {
        waveText.text = waves[0].name;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!enemyAlive())
            {
                WaveComplete();
            }
            else return;
        }

        if (countdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            countdown -= Time.deltaTime;
        }
    }

    IEnumerator SpawnWave(Wave wave)
    {
        Debug.Log("Spawning Wave " + wave.name);
        state = SpawnState.Spawning;
        for (int i = 0; i < wave.enemyCount; i++)
        {
            Spawn(wave.enemy);
            yield return new WaitForSeconds(1/wave.rate);
        }

        if (wave.name == "Wave 15")
        {
            Instantiate(wave.enemy[3], spawnPoint.transform.position, spawnPoint.transform.rotation);
        }

        state = SpawnState.Waiting;

        yield break;
    }

    void Spawn(Transform[] enemy)
    {
        Instantiate(enemy[Random.Range(0, 3)], spawnPoint.transform.position, spawnPoint.transform.rotation);
    }

    bool enemyAlive()
    {
        checkCountdown -= Time.deltaTime;

        if (checkCountdown <= 0)
        {
            checkCountdown = 1;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }

        return true;
    }

    void WaveComplete()
    {
        state = SpawnState.Counting;
        countdown = waveTimeLimit;

        if (nextWave + 1 > waves.Length - 1)
        {
            Debug.Log("Level Clear");
            VictoryScreen.SetActive(true);
            BackgroundMusic.SetActive(false);
            VictoryMusic.SetActive(true);
            Time.timeScale = 0f;
        }
        else nextWave++;

        waveText.text = waves[nextWave].name;
        EnemyBehavior.difficultyMultiplier = (1 + nextWave);
        if (GameObject.FindGameObjectWithTag("BankTower"))
        {
            MoneyManager.money = MoneyManager.money + 1000 + BankerScript.bonusCash;
        }
        else MoneyManager.money = MoneyManager.money + 1000;
        StartCoroutine(FlashText());

    }

    IEnumerator FlashText()
    {
        completeText.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        completeText.SetActive(false);
    }
}
