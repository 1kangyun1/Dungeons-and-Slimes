using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Entity
{
    public override bool findEnemy()
    {
        int directionIndex = 0;
        Tile currentSearch;
        for (int j = 0; j < 4; j++)
        {
            if (tileExists(directionIndex))
            {
                currentSearch = findTileDirection(curTile, j);
                if (currentSearch.tag != "Untagged")
                {
                    if (currentSearch.colliders.Count > 0)
                    {
                        for (int i = 0; i < currentSearch.colliders.Count; i++)
                        {
                            if (currentSearch.colliders[i].gameObject.GetComponent<Slime>())
                            {
                                target = currentSearch.colliders[i].gameObject.GetComponent<Slime>();
                                return true;
                            }
                        }
                    }
                }
            }
        }
        return false;

    }
    public override bool AttackTarget()
    {
        return target.Attacked(attack);
    }
    public override void checkGameOver()
    {
        if (cY == 1 && (cX == 7 || cX == 8))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
        }
    }

}
