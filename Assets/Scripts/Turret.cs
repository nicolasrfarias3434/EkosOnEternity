using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : Cannoner
{
    #region Public Attributes
    public GameObject target;
    public CharacterMoveMode characterMoveMode;
    public float minDistanceToTarget;
    public float speed;

    public GameObject bullet;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet4;
    public Transform bulletOrigin;
    public float coolDown;
    private float countdown;
    public float speedBullet = 2.0f;
    public float rayDistance;
    #endregion

    #region Local Attributes
    private float distance;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TargetDistance();
        LookAtPlayerLerp();
        FollowPlayer();
        DetectEnemy();
    }

    void DetectEnemy()
    {
        Debug.DrawRay(transform.position, transform.forward * rayDistance, Color.red);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward * rayDistance, out hit, rayDistance))
        {
            if (hit.transform.tag == "Player")
            {
                DobleDisparar();
                TripleDisparar();
                CuadrupleDisparar();
            }
        }
    }

    //private void LookAtPlayer()
    //{
    //    if(posJugador != null)transform.LookAt(posJugador.transform);
    //}

    private void TargetDistance()
    {
        distance = Vector3.Distance(transform.position, target.transform.position);
    }
        

    private void LookAtPlayerLerp()
    {
        if (target != null && minDistanceToTarget < distance && distance < 40)
        {
            Quaternion newRotation = Quaternion.LookRotation(target.transform.position - transform.position);
            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, speed * Time.deltaTime);
        }
        else
        {
            if(minDistanceToTarget >= distance)
            {
                Debug.Log("Perdiste! Fuiste capturado");
            }
        }
    }

    private void FollowPlayer()
    {
        
        if (characterMoveMode == CharacterMoveMode.Chasser && minDistanceToTarget < distance && distance < 40)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
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
}
