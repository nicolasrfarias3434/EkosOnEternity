using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerasGame : MonoBehaviour
{
    public GameObject[] cameras;

    private int camIndex = 0;       //cámara a elegir

    // Start is called before the first frame update
    void Start()
    {
        SetDefault();
    }

    private void Update()
    {
        ChangeCameraInArray();
    }

    private void SetDefault()
    {
        cameras[0].SetActive(true);
        for(int i = 1; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }
    }

    public void ChangeCameraInArray()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cameras[camIndex].SetActive(false);
            camIndex = ++camIndex % cameras.Length;
            cameras[camIndex].SetActive(true);
        }
    }
}
