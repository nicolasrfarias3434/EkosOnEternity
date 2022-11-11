using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 origin = new Vector3(0.0f, 1.0f, 0.0f);
    public Vector3 movement = new Vector3(0.0f, 0.0f, 0.0f);
    public Vector3 objectScale = new Vector3(1.0f, 1.0f, 1.0f);
    public float speed;

    public Vector3 direccion;
    public Vector3 rotation;
    public int vida;
    public int deltaVida;

    public float rayDistance;

    // Start is called before the first frame update
    void Start()
    {
        StartStatus();
    }

    // Update is called once per frame
    void Update()
    {
        PlayActions();
        UpdateStatus();
    }

    /// <summary>
    /// Esta función setea los valores iniciales del personaje
    /// </summary>
    void StartStatus()
    {
        speed = 10.0f;
        rotation = new Vector3(0.0f, 0.0f, 0.0f);
        objectScale = new Vector3(1.0f, 1.0f, 1.0f);
        direccion = new Vector3(0.0f, 0.0f, 0.0f);
        transform.position = origin;
        transform.eulerAngles = rotation;
        transform.localScale = objectScale;
        deltaVida = 0;
    }

    void UpdateStatus()
    {
        transform.position += direccion * speed * Time.deltaTime;
        transform.eulerAngles += rotation * speed * Time.deltaTime;
        transform.localScale = objectScale;
        
        vida = deltaVida;
    }

    void PlayActions()
    {
        Hability_HealingMeditation();
        Hability_DobleEdge();
        Hability_Levitation();
        Hability_TeleportToOrigin();
        DetectEnemy();
        RotateMovement();
        DriveMovement();
    }

    /// <summary>
    /// Esta función controla el movimiento del personaje
    /// </summary>
    void DriveMovement()
    {
        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S)) transform.position -= transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.A)) transform.position -= transform.right * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.D)) transform.position += transform.right * speed * Time.deltaTime;
    }

    void RotateMovement()
    {
        if (Input.GetKey(KeyCode.LeftArrow)) transform.Rotate(new Vector3(0.0f,-speed/2, 0.0f));
        if (Input.GetKey(KeyCode.RightArrow)) transform.Rotate(new Vector3(0.0f, speed/2, 0.0f));
    }

    #region Habilities

    void DetectEnemy()
    {
        Debug.DrawRay(transform.position,transform.forward * rayDistance, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward * rayDistance, out hit, rayDistance))
        {
            if(hit.transform.name == "BotEnemy")
            Debug.Log("Patrullero está cerca frente a ti.");
        }
    }

    /// <summary>
    /// Esta función cura al personaje
    /// </summary>
    void Hability_HealingMeditation()
    {
        if (Input.GetKeyDown(KeyCode.Q)) deltaVida += 5;
    }

    /// <summary>
    /// Esta función daña al personaje
    /// </summary>
    void Hability_DobleEdge()
    {
        if (Input.GetKeyDown(KeyCode.E)) deltaVida += -5;
    }

    /// <summary>
    /// Esta función mueve al personaje en el eje Z
    /// </summary>
    void Hability_Levitation()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += transform.up * speed*5 * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position -= transform.up * speed*5 * Time.deltaTime;
    }

    /// <summary>
    /// Esta función devuelve al personaje a la posición de inicio y resetea sus deltas
    /// </summary>
    void Hability_TeleportToOrigin()
    {
        if (Input.GetKeyDown(KeyCode.Y)) 
        { 
            StartStatus();
        }
    }

    /// <summary>
    /// Esta función maneja las características de activar los efectos de hacer un salto en el tiempo
    /// </summary>
    void Hability_TimeJump()
    {
        //Los saltos en el espacio-tiempo son teóricamente imposibles, pero nada impide saltar a realidades paralelas
        //coincidentes con la nuestra. Este tipo de posibilidades permiten que podamos ir a otra de estas realidades,
        //de tal manera que su momento actual sea igual a un momento de nuestro pasado. Por lo que movernos a ella,
        //sería el equivalente a atravesar una esfera con las coordenadas espacio-tiempo definidas, que nos lleve a nuestro pasado.
        //Notar que de la misma manera, podríamos ir al futuro si conociéramos sus coordenadas de espacio-tiempo.
    }

    /// <summary>
    /// Esta función maneja las características al activar los efectos de usar un teseracto
    /// </summary>
    void Hability_Tesseract()
    {
        //Abrir un teseracto permite adentrarse en una dimensión interdimensional, en la que podemos revisar todos los tiempos
        //de un lapso determinado, y hacer pequeños ajustes en él, afectando la información en ese espacio-tiempo, influyendo
        //sobre la fuerza gravitacional del lugar.
    }

    #endregion

    #region Powers
    /// <summary>
    /// Esta función maneja las características de activar los efectos de estar cerca de un agujero negro
    /// </summary>
    void BlackHole()
    {
        //De la misma manera que ocurre en los agujeros negros, la alta densidad del área cerca del agujero,
        //hace que el tiempo transcurra más lento cerca de él, y cada vez más rápido a medida que nos alejamos de él.
        //Esta función se usa para ralentizar el reloj del personaje, mientras el jugador esté en una ubicación de alta densidad,
        //o cuando esté usando una habilidad que lo haga temporalmente en algún lugar determinado.
    }

    /// <summary>
    /// Esta función maneja las características de activar los efectos de estar cerca de un agujero blanco
    /// </summary>
    void WhiteHole()
    {
        //Inversamente a lo que ocurre en los agujeros negros, la baja densidad del área cerca del agujero blanco,
        //hace que el tiempo transcurra más rápido cerca de él, y cada vez más lento a medida que nos alejamos de él.
        //Esta función se usa para acelerar el reloj del personaje, mientras el jugador esté en una ubicación de baja densidad,
        //o cuando esté usando una habilidad que lo haga temporalmente en algún lugar determinado.
    }

    /// <summary>
    /// Esta función maneja las características de activar los efectos de utilizar el pasaje a través de un agujero de gusano
    /// </summary>
    void WormHole()
    {
        //Los agujeros de gusano permiten trasladarnos grandes distancias mediante un túnel en 3D (que en la realidad es una esfera)
        //que nos lleva desde un punto a otro en un instante, dándonos la posibilidad de ver los sucesos del pasado ocurrir,
        //Pero dada la distancia que hay que alejarse para poder hacerlo, no se pueden cambiar esos hechos del pasado.
        //Esta función se utiliza para revisar acciones del pasado.
    }

    #endregion
}
