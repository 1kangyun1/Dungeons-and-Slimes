﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float cell_size = 0.64f;
    public Renderer rend;
    public int posX, posY;
    SpriteRenderer spr;
    Sprite path;

    void Start()
    {
        rend = GetComponent<Renderer>();
        path = Resources.Load<Sprite>("basic-path");
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //rend.material.color = Color.white;
        //if (tag == "cross" || tag == "path")
        //{
        //    spr.sprite = path;
        //}
    }

    public void rePosition()
    {
        transform.position = new Vector3(posX-8, posY, 0);
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

