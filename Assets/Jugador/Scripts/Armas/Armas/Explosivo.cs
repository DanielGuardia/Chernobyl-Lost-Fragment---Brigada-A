using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosivo : MonoBehaviour
{
    public float velocidad = 0.1f;
    private int porcentajeDañoExplosivo;
    private ParticleSystem explosion;
    public float tiempoDeVida = 8;
    private float vidaTimer;
    GameObject balaSalida;
    private Vector3 direccion;

    private void Start() 
    {
        porcentajeDañoExplosivo = GameObject.Find("Player").GetComponent<Jugador_Ataque>().porcentajeDañoExplosivo;
        vidaTimer = tiempoDeVida;
        balaSalida = GameObject.Find("BalaPuntoSalida");
        direccion = transform.forward;
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
                other.gameObject.GetComponent<Enemigo_Control>().QuitarVida(porcentajeDañoExplosivo);
                Explosion();
            }  
            Destroy(gameObject);     
        }
             
    }

    private void Explosion()
    {
        Destroy(gameObject.GetComponent<MeshRenderer>());
        explosion = gameObject.GetComponent<ParticleSystem>();
        explosion.Play();
        Destroy(gameObject, explosion.main.duration);
    }
}
