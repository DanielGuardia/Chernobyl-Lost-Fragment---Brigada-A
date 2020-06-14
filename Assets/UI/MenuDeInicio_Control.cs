using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuDeInicio_Control : MonoBehaviour
{
#region ATRIBUTOS
[SerializeField] private string nombreStoryBoardEscena = "Storyboard(Trancisiones)";
[SerializeField] private string nombreNivel1 = "Nivel_1";
private GameObject PartidasGuardadas, Ajustes, Salir;
private bool guardandoPartida = false;
private GameObject Salir_Seguro; Button Salir_Seguro_Si, Salir_Seguro_No;
private Slider sliderSonido, sliderMusica; //En Ajustes

#endregion

#region METODOS POR DEFECTO

    private void Awake() 
    {   //Principales
        PartidasGuardadas = GameObject.Find("Partidas_Guardadas");
        Ajustes = GameObject.Find("Ajustes");
        Salir = GameObject.Find("Salir");
        //Salir
        Salir_Seguro = GameObject.Find("Seguro");
        Salir_Seguro_Si = Salir_Seguro.transform.Find("Si").gameObject.GetComponent<Button>(); 
        Salir_Seguro_No = Salir_Seguro.transform.Find("No").gameObject.GetComponent<Button>();
        //Ajustes
        sliderSonido = Ajustes.transform.Find("Grupo_Ajustes").gameObject.transform.Find("Sonido").gameObject.transform.Find("Slider").gameObject.GetComponent<Slider>();
        sliderMusica = Ajustes.transform.Find("Grupo_Ajustes").gameObject.transform.Find("Musica").gameObject.transform.Find("Slider").gameObject.GetComponent<Slider>();
        
        //Inabilitar al principio
        PartidasGuardadas.SetActive(false);
        Ajustes.SetActive(false);
        Salir.SetActive(false);  
        //Salir
        Salir_Seguro.SetActive(false);   
        //Habilitar este objeto
        gameObject.SetActive(true);  
    }
    private void Start()
    {
        //Botones
        Salir_Seguro_Si.onClick.AddListener(OnClick_Seguro_Si);
        Salir_Seguro_No.onClick.AddListener(OnClick_Seguro_No);    
        //Sliders de Ajustes
        sliderSonido.onValueChanged.AddListener(delegate {CambioDeValor_SliderSonido(); });
        sliderMusica.onValueChanged.AddListener(delegate {CambioDeValor_SliderMusica(); });
    }
    #endregion

#region METODOS CUSTOM

    #region OnClick Botones
    public void OnClick_NuevaPartida()
    {
        //SceneManager.LoadScene(nombreNivel1);
        //SceneManager.LoadScene(nombreStoryBoardEscena);
        PartidasControl.Instance.NuevaPartida(nombreStoryBoardEscena);
    }
    public void OnClick_CargarPartida()
    {
        Ajustes.SetActive(false);
        EnableCanvas(PartidasGuardadas);
        PartidasControl.Instance.RecibirNombreNivel(nombreStoryBoardEscena);
    }
    public void OnClick_Ajustes()
    {
        PartidasGuardadas.SetActive(false);
        EnableCanvas(Ajustes);
    }
    public void OnClick_Salir()
    {
        PartidasGuardadas.SetActive(false);
        Ajustes.SetActive(false);
        Salir.SetActive(true);
        Salir_Seguro.SetActive(true);
    }
    //Botones Salir
    private void OnClick_Seguro_Si()
    {
        Salir_Seguro.SetActive(false);
        Application.Quit();
    }
    private void OnClick_Seguro_No()
    {
        Salir_Seguro.SetActive(false);
        Salir.SetActive(false);
    }  
    #endregion
    
    private void EnableCanvas(GameObject canvas)
    {
        if(canvas.activeInHierarchy)
        canvas.SetActive(false);
        else
        canvas.SetActive(true);
    }
    

    #region Sliders
    private void CambioDeValor_SliderSonido()
    {
        //Codigo para controlar ajuste de sonido de sliderSonido aqui
    }
    private void CambioDeValor_SliderMusica()
    {
        //Codigo para controlar ajuste de musica de sliderMusica aqui
    }
    #endregion

    public void OnClick_GuardarPartida(string pPref)
    {
        int ejemploVariableInt = 0;
        float ejemploVariableFloat = 0.0f;
        string ejemploVariableString = "";

        if(guardandoPartida)
        {
            PlayerPrefs.SetInt(pPref + ejemploVariableInt, ejemploVariableInt);
            PlayerPrefs.SetFloat(pPref + ejemploVariableFloat, ejemploVariableFloat);
            PlayerPrefs.SetString(pPref + ejemploVariableString, ejemploVariableString);
            //Otras variable a guardar en prefabs aqui

            Application.Quit();
        }
        else
        {
            ejemploVariableInt = PlayerPrefs.GetInt(pPref + ejemploVariableInt);
            ejemploVariableFloat = PlayerPrefs.GetFloat(pPref + ejemploVariableFloat);
            ejemploVariableString = PlayerPrefs.GetString(pPref + ejemploVariableString);
            //Otras variable a ser cargadas de prefabs aqui
        }
    }

#endregion
}
