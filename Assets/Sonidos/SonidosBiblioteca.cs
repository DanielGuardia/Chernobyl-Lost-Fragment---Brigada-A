using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SonidosBiblioteca", menuName = "Scriptables/NuevoSonidosBiblioteca", order = 0)]
public class SonidosBiblioteca : ScriptableObject
{
    public AudioClip infectado; //Sonido para todos los Sprites de Enemigos
    public AudioClip Boton; //Sonido de Boton de Escena Menu
    public AudioClip Disparo; //Sonido de pistola
    public AudioClip Explosion;//Sonido de exposion de la planta 
    public AudioClip Fondo; // Sonido de Fondo de de Menu
    public AudioClip Barreta; //Sonido al accionar la Barrera
    public AudioClip Grillo; //Sonido de grillo del Nivel 2
    public AudioClip Interaccion; // en menu al hacer la accion de recorrer por todo el menu, pero sin hacer click
    public AudioClip Latido_corazon_rapido; //Sonido per personaje de baja vida
    public AudioClip Lluvia;// Sonido del Nivel 2
    public AudioClip Lobo; //Sonido de lobo del Nivel 2
    public AudioClip Muerte; // Sonido cuando mueres
    public AudioClip Pajaros; //Sonido de pajaros del Nivel 2
    public AudioClip Pasos; //Sonido de pisadas por el nivel de nuestro personaje
    public AudioClip Pelea; //Cuando se aceruqe un Enemigo
    public AudioClip Radiacion; // Sonido donde se representa el nivel de radiacion que existe
    public AudioClip Vaca; //Sonido de Vaca del Nivel 2

    public void Play(AudioSource audioSource, AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }
}