using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    AudioSource sfxSource;

    [Header("Main Menu SFX")]
    public AudioClip menu_Click;
    public AudioClip menu_Back;
    public AudioClip menu_Error;
    public AudioClip menu_Exit;
    public AudioClip menu_Esc;

    [Header("GUI SFX")]
    public AudioClip paper_Open;
    public AudioClip paper_Close;

    // Start is called before the first frame update
    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
    }

    public void MenuClick()
    {
        sfxSource.PlayOneShot(menu_Click, 0.7f);
    }
    public void MenuBack()
    {
        sfxSource.PlayOneShot(menu_Back, 0.7f);
    }
    public void MenuError()
    {
        sfxSource.PlayOneShot(menu_Error, 0.3f);
    }
    public void MenuExit()
    {
        sfxSource.PlayOneShot(menu_Exit, 1f);
    }
    public void MenuESC()
    {
        sfxSource.PlayOneShot(menu_Esc, 0.7f);
    }
    public void PaperOpen()
    {
        sfxSource.PlayOneShot(paper_Open, 1f);
    }
    public void PaperClose()
    {
        sfxSource.PlayOneShot(paper_Close, 1f);
    }
}
