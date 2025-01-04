using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{   
    public Transform[] spawnPoint;
    public SpawnData[] spawnData;
    int level;
    float timer;
    
    private void Awake() 
    {
        spawnPoint = GetComponentsInChildren<Transform>();
    }
    private void Update()
    {
        if(!GameManager.instance.isLive) return;
        
        timer += Time.deltaTime;
        // 적절한 시간에 맞춰서 레벨이 올라가게끔 만들기.
        level = Mathf.Min(Mathf.FloorToInt(GameManager.instance.gameTime / 10f),spawnData.Length-1);

        if (timer > spawnData[level].spawnTime) 
        {
            timer = 0;
            Spawn();
        }
    }

    private void Spawn()
    {
        GameObject enemy = GameManager.instance.pool.Get(0);
        enemy.transform.position = spawnPoint[Random.Range(1, spawnPoint.Length)].position;
        enemy.GetComponent<Enemy>().Init(spawnData[level]);
    }
}

[System.Serializable]
public class SpawnData
{
    public float spawnTime;
    public int spriteType;
    public int health;
    public float speed;
}
