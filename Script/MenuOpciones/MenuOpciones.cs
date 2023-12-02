using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{
    //Resolucion
    [SerializeField] Dropdown ResolutionDropdown;
    private Resolution[] Resolutions;

    //Calidad
    [SerializeField] Dropdown QualityDropdown;
    [SerializeField] List<string> QualityLevels = new List<string> { "Muy Baja", "Baja", "Media", "Alta", "Muy Alta", "Ultra" };

    //Pantalla Completa
    [SerializeField] Toggle FullScreenToggle;

    //Brillo
    [SerializeField] bool Glow;
    [SerializeField] Slider GlowSlider;
    [SerializeField] PanelBrillo PanelBrillo;

    //Volumen
    [SerializeField] Slider VolumenSlider;
    [SerializeField] Image ImageMute;

    //Regresar
    [SerializeField] GameObject BotonRegresar;
    [SerializeField] GameObject PanelAnterior;



    // Start is called before the first frame update
    void Start()
    {
        ResolutionStart();
        QualityStart();
        FullScreenStart();
        GlowStart();
        VolumenStart();
        BotonRegresarStart();
        gameObject.SetActive(false);
    }
    //Resolucion
    void ResolutionStart()
    {
        Resolutions = Screen.resolutions;
        ResolutionDropdown.ClearOptions();
        List<string> Opciones = new List<string>();

        foreach(Resolution resolution in Resolutions)
        {
            Opciones.Add(resolution.width+" x "+resolution.height);
        }

        ResolutionDropdown.AddOptions(Opciones);
        ResolutionDropdown.value = PlayerPrefs.GetInt("Resolution", Resolutions.Length/2);
        ResolutionDropdown.GetComponent<Dropdown>().onValueChanged.AddListener(SetResolution);
        SetResolution(ResolutionDropdown.value);
    }

    void SetResolution(int ResolutionIndex)
    {
        Screen.SetResolution(Resolutions[ResolutionIndex].width, Resolutions[ResolutionIndex].height, PlayerPrefs.GetInt("FullScreen", 1) == 1);
        PlayerPrefs.SetInt("Resolution", ResolutionIndex);
    }

    //Calidad
    void QualityStart()
    {
        QualityDropdown.ClearOptions();
        QualityDropdown.AddOptions(QualityLevels);
        QualityDropdown.value = PlayerPrefs.GetInt("Calidad", (int)(QualityLevels.Count / 2));
        QualityDropdown.GetComponent<Dropdown>().onValueChanged.AddListener(QualityDropdownChange);
        AjustarCalidad();
    }
    void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(QualityDropdown.value);
        PlayerPrefs.SetInt("Calidad", QualityDropdown.value);
    }

    void QualityDropdownChange(int change)
    {
        QualitySettings.SetQualityLevel(change);
        PlayerPrefs.SetInt("Calidad", change);
    }

    //Pantalla Completa
    void FullScreenStart()
    {
        FullScreenToggle.isOn = PlayerPrefs.GetInt("FullScreen", 1) == 1;
        FullScreenToggle.onValueChanged.AddListener(ChangeFullScreenToggle);
        Screen.fullScreen = FullScreenToggle.isOn;
    }
    void ChangeFullScreenToggle(bool valor)
    {
        Screen.fullScreen = valor;
        if (valor)
        {
            PlayerPrefs.SetInt("FullScreen", 1);
        }
        else
        {
            PlayerPrefs.SetInt("FullScreen", 0);
        }
    }

    //Brillo
    void GlowStart()
    {
        if (Glow)
        {
            GlowSlider.value = PlayerPrefs.GetFloat("Brillo", 0.5f);
            GlowSlider.onValueChanged.AddListener(ChangeGlowSlider);
        }
        
    }
    void ChangeGlowSlider(float valor)
    {
        if (Glow)
        {
            PlayerPrefs.SetFloat("Brillo", valor);
            PanelBrillo.ActualizarBrillo();
        }
        
    }

    //Volumen
    void VolumenStart()
    {
        VolumenSlider.value = PlayerPrefs.GetFloat("VolumenAudio", 0.5f);
        AudioListener.volume = VolumenSlider.value;
        RevisarMute();
        VolumenSlider.onValueChanged.AddListener(ChangeVolumenSlider);
    }

    void ChangeVolumenSlider(float valor)
    {
        PlayerPrefs.SetFloat("VolumenAudio", valor);
        AudioListener.volume=valor;
        RevisarMute();
    }

    void RevisarMute()
    {
        if (VolumenSlider.value == 0)
        {
            ImageMute.enabled = true;
        }
        else
        {
            ImageMute.enabled = false;
        }
    }

    //boton regresar
    void BotonRegresarStart()
    {
        BotonRegresar.GetComponent<Button>().onClick.AddListener(Regresar);
    }

    void Regresar()
    {
        gameObject.SetActive(false);
        PanelAnterior.SetActive(true);
    }






}
