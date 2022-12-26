using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public Transform OtherPortal;
    public Rigidbody playerRBody;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            Vector3 PlayerFromPortal = transform.InverseTransformPoint(player.transform.position);

            if(PlayerFromPortal.z <= 0.02)
            {
                player.transform.position = OtherPortal.position + new Vector3(-PlayerFromPortal.x, +PlayerFromPortal.y,-PlayerFromPortal.z);
                player.transform.eulerAngles = Vector3.up * (OtherPortal.eulerAngles.y - (transform.eulerAngles.y - player.transform.eulerAngles.y) + 180);
                playerRBody.velocity = -OtherPortal.transform.forward * playerRBody.velocity.y * 2;
            }
        }
    }
}
