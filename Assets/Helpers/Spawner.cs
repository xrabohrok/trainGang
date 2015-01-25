using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

	public List<Vector3> wave1path = new List<Vector3>();
	public List<Vector3>wave2path = new List<Vector3>();

	// Use this for initialization
	void Start () {
        timeSinceLastWave = waveGapTime;
        timeSinceLastSpawn = 0;
        finished = false;
        if (spawnTemplate == null)
            throw new System.Exception("need a thing to spawn!");

		/*wave1path.Add (Vector3(17.89, 2.67, -19.51));
		wave1path.Add (Vector3(17.89, 2.67, 29.41));
		wave1path.Add (Vector3(8.57, 2.67, 37.09));

		wave2path.Add (Vector3(-1.97, 2.67, -15.79));
		wave2path.Add (Vector3(-1.97, 2.67, 30.29));
		wave2path.Add (Vector3(8.57, 2.67, 37.09));*/


	}
	
	// Update is called once per frame
	void Update () {
        if (wavesSpawned >= waveNum)
            finished = true;

        if (!finished)
        {
            timeSinceLastWave += Time.deltaTime;
            if (timeSinceLastWave > waveGapTime )
            {


                timeSinceLastSpawn = timeSinceLastSpawn + Time.deltaTime;
                if (timeSinceLastSpawn > spawnGapTime)
                {
                    timeSinceLastSpawn = 0;
                    GameObject.Instantiate(spawnTemplate, this.transform.position, this.transform.rotation);
					spawnTemplate.GetComponent<EnemyMovement>().positions = wave1path;
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
