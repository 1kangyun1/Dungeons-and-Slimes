﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float cell_size = 0.64f;
    public Renderer rend;
    public int posX, posY;
    public List<Collider2D> colliders = new List<Collider2D>();

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!colliders.Contains(other))
        {
            colliders.Add(other);
        }
        //Debug.Log(posX);
        //Debug.Log(posY);

        //for (int i = 0; i < colliders.Count; i++)
        //{
        //    if (colliders[i].gameObject.GetComponent<Hero>())
        //        Debug.Log(colliders[i].gameObject.GetComponent<Hero>());
        //}

    }
    void OnTriggerExit2D(Collider2D other)
    {
        colliders.Remove(other);
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        

        
    }

    void Update()
    {
        if (tag == "summon")
        {
            rend.material.color = Color.red;
        }
        else if(tag == "Untagged")
        {
            rend.material.color = new Color(1, 1, 1,1);
        }
        else if (tag == "cross")
        {
            rend.material.color = Color.yellow;
        }
        else if (tag == "path")
        {
            rend.material.color = Color.green;
        }
        else if (tag == "goal")
        {
            rend.material.color = Color.blue;
        }
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

