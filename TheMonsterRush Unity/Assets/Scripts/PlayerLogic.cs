using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] float minEnergy, maxEnergy;
    public float currentEnergy;
    [SerializeField] float cooldown , divideFactor, holdMonsterValue;
    [SerializeField] int monsterScore;
    public bool hasDrink, isDrinking, gotCaught, isSitting, closeToChair, closeToDispenser;


    // Start is called before the first frame update
    void Start()
    {
        divideFactor = 1.0f / 4f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isSitting)
        {
            currentEnergy -= Time.deltaTime * divideFactor;
        }
        
        CheckEnergy();
    }

    public void CheckEnergy()
    {        
        if(currentEnergy <= minEnergy / 4f)
        {
            divideFactor = 1f / 3f;
        }
        else
        {
            divideFactor = 1f / 4f;
        }
        
        if (currentEnergy <= minEnergy / 3f)
        {
            divideFactor = 1f / 2f;
        }
        
        if (currentEnergy <= minEnergy / 2f)
        {
            divideFactor = 1f;
        }

        if (currentEnergy <= minEnergy)
        {
            Destroy(gameObject);
        }       
    }

    public void OnFire(InputValue input)
    {
        if (input.isPressed && hasDrink && isSitting)
        {
            monsterScore += 100;
            hasDrink = false;
            if(currentEnergy < maxEnergy)
            {
                currentEnergy += holdMonsterValue;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else if(input.isPressed && isSitting && !hasDrink)
        {
            isSitting = false;
            //TODO: stand up animation
        }

        if(input.isPressed && !isSitting && closeToChair)
        {
            //TODO: if(Desk.canAmount < Desk.maxCanAmount){} <--- this might can go on the previous check, maybe a method that returns a boolean for availability of the desk
            isSitting = true;
            //TODO: sit down animation
        }

        if(input.isPressed && closeToDispenser)
        {
            //TODO: VendingMachine.Dispense(); ------> Instatiate Monster in front of the machine after x seconds
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chair") 
        {
            closeToChair = true;
        }
        else
        {
            closeToChair = false;
        }

        if (collision.gameObject.tag == "Dispenser")
        {
            closeToDispenser = true;
        }
        else
        {
            closeToDispenser = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Monster")
        {
            hasDrink = true;
            Destroy(other.gameObject);
        }
    }
}
