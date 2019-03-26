using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMovieByMaterial : MonoBehaviour {

    public MovieTexture _Movie;

    private float m_Moiveduration = 0;
    private float m_detaTime = 0;
    private bool ShowMovie = false;

    void Awake()
    {
        //GetComponent<RawImage>().texture = _Movie;
    }

    void Start () {
        m_detaTime = 0;
        m_Moiveduration = _Movie.duration;
        //ShowMovie = true;
        //_Movie.loop = true;
        _Movie.Play();
        Debug.Log(_Movie.duration);
    }

    void Update () {
        if (ShowMovie == false) return;
        if(!_Movie.isPlaying && m_detaTime < m_Moiveduration)
        {
            _Movie.Play();
        }
        m_detaTime += Time.deltaTime;
        if(!_Movie.isPlaying && m_detaTime > m_Moiveduration)
        {
            ShowMovie = false;
            _Movie.Stop();
            m_detaTime = 0;
        }
    }
}
