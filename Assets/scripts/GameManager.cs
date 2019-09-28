using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Tile[] spawnPoints;
    public TileManager grid;
    public Entity aHero;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new Tile[3];
        //grid = GameObject.Find("gridTiles");
        grid.populateTiles();
        generateSpawnArray();
        //Debug.Log(spawnPoints[0].posX);
        //Debug.Log(spawnPoints[0].posY);
    }

    private void generateSpawnArray()
    {
        int spawnIndex = 0;
        for (int i = 0; i < grid.width; i++)
        {
            for (int j = 0; j < grid.height; j++)
            {
                if (grid.tiles[i, j].tag == "summon")
                {
                    spawnPoints[spawnIndex] = grid.tiles[i, j];
                    spawnIndex++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnHero();
        }
    }
    private void spawnHero()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rSpeed = UnityEngine.Random.Range(1, 100);
        Instantiate(aHero, spawnPoints[rSpawn].transform.position, Quaternion.identity);
        aHero.spawn(spawnPoints[rSpawn], 1, 1, 1, rSpeed);
    }
}
