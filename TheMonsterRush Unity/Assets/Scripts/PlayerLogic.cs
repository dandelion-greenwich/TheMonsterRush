using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] float minEnergy, maxEnergy;
    public float currentEnergy;
    [SerializeField] float cooldown , divideFactor, holdMonsterValue;
    [SerializeField] int monsterScore;
    public bool hasDrink, isDrinking, gotCaught, isSitting, closeToChair, closeToDispenser, isPressed;
    [SerializeField]Desk currentDesk, inputDesk;
    [SerializeField]VendingMachine vendingMachine;
    Vector3 spawnPosition;
    public AudioManager1 am;
    public Canvas canvas;
    public GameObject MenuPage;
    public GameObject AudioSettingsPanel;
    public GameObject VideoSettingsPanel;
    public GameObject KeybindingsPanel;
    public GameObject GameOverPanel;


    // Start is called before the first frame update
    void Start()
    {
        divideFactor = 1.0f / 4f;
        spawnPosition = GameObject.FindGameObjectWithTag("SpawnPoint").gameObject.transform.position;
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
        if (!gotCaught)
        {
            if (currentDesk != null)
            {
                if (input.isPressed && hasDrink && isSitting && currentDesk.CheckSpace())
                {
                    am.AudioTrigger(AudioManager1.SoundFXCat.Drinking, transform.position, 1f);
                    isDrinking = true;
                    hasDrink = false;
                    StartCoroutine(Drinking());
                   // am.AudioTrigger(AudioManager1.SoundFXCat.EndingNoMonster, transform.position, 1f);
                }
                else if (input.isPressed && isSitting && !hasDrink && !isDrinking && isPressed || !currentDesk.CheckSpace())
                {
                    isPressed = false;
                    isSitting = false;
                    //TODO: stand up animation
                }

                else if (input.isPressed && !isSitting && closeToChair && !isPressed && currentDesk.CheckSpace())
                {
                    am.AudioTrigger(AudioManager1.SoundFXCat.AngryAh, transform.position, 0.1f);
                    isPressed = true;
                    isSitting = true;
                    //TODO: sit down animation
                }
            }
            if (vendingMachine != null)
            {
                if (input.isPressed && closeToDispenser)
                {
                    am.AudioTrigger(AudioManager1.SoundFXCat.Dispenser, transform.position, 1f);
                    StartCoroutine(DispenserRoutine()); // ------> Instatiate Monster in front of the machine after x seconds
                }
            }
        }
    }

    IEnumerator DispenserRoutine()
    {
        yield return new WaitForSeconds(2);
        vendingMachine.Dispense(spawnPosition);
    }

    IEnumerator Drinking()
    {
        yield return new WaitForSeconds(2);        
        isDrinking = false;        
        currentDesk.canAmount++;
        if (currentEnergy < maxEnergy)
        {
            currentEnergy += holdMonsterValue;
            monsterScore += 100;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Chair") 
        {
            closeToChair = true;
            currentDesk = collision.gameObject.GetComponent<Desk>();
        }
/*
        if (collision.gameObject.tag == "VendingMachine")
        {
            closeToDispenser = true;
            vendingMachine = collision.gameObject.GetComponent<VendingMachine>();
        }*/
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Chair")
        {
            closeToChair = false;            
        }

        if (collision.gameObject.tag == "VendingMachine")
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

        if (other.gameObject.tag == "FOV"&& hasDrink && !isSitting || isDrinking)
        {
            gotCaught = true;
            Time.timeScale = 0;
            am.AudioTrigger(AudioManager1.SoundFXCat.EndingNoMonster, transform.position, 1f);
            canvas.enabled = true;
            MenuPage.SetActive(false);
            VideoSettingsPanel.SetActive(false);
            AudioSettingsPanel.SetActive(false);
            KeybindingsPanel.SetActive(false);
            GameOverPanel.SetActive(true);


        }

        if (other.gameObject.tag == "VendingMachine")
        {
            am.AudioTrigger(AudioManager1.SoundFXCat.PressSpace, transform.position, 1f);
            closeToDispenser = true;
            vendingMachine = other.gameObject.GetComponent<VendingMachine>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "VendingMachine")
        {
            closeToDispenser = false;
            vendingMachine = other.gameObject.GetComponent<VendingMachine>();
        }
    }
}
