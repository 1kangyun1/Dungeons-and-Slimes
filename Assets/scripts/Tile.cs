using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    public float cell_size = 0.64f;
    public Renderer rend;
    public int posX, posY;

    void Start()
    {
        rend = GetComponent<Renderer>();
        

        
    }

    void Update()
    {
        
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

