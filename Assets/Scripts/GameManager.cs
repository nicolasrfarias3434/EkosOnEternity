using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; //Singleton

    private List<string> activeAbilities = new List<string>(); //Acá se suman las habilidades que el jugador tiene activas ahora
    private int abilityLimits;
    private List<string> gainedAbilities = new List<string>(); //Acá se suman las habilidades que el jugador va ganando al atravesar los portales de victoria.

    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Método para agregar una habilidad al jugador
    /// </summary>
    public static void AddNewAbility(string ability)
    {
        instance.gainedAbilities.Add(ability);
    }

    /// <summary>
    /// Método para agregar una habilidad al jugador
    /// </summary>
    public static void AddActiveAbility(int index, string ability)
    {
        //Si la posición ya está ocupada, reemplazarla
        instance.activeAbilities.Insert(index, ability);
    }

    /// <summary>
    /// Para verificar si el jugador adquirió la habilidad
    /// Se usa normalmente cuando al apretar una tecla, se vé si el jugador puede o no hacer algo.
    /// </summary>
    /// <param name="ability"></param>
    /// <returns></returns>
    public static bool AbilityIsActive(string ability)
    {
        return instance.gainedAbilities.Contains(ability);
    }
}
