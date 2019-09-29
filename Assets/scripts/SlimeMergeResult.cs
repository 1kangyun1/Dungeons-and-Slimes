using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMergeResult : MonoBehaviour
{
    public GameObject slimeSprite01;
    public GameObject slimeSprite02;
    public GameObject slimeSprite03;
    public GameObject slimeSprite04;
    public GameObject slimeSprite05;
    public GameObject slimeSprite06;
    public GameObject slimeSprite07;
    public GameObject slimeSprite08;
    public GameObject slimeSprite09;
    public GameObject slimeSprite10;
    public GameObject slimeSprite11;
    public GameObject slimeSprite12;
    public GameObject slimeSprite13;
    public GameObject slimeSprite14;
    public GameObject slimeSprite15;

    int resultSlimeId;
    SlimeManager.SlimeModel resultSlimeModel;
    GameObject currentSlimeObject;
    GameObject slimeManager;
    GameManager gm;

    public Dictionary<string, int> slimeFormula = new Dictionary<string, int>()
    {
        { "1,1", 3 },
        { "1,2", 4 },
        { "1,3", 5 },
        { "1,4", 5 },
        { "1,5", 6 },
        { "2,2", 4 },
        { "3,5", 4 },
        { "6,7", 8 },
        { "7,7", 6 },
        { "4,6", 7 },
        { "1,7", 8 },
        { "8,7", 9 },
        { "8,6", 9 },
        { "9,9", 10 },
        { "7,9", 10 },
        { "8,9", 10 },
        { "10,8", 11 },
        { "10,9", 11 },
        { "10,11", 12 },
        { "11,8", 12 },
        { "11,9", 13 },
        { "11,7", 13 },
        { "13,12", 14 },
        { "14,13", 15 }
    };
    public Dictionary<int, SlimeManager.SlimeModel> slimeList;

    Vector3 initPosition;
    Vector3 hidePosition = new Vector3(-9999999f, -99999999f, 0);

    public void show()
    {
        transform.position = initPosition;
    }

    public void hide()
    {
        transform.position = hidePosition;
    }

    public void setSlime(int slimeId1, int slimeId2, int cost)
    {
        if (true)//gm.spendMoney(cost))
        {
            string key1 = "" + slimeId1 + "," + slimeId2;
            string key2 = "" + slimeId2 + "," + slimeId1;
            string key = getKey(key1, key2);
            if (key != null)
            {
                resultSlimeId = slimeFormula[key];
                resultSlimeModel = slimeList[resultSlimeId];

                if (currentSlimeObject != null)
                {
                    Destroy(currentSlimeObject);
                }
                currentSlimeObject = Instantiate(resultSlimeModel.sprite, new Vector3(0, 0, -0.5f), Quaternion.identity);
                currentSlimeObject.transform.SetParent(transform, false);
                currentSlimeObject.transform.localScale = new Vector3(
                    currentSlimeObject.transform.localScale.x*0.1f, 
                    currentSlimeObject.transform.localScale.y*0.1f,
                    1);
                slimeManager.GetComponent<SlimeManager>().addSlime(resultSlimeModel);

                show();
                StartCoroutine(StartCountdown(5));
            }
        }
    }

    private string getKey(string key1, string key2)
    {
        if (slimeFormula.ContainsKey(key1))
        {
            return key1;
        } else if (slimeFormula.ContainsKey(key2))
        {
            return key2;
        } else
        {
            return null;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        initPosition = transform.position;
        hide();

        slimeManager = GameObject.FindWithTag("slimemanager");

        slimeList = new Dictionary<int, SlimeManager.SlimeModel>()
        {
            { 1, new SlimeManager.SlimeModel(1, slimeSprite01, 1) },
            { 2, new SlimeManager.SlimeModel(2, slimeSprite02, 1) },
            { 3, new SlimeManager.SlimeModel(3, slimeSprite03, 2) },
            { 4, new SlimeManager.SlimeModel(4, slimeSprite04, 2) },
            { 5, new SlimeManager.SlimeModel(5, slimeSprite05, 3) },
            { 6, new SlimeManager.SlimeModel(6, slimeSprite06, 3) },
            { 7, new SlimeManager.SlimeModel(7, slimeSprite07, 4) },
            { 8, new SlimeManager.SlimeModel(8, slimeSprite08, 4) },
            { 9, new SlimeManager.SlimeModel(9, slimeSprite09, 5) },
            { 10, new SlimeManager.SlimeModel(10, slimeSprite10, 5) },
            { 11, new SlimeManager.SlimeModel(11, slimeSprite11, 10) },
            { 12, new SlimeManager.SlimeModel(12, slimeSprite12, 10) },
            { 13, new SlimeManager.SlimeModel(13, slimeSprite13, 10) },
            { 14, new SlimeManager.SlimeModel(14, slimeSprite14, 10) },
            { 15, new SlimeManager.SlimeModel(15, slimeSprite15, 10) }
        };

        SlimeManager sm = slimeManager.GetComponent<SlimeManager>();
        sm.addSlime(slimeList[1]);
        sm.addSlime(slimeList[2]);
        sm.addSlime(slimeList[3]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float currCountdownValue;
    public IEnumerator StartCountdown(float countdownValue = 10)
    {
        currCountdownValue = countdownValue;
        while (currCountdownValue > 0)
        {
            Debug.Log("Countdown: " + currCountdownValue);
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
        }

        hide();
    }
}
