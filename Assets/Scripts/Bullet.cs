using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 2.0f;
    public Vector3 bulletDirection;
    public float damage = 50;
    public float objectScale = 0.25f;
    public float destroyTime;
    //agregar acá un GameObject de parámetro, para indicar la dirección a la que se dispara
    //y en el juego en la punta del cañón

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        GrowBullet();
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void GrowBullet()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.localScale *= 2.0f;
        }
    }
}
