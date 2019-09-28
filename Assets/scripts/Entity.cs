using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public int health, maxHealth, attack, defense, speed; //stats
    public int cX, cY; //character x and y location on grid
    public int directionFacing; //0 = North, 1 = East, 2 = South, 3 = West
    protected TileManager grid;
    public Tile prevTile;
    public Tile curTile;
    public int id;
    protected int clockTimer = 0;
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
                Move();
            }
        }
        else
        {
            Tile[] availableTiles = findAvailableTiles();
            int numAvail = availableTiles.Length;
            int choice = UnityEngine.Random.Range(0, numAvail);
            directionFacing = updateDirection(availableTiles[choice]);
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

    // Start is called before the first frame update
    void Start()
    {
        grid = (TileManager)FindObjectOfType(typeof(TileManager));
        directionFacing = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (curTile)
            updatePos();
        clockTimer++;
        if (clockTimer % speed == 0)
        {
            Move();
        }
    }

    protected void updatePos()
    {
        transform.position = new Vector3((float)(cX - 8), (float)cY, -0.3f);
        //Debug.Log(transform.position.x);
        //Debug.Log(transform.position.y);
        //Debug.Log(transform.position.z);


    }

    public void spawn(Tile spawnTile, int inMaxHealth, int inAttack, int inDefense, int inSpeed)
    {
        curTile = spawnTile;
        updateXY();
        maxHealth = inMaxHealth;
        health = maxHealth;
        attack = inAttack;
        defense = inDefense;
        speed = (100 - inSpeed);
    }

    protected void updateXY()
    {
        cX = curTile.posX;
        cY = curTile.posY;
    }
}
