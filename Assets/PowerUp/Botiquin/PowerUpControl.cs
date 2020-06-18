using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//***IMPLEMENTACION*** : Objeto al cual es asignado debe tener:
// Componente: **Collider** > Trigger activado
public class PowerUpControl : MonoBehaviour
{ 
    public SonidosBiblioteca sSonidos;
    public int vida = 15; //Cantidad de vida que devuelve al jugador
    private Jugador sPlayer;
    private void Awake() {
        sPlayer = GameObject.Find("Player").GetComponent<Jugador>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player" || other.gameObject.transform.parent.name == "Player")
        {
            //sPlayer.vida += vida;
            sPlayer.RecibirDaño(-vida);
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Interaccion);
            Destroy(gameObject);
        }   
    }
}
