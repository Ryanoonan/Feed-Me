using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatManScript : MonoBehaviour
{

    private void Awake()
    {
        if (FatManScript.instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.Log("Found more than one game manager in the scene");
        }

    }


    public static FatManScript instance { get; private set; }
    public GameObject fatman;
    float current_height = 1f;

    public float weight = 30f;
    public float scaleFactor = 1.0f;
    public GameObject testMenu;
    public static float[] weightClasses = {30, 65, 100, 200, 500,1000, 2000, 5000, 50000, 400000,2000000, 10000000,100000000,3000000000};
    public static int[] newZoneWeightClassIndexes = { 5, 10 };
    float current_size;
    private Vector3 start_size;
    public GameObject[] SceneDestinations;
    private int currentLocationIndex = 0;
    private int currentWeightClassIndex = 0;
    private float[] weightRatioForZone = {1f,1/20f,1/50f};


    private void Start()
    {
        start_size = transform.localScale;
    }


    public void IncreaseSize()
    {
        fatman.transform.localScale = start_size * Mathf.Pow((float) weightClasses[currentWeightClassIndex] / (float) weightClasses[0], 1 / 3f) ;

        // This part probably only works for cube
        float offset = (current_height * scaleFactor) / 2 - (current_height / 2);
        Vector3 translate = new Vector3(0f, offset, 0f);
        fatman.transform.position += (translate);
        current_height *= scaleFactor;


    }


    //Called when the weight is changed, checks if fatman should increase size,
    // or load a new scene
    public void WeightChanged(float newWeight)
    {

        weight = newWeight;


        bool inNewWeightCLass = false;
        // if new weight is is "new weight class", then increase size
        //print(currentWeightClassIndex);
        if (currentWeightClassIndex != weightClasses.Length - 1)
        {
            while (newWeight >= weightClasses[currentWeightClassIndex + 1])
            {
                currentWeightClassIndex += 1;
                inNewWeightCLass = true;
                if (currentWeightClassIndex == weightClasses.Length - 1)
                {
                    break;
                }
            }
        }

        

        if (inNewWeightCLass)
        {
            LoadNewZone();
            IncreaseSize();
            

        }

        // If new weight is in new scence class, then change scene


    }

    public float GetWeight()
    {
        return weight;

    }

    private void LoadNewZone()
    {
        if (currentWeightClassIndex >5 & currentWeightClassIndex < 10)
        {
            currentLocationIndex = 1;
            fatman.transform.position = SceneDestinations[0].transform.position;
        }

        if (currentWeightClassIndex >= 10)
        {
            currentLocationIndex = 2;
            fatman.transform.position = SceneDestinations[1].transform.position;
        }
    }

    public float GetCurrentSizeRatio()
    {
        return weightRatioForZone[currentLocationIndex];
    }


}
