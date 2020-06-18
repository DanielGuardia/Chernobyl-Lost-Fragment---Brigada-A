using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoCercano_Control : MonoBehaviour
{ public float dis;
    public SonidosBiblioteca sSonidos;
    private AudioSource audioSource;
    [SerializeField] float velocidad = 10f;
    [SerializeField] int fuerzaDaño = 15;
    [SerializeField] float distanciaPerseguir = 10f, distanciaMin = 2f;
    [SerializeField] float distanciaDeGolpe = 3f;
    [SerializeField] float frecuenciaAtaque = 1f; //Cada cuantos segundos ataca
    public float timerAtaque = 0f;
    private bool bAtacando = false;
    //Jugador
    private GameObject player; 
    private Jugador sPlayer;
    //Animacion
    private Animator animator; 
    [SerializeField] string nombreTriggerAnimacionAtaque; //Trigger que activa la animacion de ataque del animator

    private void Awake() 
    {
        animator = gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        sPlayer = player.GetComponent<Jugador>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update() 
    { dis = Vector3.Distance(transform.position, player.transform.position);
        if(Vector3.Distance(transform.position, player.transform.position) < distanciaPerseguir && Vector3.Distance(transform.position, player.transform.position) > distanciaMin) //Si cerca, entonces perseguir
        { //ACERCARSE
            
            transform.LookAt(player.transform); //Mirar al jugador
            Vector3 eulerPos = transform.localEulerAngles; eulerPos.x = 0; //No mirar en eje x
            transform.rotation = Quaternion.Euler(eulerPos);    
            
            transform.position += transform.forward * velocidad * Time.deltaTime; //Acercarse
            timerAtaque -= Time.deltaTime; 
            //ATACAR
            if(Vector3.Distance(transform.position, player.transform.position) <= distanciaDeGolpe)
            {           
                if(timerAtaque <= 0)
                {
                    Atacar();
                    timerAtaque = frecuenciaAtaque;
                } 
            } 
        }       
    }
    private void Atacar()
    { 
        PlayAnimacionAtaque();
        //audioSource.Play();
        //sSonidos.Play(player.gameObject.GetComponent<AudioSource>(), sSonidos.Lobo);
        sPlayer.RecibirDaño(fuerzaDaño);
    }
    private void PlayAnimacionAtaque()
    {
        animator.SetTrigger(nombreTriggerAnimacionAtaque);     //La animacion de ataque del enemigo 
    }  
}
