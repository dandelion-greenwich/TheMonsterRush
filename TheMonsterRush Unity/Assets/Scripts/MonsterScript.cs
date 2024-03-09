using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterScript : MonoBehaviour
{
    PlayerLogic playerLogic;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerLogic = other.gameObject.GetComponent<PlayerLogic>();
            playerLogic.hasDrink = true;
            Destroy(gameObject);
        }
    }
}
