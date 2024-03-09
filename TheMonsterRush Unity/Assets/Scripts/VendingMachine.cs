using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    [SerializeField] GameObject monsterCan, frontSide, player;
    [SerializeField] bool timerBool = false;
    [SerializeField] float timer, setTimer;
    void Update()
    {
        Dispense();
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            timerBool = true;
        }   
    }
    public void Dispense()
    {
        if (timerBool == true)
        {
            timer += Time.deltaTime;
            if (timer >= setTimer)
            {
                Instantiate(monsterCan, frontSide.transform.position, Quaternion.identity);
                timer = 0;
                timerBool = false;
            }
        }
    }
}
