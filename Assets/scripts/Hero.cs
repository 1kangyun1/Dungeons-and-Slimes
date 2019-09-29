using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    public override bool findEnemy()
    {
        int directionIndex = 0;
        if (tileExists(directionIndex) && grid.tiles[cX, cY + 1].tag != "Untagged")
        {
            //Collision2D[] currentCollide = 
            //if (grid.tiles[cX, cY + 1].GetComponent<BoxCollider2D>.)
        }
        directionIndex++;
        if (tileExists(directionIndex) && grid.tiles[cX + 1, cY].tag != "Untagged")
        {

        }
        directionIndex++;
        if (tileExists(directionIndex) && grid.tiles[cX, cY - 1].tag != "Untagged")
        {

        }
        directionIndex++;
        if (tileExists(directionIndex) && grid.tiles[cX - 1, cY].tag != "Untagged")
        {

        }
        return false;

    }

}
