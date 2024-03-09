using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desk : MonoBehaviour
{
    [SerializeField] int canAmount, maxCanAmount;

    public bool CheckSpace()
    {
        if (canAmount < maxCanAmount)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
