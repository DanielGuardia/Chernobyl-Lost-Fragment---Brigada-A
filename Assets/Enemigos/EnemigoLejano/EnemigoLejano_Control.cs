 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoLejano_Control : MonoBehaviour
{
    [SerializeField] int dañoDisparo = 5;
    [SerializeField] float frecuenciaDisparo = 1f; //Cada cuantos segundos dispara
    private float timerDisparo = 0f;
    private bool bDisparando = false;
    [SerializeField] float disDisparar = 5f; //Distancia desde la cual comienza a disparar al jugador
    [SerializeField] GameObject bala, balaSalida;
    //Jugador
    private GameObject player; 
    private Jugador sPlayer;
    //Animacion
    private Animator animator; 
    [SerializeField] string nombreTriggerAnimacionDisparo; //Trigger que activa la animacion de ataque del animator

    private void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        sPlayer = player.GetComponent<Jugador>();
    }
    private void Update() 
    {
        if(Vector3.Distance(transform.position, player.transform.position) < disDisparar ) //Si cerca, entonces disparar
        {
            
            transform.LookAt(player.transform); //Mirar al jugador
            Vector3 eulerPos = transform.localEulerAngles; eulerPos.x = 0; //No mirar en eje x
            transform.rotation = Quaternion.Euler(eulerPos);    
            
            timerDisparo -= Time.deltaTime;

            if(timerDisparo <= 0)
            {
                Disparar();
                timerDisparo = frecuenciaDisparo;
            }
        } else timerDisparo = 0;
    }

    private void Disparar()
    { 
        PlayAnimacionAtaque();
        Instantiate(bala, balaSalida.transform);
    }
    private void PlayAnimacionAtaque()
    {
        animator.SetTrigger(nombreTriggerAnimacionDisparo);     //La animacion de ataque del enemigo 
    }  
}
