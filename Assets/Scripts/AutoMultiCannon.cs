using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMultiCannon : Cannoner
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    private Queue<int> heatDegrees = new Queue<int>();
    public Transform bulletOrigin;

    public int heatDegreesPerFire;
    public int overheatLimit;
    private bool overheat;
    public float coolDown;
    private float countdown;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        ResetCooldown();
    }

    // Update is called once per frame
    void Update()
    {
        Temporizador();
        if (heatDegrees.Count * heatDegreesPerFire <= overheatLimit)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                DobleDisparar();
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                TripleDisparar();
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                CuadrupleDisparar();
            }
        }
        else
        {
            overheat = true;
        }
    }

    protected override void Disparar()
    {
        Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
        heatDegrees.Enqueue(heatDegreesPerFire);
    }

    protected override void DobleDisparar()
    {
        Instantiate(bullet, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z - 0.5f), bulletOrigin.rotation);
        Instantiate(bullet2, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z + 0.5f), bulletOrigin.rotation);
        heatDegrees.Enqueue(heatDegreesPerFire);
        heatDegrees.Enqueue(heatDegreesPerFire);
    }

    protected override void TripleDisparar()
    {
        Instantiate(bullet, bulletOrigin.position, transform.rotation);
        Instantiate(bullet2, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z - 0.5f), bulletOrigin.rotation);
        Instantiate(bullet3, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z + 0.5f), bulletOrigin.rotation);
        heatDegrees.Enqueue(heatDegreesPerFire);
        heatDegrees.Enqueue(heatDegreesPerFire);
        heatDegrees.Enqueue(heatDegreesPerFire);
    }

    protected override void CuadrupleDisparar()
    {
        Instantiate(bullet, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y - 0.5f, bulletOrigin.position.z), bulletOrigin.rotation);
        Instantiate(bullet2, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z - 0.5f), bulletOrigin.rotation);
        Instantiate(bullet3, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z + 0.5f), bulletOrigin.rotation);
        Instantiate(bullet4, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y + 0.5f, bulletOrigin.position.z), bulletOrigin.rotation);
        heatDegrees.Enqueue(heatDegreesPerFire);
        heatDegrees.Enqueue(heatDegreesPerFire);
        heatDegrees.Enqueue(heatDegreesPerFire);
        heatDegrees.Enqueue(heatDegreesPerFire);
    }

    private void ResetCooldown()
    {
        overheat = false;
        countdown = coolDown;
    }

    private void Temporizador()
    {
        countdown -= Time.deltaTime;

        for (int i = heatDegreesPerFire; i >= 0; i--)
        {
            if (heatDegrees.Count <= 0) break;
            heatDegrees.Dequeue();
        }

        if (!overheat && countdown <= 0 && heatDegrees.Count * heatDegreesPerFire <= overheatLimit)
        {
            Disparar();
            ResetCooldown();
        }
        else 
        {
            if(countdown <= 0 && heatDegrees.Count <= 0)
                overheat = (heatDegrees.Count >= overheatLimit);
        }
    }
}
