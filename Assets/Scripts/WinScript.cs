using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private bool darHabilidad;
    // Start is called before the first frame update
    void Start()
    {
        darHabilidad = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Winning();
        }
    }

    public void Winning()
    {
        if (!GameManager.AbilityIsActive("Jump")) { GameManager.AddNewAbility("Jump"); GameManager.AddActiveAbility(0, "Jump"); Debug.Log("Ahora puedes saltar!!");return; }
        if (!GameManager.AbilityIsActive("PowerUp1")) { GameManager.AddNewAbility("PowerUp1"); Debug.Log("Power Up 1!!");return; }
        if (!GameManager.AbilityIsActive("PowerUp2")) { GameManager.AddNewAbility("PowerUp2"); Debug.Log("Power Up 2!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp3")) { GameManager.AddNewAbility("PowerUp3"); Debug.Log("Power Up 3!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp4")) { GameManager.AddNewAbility("PowerUp4"); Debug.Log("Power Up 4!!"); return; }
        if (!GameManager.AbilityIsActive("Levitation")) { GameManager.AddNewAbility("Levitation"); GameManager.AddActiveAbility(1, "Levitation"); Debug.Log("Ahora puedes levitar!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp5")) { GameManager.AddNewAbility("PowerUp5"); Debug.Log("Power Up 5!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp6")) { GameManager.AddNewAbility("PowerUp6"); Debug.Log("Power Up 6!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp7")) { GameManager.AddNewAbility("PowerUp7"); Debug.Log("Power Up 7!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp8")) { GameManager.AddNewAbility("PowerUp8"); Debug.Log("Power Up 8!!"); return; }
        if (!GameManager.AbilityIsActive("PowerUp9")) { GameManager.AddNewAbility("PowerUp9"); Debug.Log("Power Up 9!!"); return; }
        if (!GameManager.AbilityIsActive("TrueVision")) { GameManager.AddNewAbility("TrueVision"); GameManager.AddActiveAbility(2, "TrueVision"); Debug.Log("Ahora puedes ver todo en la dimensión del teseracto!!"); return; }
        if (GameManager.AbilityIsActive("TrueVision"))
        {
            Debug.Log("¡Has superado los desafíos del teseracto! ¡Tu entrenamiento ha terminado! Ahora puedes ir y venir de él a los diferentes lugares en el espacio-tiempo del universo y hacer ECO EN LA ETERNIDAD...");
            SceneManager.LoadScene("IntroWin");
        }
    }
}
