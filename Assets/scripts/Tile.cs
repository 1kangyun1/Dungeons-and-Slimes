using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Tile : MonoBehaviour
{

    public float cell_size = 0.64f;
    public Renderer rend;
    public int posX, posY;
    public List<Collider2D> colliders = new List<Collider2D>();
    public BoxCollider2D myCollider;
    SpriteRenderer spr;
    Sprite path; Sprite wall; Sprite goal; Sprite door;

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
        myCollider = GetComponent<BoxCollider2D>();
        myCollider.size = new Vector2(0.98f, 0.98f);
        
        path = Resources.Load<Sprite>("basic-path");
        wall = Resources.Load<Sprite>("wall-1");
        goal = Resources.Load<Sprite>("teal-path");
        door = Resources.Load<Sprite>("door-2");
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // To reset color bindings on map tile textures
        rend.material.color = Color.white;

        // To set map textures en masse
        if (tag == "Untagged")
        {
            spr.sprite = wall;
        }
        else if (tag == "cross" || tag == "path")
        {
            spr.sprite = path;
        }
        else if (tag == "goal")
        {
            spr.sprite = goal;
        }
        else if (tag == "summon")
        {
            spr.sprite = door;
        }
        else if (tag == "slimeSpawn")
        {
            spr.sprite = path;           
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

