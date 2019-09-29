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
    private Hero newHero;
    private Slime newSlime;
    private bool firstRun = true;
    public bool gameOver = false;
    public Dictionary<int, int[]> slimeTypes;
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
        createDictionary();


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
        if (gameOver)
        {
            Debug.Log("GAME OVER!");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spawnHero();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            spawnSlime();
        }
        if (firstRun)
            firstRun = false;
    }
    private void spawnHero()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rSpeed = UnityEngine.Random.Range(1, 100);
        if (firstRun)
        { Tile test = spawnPoints[rSpawn]; }
        newHero = Instantiate(aHero, spawnPoints[rSpawn].transform.position, Quaternion.identity);
        newHero.spawn(spawnPoints[rSpawn], 10, 1, 1, rSpeed);
    }
    private void spawnSlime()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rSpeed = UnityEngine.Random.Range(1, 100);
        if (firstRun)
        { Tile test = spawnPoints[rSpawn]; }
        newSlime = Instantiate(aSlime, slimeSpawnPoints[rSpawn].transform.position, Quaternion.identity);
        newSlime.spawn(slimeSpawnPoints[rSpawn], 10, 1, 1, rSpeed);

    }
    public void spawnSlimeTile(GameObject inPrefab, int id)
    {
        int[] slimeStats = slimeTypes[id];
        //newSlime = Instantiate(aSlime, <LOCATION>, Quaternion.identity);
        //newSlime.spawn(<FIND TILE OF LOCATION>, slimeStats[0], slimeStats[1], slimeStats[2], slimeStats[3]);

    }

    public void createDictionary()
    {
        slimeTypes = new Dictionary<int, int[]>();
        //health, attack, defense, speed
        slimeTypes.Add(0, new int[] { 1, 1, 1, 1});
    }
}
