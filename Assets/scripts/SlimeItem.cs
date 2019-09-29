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

    // Start is called before the first frame update
    void Start()
    {
        slimeObject = Instantiate(wrapperPrefab, new Vector3(10, -10, -0.1f), Quaternion.identity);
        slimeObject.transform.SetParent(transform, false);
        slimeObject.GetComponent<SlimeSlime>().setSprite(genericSlimePrefab);

        textObject = Instantiate(genericTextPrefab, new Vector3(55, -16, -0.1f), Quaternion.identity);
        textObject.transform.SetParent(transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
