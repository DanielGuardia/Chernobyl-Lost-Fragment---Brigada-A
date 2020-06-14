using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LlaveControl : MonoBehaviour
{
    public SonidosBiblioteca sSonidos;
    public string color;
    public BaulMateriales baul;
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player")
        {
            baul.RecogerObjeto("Llave" + color);
            sSonidos.Play(gameObject.GetComponent<AudioSource>(), sSonidos.Interaccion);
            Destroy(gameObject);
        }    
    }
}
