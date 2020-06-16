using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class Radiacion_Control : MonoBehaviour
{ //Asignar este script a un objeto: 
  //Cuando el jugador choca contra el objeto se activa el porcentaje de radiacion definido en el objeto
    [SerializeField]
    private int porcentajeRadiacion = 2;
    private Jugador sPlayer;
    private BoxCollider radiacionCollider;
    private void Awake() 
    {
        radiacionCollider = GetComponent<BoxCollider>();

        sPlayer = GameObject.Find("Player").GetComponent<Jugador>(); 
    }
    private void Start() 
    {
        radiacionCollider.isTrigger = true;
    }
    private void OnTriggerEnter(Collider other) 
    {
        sPlayer.NivelRadiacion = porcentajeRadiacion;
    }
}
