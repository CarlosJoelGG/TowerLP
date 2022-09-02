using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class musica : MonoBehaviour
{
    public List<AudioSource> musicas,efectos;
    public List<AudioMixer> controlVolumen;
    public bool SFX = true, MV=true;
    public float Rsfx=0, Rmv = 0;
    // Start is called before the first frame update
    void Start()
    {
        playMusic(0);
    }
    public void volumenMusica(float a)
    {
        if (MV)
        { controlVolumen[0].SetFloat("VolumenMusica", Mathf.Log10(a) * 20);
            Rmv = a;
        }
    }
    public void volumenEfectos(float a)
    {
        if (SFX)
        { controlVolumen[0].SetFloat("VolumenEfectos", Mathf.Log10(a) * 20);
            Rsfx = a;
        }
    }
    public void muteMusic()
    {
        if (MV)
        {
            controlVolumen[0].SetFloat("VolumenMusica", Mathf.Log10(0.00000001f) * 20);
            MV = false;
        }
        else 
        {
            controlVolumen[0].SetFloat("VolumenMusica", Mathf.Log10(Rmv) * 20);
            MV = true;
        }
    }
    public void muteSFX()
    {
        if (SFX)
        {
            controlVolumen[0].SetFloat("VolumenEfectos", Mathf.Log10(0.00000001f) * 20);
            SFX = false;
        }
        else
        {
            controlVolumen[0].SetFloat("VolumenEfectos", Mathf.Log10(Rsfx) * 20);
            SFX = true;
        }
    }

    public void playMusic(int a)
    {
        for (int i = 0; i < musicas.Count; i++)
        {
            musicas[i].Stop();
        }
        musicas[a].Play();
    }
    public void playEfect(int a)
    {
        for (int i = 0; i < efectos.Count; i++)
        {
            efectos[i].Stop();
        }
        efectos[a].Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
