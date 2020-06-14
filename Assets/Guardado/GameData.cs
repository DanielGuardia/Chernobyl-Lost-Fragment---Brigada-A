using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int vida;
    public List<string> baulObjetos; //listaObjetos de BaulMateriales
    public float[] playerPos; //Posicion del jugador
    public GameData(Jugador player) //Constructor
    {
        vida = player.vida;
        baulObjetos = player.baulMateriales.listaObjetos;
        playerPos = new float[3];
        playerPos[0] = player.transform.position.x;
        playerPos[1] = player.transform.position.y + 2f;
        playerPos[2] = player.transform.position.z - 1f;
    }
}
