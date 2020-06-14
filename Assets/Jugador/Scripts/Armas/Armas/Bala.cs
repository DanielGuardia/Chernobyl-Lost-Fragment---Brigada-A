using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    public float velocidad = 2;
    private int porcentajeDañoArmaScientifica;
    public float tiempoDeVida = 2;
    private float vidaTimer;
    GameObject balaSalida;
    private Vector3 direccion;
    private void Start() 
    {
        balaSalida = GameObject.Find("BalaPuntoSalida");
        porcentajeDañoArmaScientifica = GameObject.Find("Player").GetComponent<Jugador_Ataque>().porcentajeDañoArmaScientifica;
        vidaTimer = tiempoDeVida;
        direccion = balaSalida.transform.forward;
    }
    private void Update() 
    {
        vidaTimer -= Time.deltaTime;
        if(vidaTimer <= 0)
        {
            Destroy(gameObject);
        }
        transform.position += direccion * velocidad;
    }
    private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.name != "Player")
        {
            if(other.gameObject.tag == "enemigo")
            {
                other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoArmaScientifica);
            }            
            Destroy(gameObject);
        }        
    }
}
