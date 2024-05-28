using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;



    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Found more than one game manager in the scene");
        }

    }

    //general fields
    float timer;
    public float spawnMoneyRate;



    //Weight fields
    public GameObject weight_text;
    TextMeshProUGUI weightTMP;
    public int[] weights_to_increase_size;
    public float unit_calories; //calories in one patty
    public float fat_man_weight;
    private float weight_since_last_spawn;
    private float[] weightInLastSecond;
    TextMeshProUGUI unitCaloriesTMP;
    public GameObject unitCaloriesText;


    //Upgrade fields
    public GameObject upgrades;
    public float[,] upgrade_values = { { 1.0f, 10.0f, 100.0f }, { 1.0f, 2.0f, 30.0f } };

    //Fatman fields
    public GameObject fatman;
    public FatManScript fatManScript;

    //Money fields
    TextMeshProUGUI moneyTMP;
    [SerializeField] private float moneyAmount;
    public GameObject moneyTextObject;
    private MoneySpawnerScript moneySpawnerScript;
    public Canvas disappearingMoneyCanvas;
    private DisappearingMoneyCanvasScript disappearingMoneyCanvasScript;
    public float minimumIncreaseInMoneyToSpawn;

    //Sound fields
    public AudioSource munchSound;
    public AudioSource bubblePop;


    //UI Fields
    public GameObject UpgradesMenu;

    //Scene fields
    
    //test





    //public FatManScript fatManScript;
    // Start is called before the first frame update
    void Start()
    {
        fat_man_weight = FatManScript.instance.weight;
        weight_since_last_spawn = fat_man_weight;
        //moneySpawnerScript = (GameObject.FindWithTag("MoneySpawner")).GetComponent<MoneySpawnerScript>();
        weightTMP = weight_text.GetComponent<TextMeshProUGUI>();
        fatManScript = fatman.GetComponent<FatManScript>();
        moneyTMP = moneyTextObject.GetComponent<TextMeshProUGUI>();
        disappearingMoneyCanvasScript = disappearingMoneyCanvas.GetComponent<DisappearingMoneyCanvasScript>();
        unitCaloriesTMP = unitCaloriesText.GetComponent<TextMeshProUGUI>();
        UpdateUI(true, true, true);

    }

    // Update is called once per frame
    void Update()
    {
        SpawnMoney();
    }

    //Script called when one of the idle patties from the 
    //barbecue hits the fatman
    public void PattyEaten()
    {


        //Querry current fatman weight
        float newWeight = FatManScript.instance.weight + Upgrades.CaloriesToWeight(unit_calories);
        
        //Call weight change function in fatman
        FatManScript.instance.WeightChanged(newWeight);
        fat_man_weight = newWeight;
        UpdateUI(false, true, false);
        Debug.Log(fat_man_weight);


        


        //Play a sound of fatman eating
        if (!munchSound.isPlaying)
            {
            munchSound.pitch = Random.Range(0.85f, 1.05f);
            munchSound.Play(); }
       
    }



    //Called whenever any upgrade is clicked? Or bought? Or any state of the upgrades
    // is different
    public void UpgradeBought(int id)
    {
        //Querry current Upgrades (Static fields of Upgrades class)
        Upgrades.upgradeLevels[id] += 1;
        moneyAmount -= Upgrades.upgradeCosts[id];
        Upgrades.IncreasePrice(id);
        unit_calories = Upgrades.ComputeUnitCalories();
        UpdateUI(true, false, true);
        
        bubblePop.Play();
        //change upgradedata (By changing fields)

        //change money amout and decrease by the cost

        //update UI (Upgrades changed = true)


    }

    //Called whenever any changes to weight, money, or upgrades are made
    public void UpdateUI(bool upgradesChanged = false, bool weightChanged = false, bool currencyChanged = false)
    {
        //Querry data on upgrades, weight, and money
        //UI.UpdateUI(upgradesChanged, weightChanged, currencyChanged);


        //Change UI of data that has been modified


        //if weight has been changed
        if (weightChanged)
        {
            //update the weight text
            //GameObject weightTextGameObject = GameObject.FindWithTag("MoneyText");
            //TextMeshProUGUI weightTextComponent = weightTextGameObject.GetComponent<TextMeshProUGUI>();
            weightTMP.text = BigNumber.NumToBigString(FatManScript.instance.weight) ;  // + " And unit calories = " + unit_calories;
        }

        //deal with weight seperately as both upgrades and money changes affect
        //which upgrades can be bought
        if (upgradesChanged || currencyChanged)
        {
            UpdateButtonsUI();
            moneyTMP.text = "$" + BigNumber.NumToBigString(moneyAmount);
            unitCaloriesTMP.text = "" + BigNumber.NumToBigString(unit_calories);
        }

    }
    //Helper function for update UI which updates the buttons' cost and level in UI
    public void UpdateButtonsUI()
    {
        int[] levels = Upgrades.upgradeLevels;
        int[] costs = Upgrades.upgradeCosts;


        GameObject upgradeButtonsParent = GameObject.FindWithTag("UpgradeButtonsParent");
        GameObject[] upgradeButtons = GameObject.FindGameObjectsWithTag("UpgradeButton");
        if (upgradeButtons != null)
        {
            foreach (GameObject upgradeButtonGameObject in upgradeButtons)
            {
                Button upgradeButton = upgradeButtonGameObject.GetComponent<Button>();
                GameObject upgradeButtonTextGameObject = upgradeButtonGameObject.transform.GetChild(0).gameObject;
                TextMeshProUGUI upgradeButtonTextComponent = upgradeButtonTextGameObject.GetComponent<TextMeshProUGUI>();
                UpgradeButtonScript upgradeButtonScript = upgradeButtonGameObject.GetComponent<UpgradeButtonScript>();
                upgradeButtonTextComponent.text = "$" + BigNumber.NumToBigString(costs[upgradeButtonScript.id]);

                if (moneyAmount >= costs[upgradeButtonScript.id])
                {

                    upgradeButton.interactable = true;
                }
                else
                {
                    upgradeButton.interactable = false;
                }
            }

            //for (int i = 0; i < upgradeButtonsParent.transform.childCount; i++)
            //{

            //    GameObject upgradeButton = upgradeButtonsParent.transform.GetChild(i).gameObject;
            //    GameObject upgradeTextGameObject = upgradeButton.transform.GetChild(0).gameObject;
            //    TextMeshProUGUI upgradeButtonText = upgradeTextGameObject.GetComponent<TextMeshProUGUI>();
            //    upgradeButtonText.text = "UPGRADE" + i + "\n Cost:" + costs[i] + "\n Level:" + levels[i];
            //    Button upgradeButtonComponent = upgradeButton.GetComponent<Button>();
            //    if (moneyAmount >= costs[i])
            //    {

            //        upgradeButtonComponent.interactable = true;
            //    }
            //    else
            //    {
            //        upgradeButtonComponent.interactable = false;
            //    }

            //}
        }
        else
        {
            print("upgradeButtonsParent not found");
        }

    }

    //Called when fatman reaches a weight too big or something
    public void LoadNewScene()
    {

    }

    // Called every couple seconds (According to spawnMoneyRate) and
    //spawns money if enough money has been made since last spawn
    private void SpawnMoney()
    {
        if (timer > (1 / spawnMoneyRate) * 10)
        {
            if (fat_man_weight - weight_since_last_spawn >= minimumIncreaseInMoneyToSpawn )
            {
                float value = Upgrades.weightToMoney(fat_man_weight - weight_since_last_spawn);
                //moneySpawnerScript.SpawnMoney(fat_man_weight - weight_since_last_spawn, 1.0f);
                weight_since_last_spawn = fat_man_weight;
                timer = 0;
                disappearingMoneyCanvasScript.SpawnMoneyText(value);
                MoneyAmountChanged(value);



            }
        }
        timer += Time.deltaTime;

    }

    public void MoneyAmountChanged(float value)
    {
        moneyAmount += value;
        UpdateUI(false, false, true);
    }
}

