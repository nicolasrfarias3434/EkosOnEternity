using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGravity : MonoBehaviour
{
    private float rayWalkableDistance;
    public float falseGravity;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //Defino que la distancia a un objeto caminable sería tomado en cuenta si está a cuatro veces el tamaño del personaje. ¿Porqué? No hay por qué.
        rayWalkableDistance = player.transform.localScale.y * 2.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NearestWalkable();
    }

    void NearestWalkable()
    {
        Debug.DrawRay(player.transform.position, player.transform.forward * rayWalkableDistance, Color.blue);
        Debug.DrawRay(player.transform.position, -player.transform.forward * rayWalkableDistance, Color.white);
        Debug.DrawRay(player.transform.position, player.transform.right * rayWalkableDistance, Color.red);
        Debug.DrawRay(player.transform.position, -player.transform.right * rayWalkableDistance, Color.cyan);
        Debug.DrawRay(player.transform.position, player.transform.up * rayWalkableDistance, Color.green);
        Debug.DrawRay(player.transform.position, -player.transform.up * rayWalkableDistance * 20, Color.black);


        RaycastHit frontHit; //red
        //RaycastHit backHit; //green
        RaycastHit leftHit; //cyan
        RaycastHit rightHit; //blue
        RaycastHit topHit; //white
        RaycastHit downHit; //black
        RaycastHit nearestRayHit; //orange

        bool raycastFrontHit = Physics.Raycast(player.transform.position, player.transform.forward, out frontHit, rayWalkableDistance);
        bool raycastLeftHit = Physics.Raycast(player.transform.position, -player.transform.right, out leftHit, rayWalkableDistance);
        bool raycastRightHit = Physics.Raycast(player.transform.position, player.transform.right, out rightHit, rayWalkableDistance);
        bool raycastTopHit = Physics.Raycast(player.transform.position, player.transform.up, out topHit, rayWalkableDistance * 10);
        bool raycastDownHit = Physics.Raycast(player.transform.position, -player.transform.up, out downHit, rayWalkableDistance * 20);
        bool raycastHit = Physics.Raycast(player.transform.position, -player.transform.up, out nearestRayHit, rayWalkableDistance * 20);

        if (raycastFrontHit || raycastLeftHit || raycastRightHit || raycastTopHit || raycastDownHit)
        {
            float minDistance = Math.Min(Math.Min(Math.Min((raycastFrontHit?frontHit.distance:float.MaxValue), (raycastLeftHit?leftHit.distance: float.MaxValue)),(raycastRightHit?rightHit.distance: float.MaxValue)),(raycastTopHit?topHit.distance: float.MaxValue));
            
            if (raycastFrontHit && minDistance == (raycastFrontHit ? frontHit.distance : float.MaxValue) && frontHit.transform.tag == "Walkable") nearestRayHit = frontHit;
            if (raycastLeftHit && minDistance == (raycastLeftHit ? leftHit.distance : float.MaxValue) && leftHit.transform.tag == "Walkable") nearestRayHit = leftHit;
            if (raycastRightHit && minDistance == (raycastRightHit ? rightHit.distance : float.MaxValue) && rightHit.transform.tag == "Walkable") nearestRayHit = rightHit;
            if (raycastTopHit && minDistance == (raycastTopHit ? topHit.distance : float.MaxValue) && topHit.transform.tag == "Walkable") nearestRayHit = topHit;
            raycastHit = true;
        }

        if (raycastHit || raycastDownHit)
        {
            if (raycastHit && raycastDownHit)
            {
                if (nearestRayHit.distance != downHit.distance && nearestRayHit.transform.tag == "Walkable" && nearestRayHit.distance >= 0.0f && nearestRayHit.distance < rayWalkableDistance)
                {
                    //Oriento los pies sobre la pared caminable contra la que choco
                    player.transform.up = RotateLerp(player.transform.up, nearestRayHit.normal);
                }
            }

            if (!raycastFrontHit && raycastDownHit && downHit.transform.tag == "Walkable" && downHit.distance > 1.0f && downHit.distance < rayWalkableDistance * 20)
            {
                if (Math.Round(player.transform.up.x, 2) != Math.Round(downHit.normal.x, 2)
                || Math.Round(player.transform.up.y, 2) != Math.Round(downHit.normal.y, 2)
                || Math.Round(player.transform.up.z, 2) != Math.Round(downHit.normal.z, 2))
                {
                    //Enderezo al personaje, para que quede perpendicular al piso
                    player.transform.up = RotateLerp(player.transform.up, downHit.normal);
                }
                else
                {
                    if (raycastDownHit && downHit.distance > 1.1f && downHit.distance < rayWalkableDistance * 20)
                    {
                        //Aplico la fuerza de gravedad aquí
                        player.transform.position -= falseGravity * Time.deltaTime * 2.0f * player.transform.up;
                    }
                    else
                    {
                        //Aplico ajuste de caída suave para no atravesar el piso y normalizar la distancia al piso
                        player.transform.position -= new Vector3(0.01f * downHit.normal.x, 0.01f * downHit.normal.y, 0.01f * downHit.normal.z);
                    }
                }

            }
        }
    }

    public Vector3 RotateLerp(Vector3 currentAngle, Vector3 targetAngle)
    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime * 5.0f),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime * 5.0f),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime * 5.0f));
        return currentAngle;
    }
}
