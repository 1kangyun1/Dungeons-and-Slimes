﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tile : MonoBehaviour
{

    public float cell_size = 0.64f;
    public Renderer rend;
    public int posX, posY;
    private float x, y, z, r;
    public Tile[] nearTiles;
    public bool start = true;

    void Start()
    {
        x = 0f;
        y = 0f;
        z = 0f;
        rend = GetComponent<Renderer>();

        r = cell_size;

        
    }

    void Update()
    {
        //Move to Start() after map is finalized.
        x = Mathf.Round(transform.position.x / cell_size) * cell_size;
        y = Mathf.Round(transform.position.y / cell_size) * cell_size;
        z = transform.position.z;
        transform.position = new Vector3(x, y, z);

        posX = (int)Mathf.Round(x / 0.64f);
        posY = (int)Mathf.Round(y / -0.64f);

        if (start)
        {
            start = false;

            Collider2D[] nearColliders = Physics2D.OverlapCircleAll(new Vector3(x, y, z), r);
            int i = 0;
            int j = 0;
            nearTiles = new Tile[nearColliders.Length - 1];
            while (i < nearColliders.Length)
            {
                if (!(nearColliders[i].gameObject == this.gameObject))
                {
                    nearTiles[i - j] = nearColliders[i].GetComponent<Tile>();
                }
                else
                {
                    j++;
                }
                i++;
            }
        }
    }

    void OnMouseEnter()
    {
        rend.material.color = new Color(0.5f, 0.5f, 0.5f, 1f);
    }
    void OnMouseExit()
    {
        rend.material.color = new Color(1f, 1f, 1f, 1f);
    }

}
