using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Entity : MonoBehaviour
{
    public int health, maxHealth, attack, defense, speed; //stats
    public int cX, cY; //character x and y location on grid
    public int directionFacing; //0 = North, 1 = East, 2 = South, 3 = West
    protected TileManager grid;
    public Tile prevTile;
    public Tile curTile;
    public int id;
    protected int clockTimer = 0;
    public bool inBattle = false;
    public Entity target;
    protected int deathTime;
    protected bool dying = false;
    public bool newSpawn = true;
    protected float velocity;
    protected float saveVelocity;
    protected float vX;
    protected float vY;
    protected float cXF;
    protected float cYF;
    protected bool haveMoved = false;

    public void Move()
    {
        if (curTile.tag != "cross")
        {
            if (tileExists(directionFacing))
            {
                moveOneUnit(directionFacing);
            }
            else
            {
                turnAround();
                updateVelo();
                Move();
            }
        }
        else
        {
            Tile[] availableTiles = findAvailableTiles();
            int numAvail = availableTiles.Length;
            int choice = UnityEngine.Random.Range(0, numAvail);
            directionFacing = updateDirection(availableTiles[choice]);
            updateVelo();
            prevTile = curTile;
            curTile = availableTiles[choice];
            updateXY();
        }

    }
    protected int updateDirection(Tile newTile)
    {
        int xDiff = newTile.posX - cX;
        int yDiff = newTile.posY - cY;
        if (xDiff > 0)
        {
            return 1;
        }
        else if (xDiff < 0)
        {
            return 3;
        }
        else if (yDiff > 0)
        {
            return 0;
        }
        else if (yDiff < 0)
        {
            return 2;
        }
        return directionFacing;
    }

    protected void turnAround()
    {
        int newDirection = directionFacing + 2;
        if (newDirection >= 4)
        {
            newDirection -= 4;
        }
        directionFacing = newDirection;
    }

    protected void moveOneUnit(int direction)
    {
        prevTile = curTile;
        if (direction == 0)
        {
            curTile = grid.tiles[cX, cY + 1];
        }
        else if (direction == 1)
        {
            curTile = grid.tiles[cX + 1, cY];
        }
        else if (direction == 2)
        {
            curTile = grid.tiles[cX, cY - 1];
        }
        else
        {
            curTile = grid.tiles[cX - 1, cY];
        }
        updateXY();
    }


    protected bool tileExists(int lookDirection)
    {
        if (lookDirection == 0)
        {
            return (cY + 1 < grid.height);
        }
        else if (lookDirection == 1)
        {
            return (cX + 1 < grid.width);
        }
        else if (lookDirection == 2)
        {
            return (cY - 1 >= 0);
        }
        else
        {
            return (cX - 1 >= 0);
        }
    }

    protected Tile[] findAvailableTiles()
    {
        int numTilesReturned = 3;
        Tile[] tilesReturned = new Tile[numTilesReturned];
        int tileIndex = 0;
        if (directionFacing == 0)
        {
            if (tileExists(0) && grid.tiles[cX, cY + 1].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX, cY + 1];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(1) && grid.tiles[cX + 1, cY].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX + 1, cY];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(3) && grid.tiles[cX - 1, cY].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX - 1, cY];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
        }
        else if (directionFacing == 1)
        {
            if (tileExists(0) && grid.tiles[cX, cY + 1].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX, cY + 1];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(1) && grid.tiles[cX + 1, cY].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX + 1, cY];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(2) && grid.tiles[cX, cY - 1].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX, cY - 1];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
        }
        else if (directionFacing == 2)
        {
            if (tileExists(3) && grid.tiles[cX - 1, cY].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX - 1, cY];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(1) && grid.tiles[cX + 1, cY].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX + 1, cY];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(2) && grid.tiles[cX, cY - 1].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX, cY - 1];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
        }
        else
        {
            if (tileExists(0) && grid.tiles[cX, cY + 1].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX, cY + 1];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(3) && grid.tiles[cX - 1, cY].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX - 1, cY];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
            if (tileExists(2) && grid.tiles[cX, cY - 1].tag != "Untagged")
            {
                tilesReturned[tileIndex] = grid.tiles[cX, cY - 1];
                tileIndex++;
            }
            else
            {
                numTilesReturned--;
            }
        }
        Tile[] temp = new Tile[numTilesReturned];
        for (int i = 0; i < numTilesReturned; i++)
        {
            temp[i] = tilesReturned[i];
        }
        tilesReturned = temp;
        return tilesReturned;
    }
    //comment
    protected Tile findTileDirection(Tile cTile, int direction)
    {
        if (direction == 0)
        {
            return grid.tiles[cTile.posX, cTile.posY + 1];
        }
        else if (direction == 1)
        {
            return grid.tiles[cTile.posX + 1, cTile.posY];
        }
        else if (direction == 2)
        {
            return grid.tiles[cTile.posX, cTile.posY - 1];
        }
        else
        {
            return grid.tiles[cTile.posX - 1, cTile.posY];
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //grid = (TileManager)FindObjectOfType(typeof(TileManager));
        grid = GameObject.Find("gridTiles").GetComponent<TileManager>();
        directionFacing = 2;
    }

    // Update is called once per frame
    void Update()
    {
        checkGameOver();
        if (newSpawn)
        {
            adjustDirection();
            updateVelo();
            newSpawn = false;
        }

        //displays entity
        clockTimer++;
        if (dying && clockTimer >= deathTime)
        {
            if (gameObject.GetComponent<Hero>())
                GameObject.Find("GameManager").GetComponent<GameManager>().money += 3;
            Destroy(this.gameObject);
        }

        inBattle = findEnemy();
        if (clockTimer % speed == 0)
        {
            if (!inBattle)
            {
                Move();
                haveMoved = true;
            }
            else
            {
                inBattle = AttackTarget();
            }
        }
        if (curTile)
            updatePos();
    }

    protected void updatePos()
    {
        if (!inBattle && haveMoved)
        {
            cXF += vX;
            cYF += vY;
        }
        transform.position = new Vector3(cXF - 8, cYF, -0.3f);

    }

    protected void updateVelo()
    {
        if (inBattle)
        {
            vX = 0;
            vY = 0;
        }
        else
        {
            if (directionFacing == 0)
            {
                vX = 0;
                vY = velocity;
            }
            else if (directionFacing == 1)
            {
                vX = velocity;
                vY = 0;
            }
            else if (directionFacing == 2)
            {
                vX = 0;
                vY = -velocity;
            }
            else
            {
                vX = -velocity;
                vY = 0;
            }
        }
    }

    public void spawn(Tile spawnTile, int inMaxHealth, int inAttack, int inDefense, int inSpeed)
    {
        prevTile = spawnTile;
        curTile = spawnTile;

        updateXY();
        maxHealth = inMaxHealth;
        health = maxHealth;
        attack = inAttack;
        defense = inDefense;
        speed = (100 - inSpeed);
        velocity = 1f / speed; //1f = smooth
    }

    protected void updateXY()
    {
        cX = curTile.posX;
        cY = curTile.posY;
        cXF = prevTile.posX;
        cYF = prevTile.posY;
    }

    public bool Attacked(int enemyAttack)
    {
        health -= (enemyAttack);// * Mathf.RoundToInt((100 - defense) / 100);
        if (health <= 0)
        {
            deathTime = clockTimer + 5;
            dying = true;
            return true;
        }
        return false;
    }

    public abstract bool findEnemy();

    public void adjustDirection()
    {
        for (int i = 0; i < 3; i++)
        {
            if (tileExists(directionFacing))
            {
                if (findTileDirection(curTile, directionFacing).tag == "Untagged")
                {
                    directionFacing--;
                    if (directionFacing < 0) directionFacing += 4;
                }
                else
                {
                    break;
                }
            }
        }
    }

    public abstract bool AttackTarget();

    public abstract void checkGameOver();
}
