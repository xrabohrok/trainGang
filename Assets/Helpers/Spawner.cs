using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject spawnTemplate;

    public int waveSize;
    public float waveGapTime;
    public float spawnGapTime;
    public int waveNum;

    public bool finished { get; private set; }

    private float timeSinceLastWave;
    private float timeSinceLastSpawn;
    private int spawnedThisWave;
    private int wavesSpawned = 0;

	// Use this for initialization
	void Start () {
        timeSinceLastWave = waveGapTime;
        timeSinceLastSpawn = 0;
        finished = false;
        if (spawnTemplate == null)
            throw new System.Exception("need a thing to spawn!");
	}
	
	// Update is called once per frame
	void Update () {
        if (wavesSpawned >= waveNum)
            finished = true;

        if (!finished)
        {
            Debug.Log("notfinished");
            timeSinceLastWave += Time.deltaTime;
            if (timeSinceLastWave > waveGapTime )
            {


                Debug.Log("ready for wave");
                timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;
                Debug.Log(timeSinceLastSpawn);
                if (timeSinceLastSpawn > spawnGapTime)
                {
                    Debug.Log("ready for individual");
                    timeSinceLastSpawn = 0;
                    GameObject.Instantiate(spawnTemplate);
                    spawnedThisWave++;
                    if (spawnedThisWave == waveSize)
                        wavesSpawned++;

                    if (spawnedThisWave >= waveSize)
                    {
                        Debug.Log("reset");
                        spawnedThisWave = 0;
                        timeSinceLastWave = 0;
                    }
                }
            }
        }

	}
}
