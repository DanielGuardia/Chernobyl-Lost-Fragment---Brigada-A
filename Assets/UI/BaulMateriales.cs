using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaulMateriales: MonoBehaviour
{
    public List<string> listaObjetos = new List<string>();
    Jugador_Interfaz jInterfaz;
    private void Awake() {
        jInterfaz = GameObject.Find("Interfaz_De_Partida").GetComponentInChildren<Jugador_Interfaz>();
    }
    public BaulMateriales()
    {
        listaObjetos = new List<string>();
        listaObjetos.Add("objetoejemplo1");
        listaObjetos.Add("objetoejemplo2");
    }

    public void RecogerObjeto(string objeto)
    {
        listaObjetos.Add(objeto);
        jInterfaz.OnClick_Baul();
    }
    public string DevolverObjeto(string objeto)
    {
        string o = "";
        foreach (var obj in listaObjetos)
        {
            if(obj == objeto)
            o = obj;
        }
        return o;
    }
    public string DevolverTodosLosObjetos()
    {
        string objetos = "";
        for (int i = 0; i < listaObjetos.Count; i++)
        {
            objetos += listaObjetos[i] + " | ";
        }
        return objetos;
    }
    public bool RevisarSiHayObjeto(string objeto)
    {
        bool encontrado = false;
        foreach (var elemento in listaObjetos)
        {
            if(elemento == objeto)
            encontrado = true;
        }
        return encontrado;
    }
}
