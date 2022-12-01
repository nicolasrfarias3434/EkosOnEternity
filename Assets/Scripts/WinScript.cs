using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Winning();
        }
    }

    public void Winning()
    {
        Debug.Log("Ganaste!! Lograste teletransportarte a la zona segura!!");
    }
}
