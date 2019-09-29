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

    public void addSlime(int slimeId, GameObject sprite, int slimeCost)
    {
        SlimeModel findSlimeModel = researchedSlimes.Find(
        delegate (SlimeModel slimeModel)
        {
            return slimeModel.slimeId == slimeId;
        });

        if (findSlimeModel == null)
        {
            SlimeModel slimeModel = new SlimeModel(slimeId, sprite, slimeCost);
            researchedSlimes.Add(slimeModel);

            GameObject newItem = Instantiate(slimeItem, new Vector3(
                0, 
                researchedSlimes.Count * -10f,
                0), Quaternion.identity);
            newItem.transform.SetParent(transform, false);

            SlimeItem slimeObject = newItem.GetComponent<SlimeItem>();
            SlimeSlime slimeslime = slimeObject.slimeObject.GetComponent<SlimeSlime>();
            slimeslime.slimeId = slimeId;
            slimeslime.setSprite(sprite);
            slimeObject.textObject.GetComponent<UnityEngine.UI.Text>().text = "$" + slimeCost;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject newItem = Instantiate(slimeItem, new Vector3(0, 0, -0.1f), Quaternion.identity);
        newItem.transform.SetParent(transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
