using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventsHandler : MonoBehaviour
{
    public event Action<int, bool> onDeath;
    public event Action<int, bool> onWin;
    // Start is called before the first frame update
    void Start()
    {
        onDeath += EventsHandler_onDeath;
        onWin += EventsHandler_onWin;
    }

    private void EventsHandler_onWin(int arg1, bool arg2)
    {
        Debug.Log("Ganar en el teseracto, te habilita nuevos portales, a nuevos lugares en el tiempo.");
    }

    private void EventsHandler_onDeath(int arg1, bool arg2)
    {
        Debug.Log("Estás dentro de un teseracto, no puedes morir y la gravedad se comporta extraño aquí.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
