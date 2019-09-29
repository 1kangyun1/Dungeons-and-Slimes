using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeButton : MonoBehaviour
{
    GameObject[] mergeCircles;
    GameObject mergeResult;

    // Start is called before the first frame update
    void Start()
    {
        mergeCircles = GameObject.FindGameObjectsWithTag("summoncircle");
        mergeResult = GameObject.FindWithTag("mergeresult");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        List<int> slimeIds = new List<int>();
        int cost = 0;

        foreach (GameObject go in mergeCircles)
        {
            MergeCircle mc = go.GetComponent<MergeCircle>();
            slimeIds.Add(mc.getCurrentSlime().slimeId);
            cost += mc.getCurrentSlime().slimeCost;
            mc.setCurrentSlime(null);
        }

        SlimeMergeResult smr = mergeResult.GetComponent<SlimeMergeResult>();
        smr.setSlime(slimeIds[0], slimeIds[1], cost);
    }

    void OnMouseUp()
    {
    }
}
