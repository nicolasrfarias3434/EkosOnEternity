using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletOrigin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            Disparar();
        }
    }

    private void Disparar()
    {
        Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
        //Debug.Log("Fire!");
    }
}
