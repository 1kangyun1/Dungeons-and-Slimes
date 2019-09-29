using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeCircle : MonoBehaviour
{
    public SlimeSlime currentSlime;

    public void setCurrentSlime(SlimeSlime slime)
    {
        if (currentSlime != null)
        {
            Destroy(currentSlime.gameObject);
            Destroy(currentSlime);
            currentSlime = null;
        }
        currentSlime = slime;
    }

    public SlimeSlime getCurrentSlime()
    {
        return currentSlime;
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
