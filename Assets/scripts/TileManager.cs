using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public Tile tilePrefab;
    public Tile[,] tiles;
    public int width=17, height=30;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void populateTiles()
    {
        tiles = new Tile[width, height];
        Tile temp;
        int i = 0;
        int j = 0;

        Collider2D[] nearColliders = Physics2D.OverlapBoxAll(new Vector2(0, 0), new Vector2(80, 80), 0);
        while (i < nearColliders.Length)
        {
            if (!(nearColliders[i].gameObject == tilePrefab.gameObject))
            {
                temp = nearColliders[i].GetComponent<Tile>();
                tiles[temp.posX, temp.posY] = temp;
                j++;

            }
            i++;
            if (j == 510)
            {
                break;
            }
        }
    }
}
