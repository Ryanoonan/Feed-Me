using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisappearingMoneyCanvasScript : MonoBehaviour
{
    public TextMeshProUGUI disappearingMoneyText;
    [SerializeField] private float spawnRange;


    public void SpawnMoneyText(float value)
    {

        TextMeshProUGUI moneyTextInstance = Instantiate(disappearingMoneyText, transform);
        moneyTextInstance.text = "$" + BigNumber.NumToBigString(value);
        //Since the lossy scale is only ever updated when the fatman grows, the x y and z should
        // always be the same?
        moneyTextInstance.transform.position += new Vector3(Random.Range(-spawnRange,spawnRange), Random.Range(-spawnRange,spawnRange), 0) * moneyTextInstance.transform.lossyScale.x; 
        Rigidbody moneyTextInstanceRigidBody = moneyTextInstance.GetComponent<Rigidbody>();
        moneyTextInstanceRigidBody.AddForce(Vector3.up * 25);

    }
}
