using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaControl : MonoBehaviour
{
    public GameObject Jugador;
    private PlayerLook sJugadorLook;
    private PlayerMove sPlayerMove;
    public KeyCode keyPausa = KeyCode.P;
    private GameObject Panel;
    private GameObject PartidasGuardadas;
    private GameObject GuardarCambios;
    private GameObject BotonesInferior;
    public GameObject CanvasPartida;
    public string nombreSceneMenu;
    private bool pausado;
    
    private void Awake() 
    {
        Panel = transform.Find("Panel").gameObject;
        PartidasGuardadas = Panel.transform.Find("Partidas_Guardadas").gameObject;   
        GuardarCambios = Panel.transform.Find("GuardarCambios").gameObject; 
        BotonesInferior = Panel.transform.Find("Botones").gameObject;
        sJugadorLook = Jugador.transform.Find("PlayerCamera").GetComponent<PlayerLook>(); 
        sPlayerMove = Jugador.GetComponent<PlayerMove>();
    }
    private void Start() 
    {    
        Panel.SetActive(false);
        PartidasGuardadas.SetActive(false); 
        GuardarCambios.SetActive(false);
        pausado = false;
    }
    private void Update() 
    {
        if(Input.GetKeyDown(keyPausa))
        {
            On_Pausa();
        }
    }
    public void OnClick_Menu()
    {
        GuardarCambios.SetActive(true);
    }
    public void OnClick_SiGuardarCambios()
    {
        PartidasGuardadas.SetActive(true);
        BotonesInferior.SetActive(false);
    }
    public void OnClick_NoGuardarCambios()
    {
        SceneManager.LoadScene(nombreSceneMenu);
    }
    public void On_Pausa()
    {
        if(!pausado)
        {
            CanvasPartida.SetActive(false);
            sJugadorLook.UnlockCursor();
            sJugadorLook.enabled = false;
            sPlayerMove.enabled = false;
            Panel.SetActive(true);
            pausado = true;
        }
        else
        {
            CanvasPartida.SetActive(true);
            PartidasGuardadas.SetActive(false); 
            GuardarCambios.SetActive(false);

            sJugadorLook.enabled = true;
            sPlayerMove.enabled = true;
            sJugadorLook.LockCursor();
            Panel.SetActive(false);
            pausado = false;
        }
    }
}
