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
    public int money = 30;
    private int heroSpawnCounter = 0;
    private int spawnRate = 500;
    private int generation = 0;
    public GameObject test;
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
            spawnSlimeTile(test, 1);
        }
        if (firstRun)
            firstRun = false;
        heroSpawnCounter++;
        if (heroSpawnCounter % spawnRate == 0)
        {
            spawnHero();
            generation++;
        }
    }
    private void spawnHero()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rHealth = UnityEngine.Random.Range(50 + generation * 10, 100 + generation * 10);
        int rAttack = UnityEngine.Random.Range(5 + generation * 2, 10 + generation * 2);
        int rSpeed = UnityEngine.Random.Range(30, 80);
        if (firstRun)
        { Tile test = spawnPoints[rSpawn]; }
        newHero = Instantiate(aHero, spawnPoints[rSpawn].transform.position, Quaternion.identity);
        newHero.spawn(spawnPoints[rSpawn], 10, 1, 1, rSpeed);
    }
    private void spawnSlime()
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int rSpeed = UnityEngine.Random.Range(20, 60);
        if (firstRun)
        { Tile test = spawnPoints[rSpawn]; }
        newSlime = Instantiate(aSlime, slimeSpawnPoints[rSpawn].transform.position, Quaternion.identity);
        newSlime.spawn(slimeSpawnPoints[rSpawn], 10, 1, 1, rSpeed);

    }
    public void spawnSlimeTile(GameObject inPrefab, int id)
    {
        int rSpawn = UnityEngine.Random.Range(0, 3);
        int[] slimeStats = slimeTypes[id];
        if (firstRun)
        { Tile test = spawnPoints[rSpawn]; }
        aSlime.GetComponent<SpriteRenderer>().sprite = test.GetComponent<SpriteRenderer>().sprite;
        aSlime.GetComponent<Animator>().runtimeAnimatorController = test.GetComponent<Animator>().runtimeAnimatorController;
        newSlime = Instantiate(aSlime, slimeSpawnPoints[rSpawn].transform.position, Quaternion.identity);
        newSlime.spawn(slimeSpawnPoints[rSpawn], slimeStats[0], slimeStats[1], slimeStats[2], slimeStats[3]);
    }

    public Slime convertToSlime(GameObject inPrefab)
    {
        inPrefab.AddComponent<Slime>();
        return inPrefab.GetComponent<Slime>();
    }

    public void createDictionary()
    {
        slimeTypes = new Dictionary<int, int[]>();
        //health, attack, defense, speed
        slimeTypes.Add(1, new int[] { 10, 5, 1, 30 });
        slimeTypes.Add(2, new int[] { 20, 3, 1, 30 });
        slimeTypes.Add(3, new int[] { 20, 8, 1, 40 });
        slimeTypes.Add(4, new int[] { 30, 5, 1, 40 });
        slimeTypes.Add(5, new int[] { 20, 5, 1, 50 });
        slimeTypes.Add(6, new int[] { 30, 10, 1, 50 });
        slimeTypes.Add(7, new int[] { 40, 8, 1, 50 });
        slimeTypes.Add(8, new int[] { 30, 8, 1, 60 });
        slimeTypes.Add(9, new int[] { 40, 13, 1, 60 });
        slimeTypes.Add(10, new int[] { 50, 10, 1, 60 });
        slimeTypes.Add(11, new int[] { 40, 10, 1, 70 });
        slimeTypes.Add(12, new int[] { 50, 15, 1, 70 });
        slimeTypes.Add(13, new int[] { 60, 13, 1, 70 });
        slimeTypes.Add(14, new int[] { 60, 20, 1, 65 });
        slimeTypes.Add(15, new int[] { 100, 15, 1, 65 });
    }
}
