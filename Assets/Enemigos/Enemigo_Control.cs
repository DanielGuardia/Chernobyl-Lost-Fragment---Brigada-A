using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Control : MonoBehaviour
{
    public int vida = 100; //Cantidad de vida del enemigo
    public int Vida { get{ return vida;} }
    private int daño = 10; //Cantidad de daño que causa el enemigo con su ataque
    public int Daño { get { return daño; } set { daño = value; } }

#region Metodos Por Defecto
    private void Update() 
    {
        if(vida <= 0)       //Si vida <= 0, el enemigo muere
        {
            Destroy(gameObject);
        }
    }
    public void QuitarVida(int valor)
    {
        vida -= valor;
    }
#endregion
}
