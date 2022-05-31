using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusSlot : MonoBehaviour
{

    public NewBehaviourScript Manager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Manager.SlotStart();
    }
}
