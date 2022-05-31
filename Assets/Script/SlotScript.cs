using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public GameManager GameManager;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.SlotStart();
    }
}
