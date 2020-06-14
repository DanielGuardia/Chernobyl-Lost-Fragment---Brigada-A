using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class PartidasControl : MonoBehaviour
{
    //General
    private static PartidasControl instance; //Singleton
    public static PartidasControl Instance 
    { 
        get 
        { 
        if(instance == null)
            Debug.LogError("PoolManager is NULL");
        return instance; 
        } 
    }
    public int maxNPartidas = 7; //maximo numero de partidas
    private static int nPartida; //numero de la partida
    public int NPartida { get { return nPartida;} }
    private int nBorrar;
    private string nombreNivel1;
    //UI
    private GameObject PartidasGuardadas, PanelMensaje, PanelBorrar;
    public GameObject[] Partidas; //Asignar desde editor
    private void Awake() 
    {
        instance = this;
        PartidasGuardadas = transform.Find("GrupoPartidas").gameObject;
        PanelMensaje =  transform.Find("PanelMensaje").gameObject;
        PanelBorrar = transform.Find("PanelBorrar").gameObject;
    }
    private void Start() 
    {        
        PanelMensaje.SetActive(false);
        PanelBorrar.SetActive(false);
        ActualizarTextoPartidas();
    }

    public void NuevaPartida(string nombreNivel1)
    {
        int nuevoN = BuscarPartidaVacia();
        if(nuevoN < maxNPartidas)
        {
            nPartida = nuevoN;
            Partidas[nPartida].GetComponentInChildren<TextMeshProUGUI>().text = "Usado";
            SceneManager.LoadScene(nombreNivel1);
        }
        else
        {
            PanelMensaje.SetActive(true);
            TextMeshProUGUI txtMensaje = PanelMensaje.transform.Find("Mensaje").GetComponentInChildren<TextMeshProUGUI>();
            txtMensaje.text = "Todas las partidas estan usadas. Selecciona 'Cargar Partida'";
        }
    }
    public void OnClick_Ok_PanelMensaje()
    {
        PanelMensaje.SetActive(false);
    }
    public void RecibirNombreNivel(string nombre)
    {
        nombreNivel1 = nombre;
    }
    public void OnClick_CargarPartida(int n)
    {
        string path = Application.persistentDataPath + "/juego" + n + ".chernobyl";
        if(File.Exists(path) == false)
        {
            PanelMensaje.SetActive(true);
            TextMeshProUGUI txtMensaje = PanelMensaje.transform.Find("Mensaje").GetComponentInChildren<TextMeshProUGUI>();
            txtMensaje.text = "Partida vacia. Porfavor selecciona otra partida";
        }
        else
        {
            nPartida = n;
            SceneManager.LoadScene(nombreNivel1);
        }
    }
    public void OnClick_BorrarPartida(int n)
    {
        PanelBorrar.SetActive(true);
        nBorrar = n;
    }
    public void OnClick_Si_BorrarPartida()
    {
        string path = Application.persistentDataPath + "/juego" + nBorrar + ".chernobyl";
        if(File.Exists(path))
        {
            File.Delete(path);
            Partidas[nBorrar].GetComponentInChildren<TextMeshProUGUI>().text = "Vacio";
        }
        PanelBorrar.SetActive(false);
    }
    public void OnClick_No_BorrarPartida()
    {
        PanelBorrar.SetActive(false);
    }
    private int BuscarPartidaVacia()
    {        
        for(int n = 0; n < maxNPartidas; n++)
        {
            string path = Application.persistentDataPath + "/juego" + n + ".chernobyl";
            if(File.Exists(path) == false)
            return n;
        }
        return maxNPartidas;
    }
    private void ActualizarTextoPartidas()
    {
        for(int n = 0; n < maxNPartidas; n++)
        {
            string path = Application.persistentDataPath + "/juego" + n + ".chernobyl";
            if(File.Exists(path))
                Partidas[n].GetComponentInChildren<TextMeshProUGUI>().text = "Usado";
            else
                Partidas[n].GetComponentInChildren<TextMeshProUGUI>().text = "Vacio";
        }
    }
}
