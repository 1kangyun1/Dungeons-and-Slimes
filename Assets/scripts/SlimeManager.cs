using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeManager : MonoBehaviour
{
    public GameObject slimeItem;

    public class SlimeModel
    {
        public int slimeId;
        public GameObject sprite;
        public int slimeCost;

        public SlimeModel(int slimeId, GameObject sprite, int slimeCost)
        {
            this.slimeId = slimeId;
            this.sprite = sprite;
            this.slimeCost = slimeCost;
        }
    };

    List<SlimeModel> researchedSlimes = new List<SlimeModel>();

    public void addSlime(SlimeModel slime)
    {
        SlimeModel findSlimeModel = researchedSlimes.Find(
        delegate (SlimeModel slimeModel)
        {
            return slimeModel.slimeId == slime.slimeId;
        });

        if (findSlimeModel == null)
        {
            SlimeModel slimeModel = slime;
            researchedSlimes.Add(slimeModel);

            GameObject newItem;
            if (researchedSlimes.Count < 10)
            {
                newItem = Instantiate(slimeItem, new Vector3(
                0,
                (researchedSlimes.Count - 1) * -1f,
                -0.1f), Quaternion.identity);
            } else
            {
                newItem = Instantiate(slimeItem, new Vector3(
                2.4f,
                (researchedSlimes.Count - 10) * -1f,
                -0.1f), Quaternion.identity);
            }
            newItem.transform.SetParent(transform, false);

            SlimeItem slimeObject = newItem.GetComponent<SlimeItem>();
            slimeObject.setSlimeObjectParam(slime.slimeId, slime.slimeCost, slime.sprite);
            slimeObject.setTextObjectParam(slime.slimeCost);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //GameObject newItem = Instantiate(slimeItem, new Vector3(0, 0, -0.1f), Quaternion.identity);
        //newItem.transform.SetParent(transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
