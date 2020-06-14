using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//***IMPLEMENTACION*** : Objeto al cual es asignado debe tener:
// Componente: **Collider** > Trigger activado
public class Municiones_Control : MonoBehaviour
{
    public SonidosBiblioteca sSonidos;
    public int nMuniciones = 1; //Cantidad de vida que devuelve al jugador
    public bool soyExplosivo; //false >> aumentar balas, true >> aumentar explosivos
    private Jugador_Ataque sPlayerAtaque;
    private void Awake() 
    {
        sPlayerAtaque = GameObject.Find("Player").GetComponent<Jugador_Ataque>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player")
        {
            if(!soyExplosivo)
            {
                sPlayerAtaque.balas += nMuniciones;
                //sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Interaccion);
            }
            else
            {
                sPlayerAtaque.explosivos += nMuniciones;
                //sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Interaccion);
            }
            
            Destroy(gameObject);
        }    
    }
}
