using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasGame : MonoBehaviour
{

    public GameObject PJCam;
    public GameObject AMTCam;
    public GameObject T1Cam;

    private int camIndex = 0;       //cámara a elegir
    private int camCant = 3;    //cantidad de cámaras activables

    // Start is called before the first frame update
    void Start()
    {
        SetDefault();
    }

    private void Update()
    {
        ChangeCamera();
    }

    private void SetDefault()
    {
        PJCam.SetActive(true);
        AMTCam.SetActive(false);
        T1Cam.SetActive(false);
    }

    public void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            camIndex = ++camIndex % camCant;
            switch (camIndex)
            {
                case 0:
                    {
                        PJCam.SetActive(true);
                        AMTCam.SetActive(false);
                        T1Cam.SetActive(false);
                        break;
                    }
                case 1:
                    {
                        PJCam.SetActive(false);
                        AMTCam.SetActive(true);
                        T1Cam.SetActive(false);
                        break;
                    }
                case 2:
                    {
                        PJCam.SetActive(false);
                        AMTCam.SetActive(false);
                        T1Cam.SetActive(true);
                        break;
                    }
            }
        }
    }
}
