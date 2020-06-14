using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IrAOtroNivel : MonoBehaviour
{
    private Jugador sPlayer;
    public string nombreNivel = "nivel2";
    private void Awake() 
    {
        sPlayer = GameObject.Find("Player").GetComponent<Jugador>();
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.name == "Player")
        {            
            SceneManager.LoadScene(nombreNivel);
        }    
    }
}
