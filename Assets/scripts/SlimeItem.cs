using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeItem : MonoBehaviour
{
    public GameObject wrapperPrefab;
    public GameObject genericSlimePrefab;
    public GameObject genericTextPrefab;

    public GameObject slimeObject;
    public GameObject textObject;
    public int slimeId;
    public int slimeCost;

    public void setSlimeObjectParam(int id, int cost, GameObject sprite)
    {
        slimeObject = Instantiate(wrapperPrefab, new Vector3(10, -10, -0.1f), Quaternion.identity);
        slimeObject.transform.SetParent(transform, false);

        SlimeSlime slimeslime = slimeObject.GetComponent<SlimeSlime>();
        slimeslime.slimeId = id;
        slimeslime.slimeCost = cost;
        slimeslime.setSprite(sprite);
    }

    public void setTextObjectParam(int slimeCost)
    {
        textObject = Instantiate(genericTextPrefab, new Vector3(55, -16, -0.1f), Quaternion.identity);
        textObject.transform.SetParent(transform, false);
        textObject.GetComponent<UnityEngine.UI.Text>().text = "$" + slimeCost;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
