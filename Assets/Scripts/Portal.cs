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
                //Quaternion ttt = Quaternion.Inverse(transform.rotation) * player.transform.rotation;
                player.transform.eulerAngles = Vector3.up * (OtherPortal.eulerAngles.y - (transform.eulerAngles.y - player.transform.eulerAngles.y) + 180);
                //Vector3 CamLEA = Camera.main.transform.localEulerAngles;
                Camera.main.transform.localEulerAngles = Vector3.right * (OtherPortal.eulerAngles.x + Camera.main.transform.eulerAngles.x);

                //Vector3 velocidadLocalPlayer = transform.InverseTransformPoint(playerRBody.velocity);
                playerRBody.velocity = -OtherPortal.transform.forward * playerRBody.velocity.y * 2;
            }
        }
    }
}
