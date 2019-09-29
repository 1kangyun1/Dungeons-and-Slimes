using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeSlime : MonoBehaviour
{
    public bool isClone = false;

    public int slimeId;
    public int slimeCost;

    public GameObject sprite;
    public GameObject spritePrefab;

    GameObject summonCircle;
    bool isInCircle = false;

    public SlimeSlime slimeClone;
    bool isDragging = false;
    Vector3 offset;

    public void setSprite(GameObject sprite)
    {
        if (this.sprite != null)
        {
            Destroy(this.sprite);
        }
        this.sprite = Instantiate(sprite, new Vector3(0, 0, 0.05f), Quaternion.identity);
        this.sprite.transform.SetParent(transform, false);
        this.spritePrefab = sprite;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (isClone && isDragging)
        {
            if (col.gameObject.tag == "summoncircle")
            {
                summonCircle = col.gameObject;
                isInCircle = true;
            }
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (isClone && isDragging)
        {
            summonCircle = null;
            isInCircle = false;
        }
    }

    void OnMouseDown()
    {
        if (!isClone && slimeClone == null)
        {
            slimeClone = Instantiate(this);
            slimeClone.name = this.name; 
            slimeClone.transform.SetParent(transform.parent, false);
            slimeClone.isDragging = false;
            slimeClone.isClone = false;
            isClone = true;
            isDragging = true;
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
        }
    }

    void OnMouseDrag()
    {
        if (isClone && isDragging)
        {
            Vector3 newPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f);
            transform.position = Camera.main.ScreenToWorldPoint(newPosition) + offset;
        }
    }

    void OnMouseUp()
    {
        if (isClone && isDragging)
        {
            if (isInCircle)
            {
                transform.position = new Vector3(summonCircle.transform.position.x, summonCircle.transform.position.y + 0.5f, summonCircle.transform.position.z - 0.1f);
                MergeCircle mergeCircle = summonCircle.GetComponent<MergeCircle>();
                mergeCircle.setCurrentSlime(this);
                // add self to circle
            }
            else
            {
                Destroy(gameObject);
                Destroy(this);
            }
        }
    }
}
