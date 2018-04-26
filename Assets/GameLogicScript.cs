﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogicScript : MonoBehaviour
{
    public Instantiate512cubes volviz;
    public int _gameScore = 0;
    public int initialBPM = 150;
    int _bpm;
    float _bpmScale; // bpm * 1min/60s
    public float conductorTolerance = 1.0f/4.0f; // fraction of a beat
    public double _inputDelay = 25.0/1000.0; // in seconds

    // Use this for initialization
    void Start()
    {
        SetBPM(initialBPM);
    }

    // Update is called once per frame
    void Update()
    {
     
        double keyTime = AudioSettings.dspTime - _inputDelay;

        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            if (KeyTimeGoodEnough( keyTime ))
                _gameScore++;
            else
                _gameScore--;
        }
        
        timer++;
		if(timer % 10 == 0){
			//if(timer > 30 * 3)
				//WoodwindSlider.value--;
			if(timer > 30 * 6)
				StringSlider.value--;
			/*if(timer > 30 * 9)
				HornSlider.value++;
			if(timer > 30 * 12)
				PercussionSlider.value++;*/
		}
        

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            volviz.volscale -= 1.35f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            volviz.volscale += 1.35f;
        }
        if (Input.GetKeyDown("z"))
        {
            StringSlider.value = 100;
        }

    }

    private bool KeyTimeGoodEnough( double t )
    {
        float beat = _bpmScale * (float)t;
        float nearestBeat = Mathf.Round(beat);
        float beatDifference = Mathf.Abs(beat - nearestBeat);

        return beatDifference < conductorTolerance;
    }

    public void SetBPM(int bpm)
    {
        _bpm = bpm;
        _bpmScale = _bpm / 60.0f;
    }

    public int GetBPM()
    {
        return _bpm;
    }
}