using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaControl : MonoBehaviour
{
    public SonidosBiblioteca sSonidos;
    public string color;
    public BaulMateriales baul;
    public Transform ejeDeGiro;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player")
        {
            if(baul.RevisarSiHayObjeto("Llave" + color))
            {
                transform.RotateAround(ejeDeGiro.position, Vector3.up, -90);
                sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Interaccion);
            }
            else
            Debug.Log("No tienes llave");
        }    
    }
    private void OnTriggerExit(Collider other) 
    {
        if(other.name == "Player")
        {
            if(baul.RevisarSiHayObjeto("Llave" + color))
            {
                transform.RotateAround(ejeDeGiro.position, Vector3.up, 90);
            }            
            else
            Debug.Log("No puedes salir sin llave");
        } 
    }
}
