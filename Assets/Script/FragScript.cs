using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FragScript : MonoBehaviour
{
    public HitMissManager Manager;
    public bool flag;
    public int rato;

    public void SetRato (int rato)
    {
        this.rato = rato;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (flag)
        {
            Debug.Log("“–‚½‚è");
            Manager.Hit(rato);
        }
        else
        {
            Debug.Log("‚Í‚¸‚ê");
        }
    }
}
