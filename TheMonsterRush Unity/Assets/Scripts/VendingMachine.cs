using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] GameObject monsterCan;
    void Update()
    {
        //Dispense();
    }
/*    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            timerBool = true;
        }   
    }*/
    public void Dispense(Vector3 spawnPosition)
    {
        Instantiate(monsterCan, spawnPosition, Quaternion.identity);            
    }
}
