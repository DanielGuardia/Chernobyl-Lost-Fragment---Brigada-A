using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarAlJugador : MonoBehaviour
{
    [SerializeField] float distanciaMirar = 100f;
    private GameObject player;
    private void Awake() 
    {
        player = GameObject.Find("Player");    
    }
    private void Update() 
    {
        if(Vector3.Distance(transform.position, player.transform.position) < distanciaMirar)
        {
            transform.LookAt(player.transform);
            Vector3 eulerPos = transform.localEulerAngles; eulerPos.x = 0; //No mirar en eje x
            transform.rotation = Quaternion.Euler(eulerPos);  
        }    
    }
}
