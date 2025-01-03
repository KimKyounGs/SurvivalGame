using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Control")]
    public float gameTime;
    public float maxGameTime = 2*10f;
    [Header("# Player Control")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {10, 30, 60, 100, 150, 210, 280, 360, 450, 600};
    [Header("# Game Object")]
    public PoolManager pool;
    public Player player;

    private void Awake() 
    {
        if (instance == null) 
        {
            instance = this;
        }
    }

    private void Update()
    {
        gameTime += Time.deltaTime;

        if (gameTime > maxGameTime) 
        {
            gameTime = maxGameTime;
        }   

        if (exp == nextExp[level])
        {
            level++;
            exp = 0;
        }
    }

    public void GetExp()
    {
        exp++;
        // 레벨업 로직
        if (exp == nextExp[level])
        {
            level ++;
            exp = 0;

        }
    }
}
