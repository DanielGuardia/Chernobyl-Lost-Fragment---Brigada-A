using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardadoControl : MonoBehaviour
{
    private Jugador player;
    private void Awake() 
    {
        player = GameObject.Find("Player").GetComponent<Jugador>();
    }
    //Load en Jugador_Interfaz al comenzar el juego
    private void OnTriggerEnter(Collider other) //Guardar
    {
        int n = PartidasControl.Instance.NPartida;
        GameSaveLoad.Save(n, player);
        player.HablarMensaje("Partida ha sido guardada");
    }
}
