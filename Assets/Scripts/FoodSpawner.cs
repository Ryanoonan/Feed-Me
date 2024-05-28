using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    //rand = Random();
    public GameObject fatman;

    public GameObject[] foods;

    private int count; //TODO: delete this as increments forever
    public float upForce;
    public GameObject destination;
    [SerializeField] private float randomFactor;
    

   // Rigidbody foodRigidbody;
    // Start is called before the first frame update

    public void SpawnFood() {

        //TODO: Make food spawn somewhat randomly in circle
        GameObject foodInstance = (GameObject)Instantiate(foods[count % foods.Length], transform);
        count++;
        SetGlobalScale(foodInstance.transform, (new Vector3(1, 1, 1)) * Upgrades.CurrentSizeOfFood());
        Rigidbody foodRigidbody = foodInstance.GetComponent<Rigidbody>();
        foodRigidbody.AddForce(new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f))* randomFactor);
       

    }

    public void SetGlobalScale(Transform transform, Vector3 globalScale)
    {
        transform.localScale = Vector3.one;
        transform.localScale = new Vector3(globalScale.x / transform.lossyScale.x, globalScale.y / transform.lossyScale.y, globalScale.z / transform.lossyScale.z);
    }


}
