using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseGravity : MonoBehaviour
{
    public float rayWalkableDistance;
    public float falseGravity;
    public GameObject player;
    public float speed;
    //private float step = 0.0f;
    private Quaternion verticalPosition;
    private Quaternion downRotation = new Quaternion(0.0f,0.0f,0.0f,1.0f);
    private Quaternion frontRotation = new Quaternion(0.5f,0.5f,0.5f,-0.5f);
    //public new Transform transform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        NearestWalkable();
    }

    void NearestWalkable()
    {
        Debug.DrawRay(player.transform.position, player.transform.forward * rayWalkableDistance, Color.red);
        Debug.DrawRay(player.transform.position, -player.transform.forward * rayWalkableDistance, Color.green);
        Debug.DrawRay(player.transform.position, player.transform.right * rayWalkableDistance, Color.blue);
        Debug.DrawRay(player.transform.position, -player.transform.right * rayWalkableDistance, Color.cyan);
        Debug.DrawRay(player.transform.position, player.transform.up * rayWalkableDistance, Color.white);
        Debug.DrawRay(player.transform.position, -player.transform.up * rayWalkableDistance * 40, Color.black);


        RaycastHit frontHit; //red
        //RaycastHit backHit; //green
        RaycastHit leftHit; //cyan
        RaycastHit rightHit; //blue
        //RaycastHit topHit; //white
        RaycastHit downHit; //black

        bool raycastFrontHit = Physics.Raycast(player.transform.position, player.transform.forward, out frontHit, rayWalkableDistance);
        bool raycastLeftHit = Physics.Raycast(player.transform.position, -player.transform.right, out leftHit, rayWalkableDistance);
        bool raycastRightHit = Physics.Raycast(player.transform.position, player.transform.right, out rightHit, rayWalkableDistance);
        //bool raycastTopHit = Physics.Raycast(player.transform.position, player.transform.up, out topHit, rayWalkableDistance * 10);
        bool raycastDownHit = Physics.Raycast(player.transform.position, -player.transform.up, out downHit, rayWalkableDistance * 40);

        //Vector3 rotateOnHit = new Vector3();
        Quaternion rotateOnHitQua = new Quaternion();

        if (raycastFrontHit)
        {
            //Debug.Log(string.Format("frontHit {0} - frontHit.transform.rotation {1} - transform.position {2} - frontHit.normal {3} - transform.rotation {4}",frontHit, frontHit.transform.rotation, transform.position, frontHit.normal, transform.rotation));
            if (frontHit.transform.tag == "Walkable" && frontHit.distance >= 0.0f && frontHit.distance < 2.0f)
            {
                Debug.Log(string.Format("frontHit {0} player.rotation {1} normal {2} frontHit.rotation {3} player.eulerAngles", frontHit.transform, player.transform.rotation, frontHit.normal, frontHit.transform.rotation, player.transform.eulerAngles));
                //rotateOnHit = CheckOnHitWalkable(frontHit, player.transform);
                rotateOnHitQua = CheckOnHitWalkableQua(frontHit, player.transform);
                //Vector3 downRotation = new Vector3(rotateOnHit.x, player.transform.eulerAngles.y, rotateOnHit.z);
                //player.transform.eulerAngles = RotateLerp(player.transform.eulerAngles, rotateOnHit);
                player.transform.rotation = RotateQLerp(player.transform.rotation, rotateOnHitQua);
            }
        }
        //else
        //{
        //    if (Physics.Raycast(player.transform.position, -player.transform.forward, out backHit, rayWalkableDistance))
        //    {
        //        Debug.Log(string.Format("backHit {0} - distance {1} - transform forward {2} - backHit.normal {3}", backHit.transform, backHit.distance, -player.transform.forward, backHit.normal));
        //        if (backHit.transform.tag == "Walkable" && (backHit.distance >= 0.0f))
        //        {
        //            player.transform.rotation = new Quaternion(0.0f, -90.0f, 0.0f, 0.0f);//revisar
        //        }
        //    }
        //    else
        //    {
        //if (raycastRightHit)
        //{
        //    if (rightHit.transform.tag == "Walkable" && rightHit.distance >= 0.0f && rightHit.distance < 5.0f)
        //    {
        //        Debug.Log(string.Format("rightHit {0} - rightHit.transform.rotation {1} - transform.position {2} - rightHit.normal {3} - transform.rotation {4}", rightHit, rightHit.transform.rotation, transform.position, rightHit.normal, transform.rotation));
        //        //player.transform.rotation = new Quaternion(0.0f, 0.0f, 90.0f, 0.0f);//revisar
        //        //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rightHit.transform.rotation, step);
        //        //step = step + Time.deltaTime;
        //        player.transform.eulerAngles = RotateLerp(player.transform.eulerAngles, rightHit.transform.eulerAngles);
        //    }
        //}
        //else
        //{
        //if (raycastLeftHit)
        //{
        //    if (leftHit.transform.tag == "Walkable" && leftHit.distance >= 0.0f && leftHit.distance < 5.0f)
        //    {
        //        Debug.Log(string.Format("leftHit {0} - leftHit.transform.rotation {1} - transform.position {2} - leftHit.normal {3} - transform.rotation {4}", leftHit, leftHit.transform.rotation, transform.position, leftHit.normal, transform.rotation));
        //        //player.transform.rotation = new Quaternion(0.0f, 0.0f, -90.0f, 0.0f);//revisar
        //        //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, leftHit.transform.rotation, step);
        //        //step = step + Time.deltaTime;
        //        player.transform.eulerAngles = RotateLerp(player.transform.eulerAngles, leftHit.transform.eulerAngles);
        //    }
        //}
        //    else
        //    {
        //if (raycastTopHit)
        //    {
        //        Debug.Log(string.Format("topHit {0} - distance {1} - transform up {2} - topHit.normal {3}", topHit.transform, topHit.distance, player.transform.up, topHit.normal));
        //        if (topHit.transform.tag == "Walkable" && (topHit.distance >= 0.0f))
        //        {
        //            player.transform.rotation = new Quaternion(0.0f, -180.0f, 0.0f, 0.0f);//revisar
        //            player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, topHit.transform.rotation, step);
        //            step = step + Time.deltaTime;
        //        }
        //    }
        //    }
        //}
        //    }
        //}

        if (raycastDownHit && downHit.transform.tag == "Walkable" && downHit.distance > 1.0f && downHit.distance < rayWalkableDistance * 40)
        {
            //Debug.Log(string.Format("downHit {0} - distance {1} - transform up {2} - downHit.normal {3}", downHit.transform, downHit.distance, -player.transform.up, downHit.normal));
            //Debug.Log(string.Format("downHit {0} - downHit.transform.rotation {1} - transform.position {2} - downHit.normal {3} - transform.rotation {4}", downHit, downHit.transform.rotation, transform.position, downHit.normal, transform.rotation));
            player.transform.position -= falseGravity * Time.fixedDeltaTime * player.transform.up;
            if (player.transform.rotation != downHit.transform.rotation)
            {
                //rotateOnHit = CheckOnHitWalkable(downHit, player.transform);
                rotateOnHitQua = CheckOnHitWalkableQua(downHit, player.transform);
                Debug.Log(string.Format("downHit {0} player.rotation {1} normal {2} downHit.rotation {3} player.eulerAngles {4}", downHit.transform, player.transform.rotation, downHit.normal, downHit.transform.rotation, player.transform.eulerAngles));
                
                //Vector3 downRotation = new Vector3(rotateOnHit.x, player.transform.eulerAngles.y, rotateOnHit.z);
                //player.transform.eulerAngles = RotateLerp(player.transform.eulerAngles, rotateOnHit);
                player.transform.rotation = RotateQLerp(player.transform.rotation, rotateOnHitQua);
            }
        }

        //if (((raycastFrontHit && frontHit.transform.tag == "Walkable" && frontHit.distance >= 0.0f && frontHit.distance < 1.0f)
        //    //|| (raycastTopHit && topHit.transform.tag == "Walkable" && topHit.distance >= 0.0f) 
        //    //|| (raycastLeftHit && rightHit.transform.tag == "Walkable" && rightHit.distance >= 0.0f && rightHit.distance < 5.0f)
        //    //|| (raycastRightHit && leftHit.transform.tag == "Walkable" && leftHit.distance >= 0.0f && leftHit.distance < 5.0f)
        //    )
        //    && raycastDownHit && downHit.transform.tag == "Walkable" && downHit.distance >= 0.0f && downHit.distance < 0.01f)
        //{
        //    Debug.Log(string.Format("Adjust: player.transform.rotation {0}, downHit.transform.rotation {1}", player.transform.rotation, downHit.transform.rotation));
        //    //player.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, downRotation, step);
        //    //step = step + Time.fixedDeltaTime;
        //    Vector3 downRotation = new Vector3(downHit.transform.eulerAngles.x, player.transform.eulerAngles.y, downHit.transform.eulerAngles.z);
        //    player.transform.eulerAngles = RotateLerp(player.transform.eulerAngles, downRotation);
        //}

        }

    public Vector3 RotateLerp(Vector3 currentAngle, Vector3 targetAngle)
    {
        currentAngle = new Vector3(
            Mathf.LerpAngle(currentAngle.x, targetAngle.x, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.y, targetAngle.y, Time.deltaTime),
            Mathf.LerpAngle(currentAngle.z, targetAngle.z, Time.deltaTime));

        Debug.Log(string.Format("currentAngle {0}, targetAngle {1}", currentAngle, targetAngle));
        return currentAngle;
    }

    public Quaternion RotateQLerp(Quaternion currentAngle, Quaternion targetAngle)
    {
        currentAngle = Quaternion.Lerp(currentAngle,targetAngle, Time.deltaTime);

        Debug.Log(string.Format("currentAngle {0}, targetAngle {1}", currentAngle, targetAngle));
        return currentAngle;
    }

    private Vector3 CheckOnHitWalkable(RaycastHit raycastHit, Transform player)
    {
        Vector3 rotationToFloor = new Vector3();

        Quaternion q = new Quaternion();

        if (raycastHit.normal == new Vector3(1.0f, 0.0f, 0.0f)) rotationToFloor = new Vector3(player.transform.eulerAngles.x, 0.0f, -90.0f);
        if (raycastHit.normal == new Vector3(-1.0f, 0.0f, 0.0f)) rotationToFloor = new Vector3(player.transform.eulerAngles.x, 0.0f, 90.0f);
        if (raycastHit.normal == new Vector3(0.0f, 1.0f, 0.0f)) rotationToFloor = new Vector3(0.0f, player.transform.eulerAngles.y, 0.0f);

        q.eulerAngles = rotationToFloor;
        return rotationToFloor;
    }

    private Quaternion CheckOnHitWalkableQua(RaycastHit raycastHit, Transform player)
    {
        Vector3 rotationToFloor = new Vector3();

        Quaternion q = new Quaternion();

        if (raycastHit.normal == new Vector3(1.0f, 0.0f, 0.0f)) rotationToFloor = new Vector3(player.transform.eulerAngles.x, 0.0f, -90.0f);
        if (raycastHit.normal == new Vector3(-1.0f, 0.0f, 0.0f)) rotationToFloor = new Vector3(player.transform.eulerAngles.x, 0.0f, 90.0f);
        if (raycastHit.normal == new Vector3(0.0f, 1.0f, 0.0f)) rotationToFloor = new Vector3(0.0f, player.transform.eulerAngles.y, 0.0f);

        q.eulerAngles = rotationToFloor;
        return q;
    }
}
