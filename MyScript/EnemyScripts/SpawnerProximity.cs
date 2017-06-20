using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class pos_Limit
{
    public float minx;
    public float maxx;
    public float minz;
    public float maxz;
    public float height;
};
public class SpawnerProximity : MonoBehaviour {

    public List<GameObject> spawnList;
    public int numberToSpawn;
    public float proximity;
    public Text waveText;
    public Text timeText;
    public pos_Limit lim;
    private float checkRate;
    private float nextCheck;
    private Transform myTransform;
    public Transform playerTransform;
    private Vector3 spawnPosition;
    private int wave;
    private float timecount;
    private int spawnwave;
    private int num;
    private int spawnnum;
    private float lastTime;
    
    
	// Use this for initialization
	void Start () {
        SetInitialReferences();
	}
	
	// Update is called once per frame
	void Update () {
        CheckDistance();
	}

    void SetInitialReferences()
    {
        myTransform = transform;
        checkRate = 5f;
        spawnwave = 10;
        timecount = 90f;
        lastTime = Time.time;
    }

    void CheckDistance()
    {
        if (num < spawnwave && Time.time > nextCheck) {
            nextCheck = Time.time + checkRate;
            numberToSpawn = Random.Range(1, spawnwave - num+1);
            spawnnum = Random.Range(0, spawnList.Count);
            SpawnObjects();
            num += numberToSpawn;
        }
        timecount -= Time.time - lastTime;
        lastTime = Time.time;
        if(timecount <= 0)
        {
            timecount = timecount + 90f;
            wave++;
            spawnwave += 2;
            num = 0;
            nextCheck = Time.time + checkRate;
        }
        waveText.text = "Wave:" + wave.ToString();
        timeText.text = "Next wave:" + timecount.ToString();
    }

    void SpawnObjects()
    {
        for(int i = 0; i < numberToSpawn; i++) {
            float maxx = lim.maxx < playerTransform.position.x + 80 ? lim.maxx : playerTransform.position.x + 80;
            float minx = lim.minx > playerTransform.position.x - 80 ? lim.minx : playerTransform.position.x - 80;
            spawnPosition.x = Random.Range(minx, maxx);
            float maxz = lim.maxz < playerTransform.position.z + 80 ? lim.maxz : playerTransform.position.z + 80;
            float minz = lim.minz > playerTransform.position.z - 80 ? lim.minz : playerTransform.position.z - 80;
            spawnPosition.z = Random.Range(minz, maxz);
            spawnPosition.y = lim.height;
            Instantiate(spawnList[spawnnum], spawnPosition, myTransform.rotation);
        }
    }
}
