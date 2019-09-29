using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Tile[] spawnPoints;
    private Tile[] slimeSpawnPoints;
    public TileManager grid;
    public Hero aHero;
    public Slime aSlime;
    // Start is called before the first frame update
    void Start()
    {
        spawnPoints = new Tile[3];
        slimeSpawnPoints = new Tile[3];
        //grid = GameObject.Find("gridTiles");
        grid.populateTiles();
        generateSpawnArray();
        slimeSpawnPoints[0] = grid.tiles[3, 9];
        slimeSpawnPoints[1] = grid.tiles[8, 10];
        slimeSpawnPoints[2] = grid.tiles[14, 11];

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
        if (Input.GetKeyDown(KeyCode.S))
        {
            spawnSlime();
        }
        if
    }
    private void spawnHero()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rSpeed = UnityEngine.Random.Range(1, 100);
        Instantiate(aHero, spawnPoints[rSpawn].transform.position, Quaternion.identity);
        aHero.spawn(spawnPoints[rSpawn], 10, 1, 1, rSpeed);
    }
    private void spawnSlime()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rSpeed = UnityEngine.Random.Range(1, 100);
        Instantiate(aSlime, slimeSpawnPoints[rSpawn].transform.position, Quaternion.identity);
        aSlime.spawn(slimeSpawnPoints[rSpawn], 10, 1, 1, rSpeed);

    }
}
