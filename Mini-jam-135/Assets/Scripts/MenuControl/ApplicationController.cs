using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ApplicationController : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    //Verificando se e a primeira inicializada
    public static bool isFirstTime()
    {
        if (PlayerPrefs.GetString ("FirstTime") != "fakeStone")
            return true;

        return false; 
    }

    //quitar do jogo
    public static void ExitGame()
    {
       Application.Quit(); 
    }

    //deixa toda a parte de audio no maximo na primeira vez
    public static void SetDefaultConfigs()
    {
        PlayerPrefs.SetString("FirstTime", "fakeStone");
        EnableSoundMusic ();
        EnableSoundSFX ();
        SetVolumeMusic(1);
        SetVolumeSFX(1);
    }
    
    //configuracoes de audio
    //SFX
    public static void EnableSoundSFX()
    {
        PlayerPrefs.GetInt("SFXSound", 1);
    }

    public static void DisableSoundSFX()
    {
        PlayerPrefs.GetInt("SFXSound", 0);
    }

    public static bool IsMuttedSoundSFX()
    {
        if (PlayerPrefs.GetInt ("SFXSound") == 1)
            return true;
        return false;
    }

    public static void SetVolumeSFX( float volume)
    {
        PlayerPrefs.SetFloat ("SFXSoundVolume", volume);
    }

    public static float GetVolumeSFX()
    {
        return PlayerPrefs.GetFloat ("SFXSoundVolume");
    }

    //Musica
    public static void EnableSoundMusic()
    {
        PlayerPrefs.GetInt("MusicSound", 1);
    }

    public static void DisableSoundMusic()
    {
        PlayerPrefs.GetInt("MusicSound", 0);
    }

    public static bool IsMuttedSoundMusic()
    {
        if (PlayerPrefs.GetInt ("MusicSound") == 1)
            return true;
        return false;
    }

    public static void SetVolumeMusic( float volume)
    {
        PlayerPrefs.SetFloat ("MusicSoundVolume", volume);
    }

    public static float GetVolumeMusic()
    {
        return PlayerPrefs.GetFloat ("MusicSoundVolume");
    }
}
