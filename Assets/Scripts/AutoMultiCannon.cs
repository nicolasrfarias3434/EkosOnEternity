using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMultiCannon : Cannoner
{
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public Transform bulletOrigin;
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

    protected override void Disparar()
    {
        Instantiate(bullet, bulletOrigin.position, bulletOrigin.rotation);
        //Debug.Log("Fire!");
    }

    protected override void DobleDisparar()
    {
        Instantiate(bullet, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z - 0.5f), bulletOrigin.rotation);
        Instantiate(bullet2, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z + 0.5f), bulletOrigin.rotation);
        //Debug.Log("Double Fire!");
    }

    protected override void TripleDisparar()
    {
        Instantiate(bullet, bulletOrigin.position, transform.rotation);
        Instantiate(bullet2, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z - 0.5f), bulletOrigin.rotation);
        Instantiate(bullet3, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z + 0.5f), bulletOrigin.rotation);
        //Debug.Log("Triple Fire!");
    }

    protected override void CuadrupleDisparar()
    {
        Instantiate(bullet, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y - 0.5f, bulletOrigin.position.z), bulletOrigin.rotation);
        Instantiate(bullet2, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z - 0.5f), bulletOrigin.rotation);
        Instantiate(bullet3, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y, bulletOrigin.position.z + 0.5f), bulletOrigin.rotation);
        Instantiate(bullet4, new Vector3(bulletOrigin.position.x, bulletOrigin.position.y + 0.5f, bulletOrigin.position.z), bulletOrigin.rotation);
        //Debug.Log("Quadra Fire!");
    }

    private void ResetCooldown()
    {
        countdown = coolDown;
    }

    private void Temporizador()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Disparar();
            ResetCooldown();
        }
    }
}
