using UnityEngine;

public class AudioStart : MonoBehaviour
{
    public AudioSource clip_knife;
    public AudioSource clip_two;
    public AudioSource clip_two_brake;
    public AudioSource clip_click1;
    public AudioSource clip_click2;
    public AudioSource clip_click3;
    public AudioSource clip_fly_in;
    public AudioSource clip_fly_out;
    public AudioSource clip_eyes;
    public AudioSource clip_boom1;
    public AudioSource clip_boom2;
    public AudioSource clip_boom3;
    public AudioSource clip_boom4;
    public AudioSource clip_fone_music;
    
    public void fonemusic()
    {
        clip_fone_music.Play();
    }
    
    public void play_clip_knife() 
    {
        clip_knife.Play(); 
    }

    public void play_clip_two()
    {
        clip_two.Play();
    }

    public void play_clip_two_brake()
    {
        clip_two_brake.Play();
    }

    public void play_clip_click1()
    {
        clip_click1.Play();
    }

    public void play_clip_click2()
    {
        clip_click2.Play();
    }

    public void play_clip_click3()
    {
        clip_click3.Play();
    }

    public void play_clip_fly_in()
    {
        clip_fly_in.Play();
    }

    public void play_clip_fly_out()
    {
        clip_fly_out.Play();
    }

    public void play_clip_eyes()
    {
        clip_eyes.Play();
    }    

    public void play_clip_boom1()
    {
        clip_boom1.Play();
    }

    public void play_clip_boom2()
    {
        clip_boom2.Play();
    }

    public void play_clip_boom3()
    {
        clip_boom3.Play();
    }

    public void play_clip_boom4()
    {
        clip_boom4.Play();
    }
}
