using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePeiceInteraction: MonoBehaviour {
	private bool selectable = true;
    private GameManagement gameManagerScript;
    public GameObject gameManagerObject;
    private Color color = Color.clear;
    private Color pulsecolor = Color.white;
    private Renderer rend;
    private byte state;
    private byte storedX, storedY, storedZ; //do not need an int as we are working on a 9/9/9 grid
    private bool pulse = false;
    private bool pulseDirection = true;
    private float timer = 0.0f;
    private float changeColourTime = 3.5f; 
    private void Start()
    {
        gameManagerObject = GameObject.Find("GameManager");
        gameManagerScript = (GameManagement)gameManagerObject.GetComponent(typeof(GameManagement));
        state = 0;
        rend = GetComponent<Renderer>();
        color = gameObject.GetComponent<Renderer>().material.color;
    }
    public byte getState()
    {
        return state;
    }
    public void setLoc(byte x, byte y, byte z)
    {
        storedX = x;
        storedY = y;
        storedZ = z;
    }
    public void setStateopponentSelected()
    {
        color.g = 256.0f;
        rend.material.color = color;
        selectable = false;
        state = 2;
    }

    private void pulsate()
    {
        
        if (pulseDirection == true)
        {
            timer += Time.deltaTime;
            rend.material.color = Color.Lerp(color, pulsecolor, timer / changeColourTime);
        }
        else if (pulseDirection == false)
        {
            timer -= Time.deltaTime;
            rend.material.color = Color.Lerp(color, pulsecolor, timer / changeColourTime);
        }
        if (timer >= 3.0f && pulseDirection == true)
        {
            pulseDirection = false;
        }
        if(timer <= 0.0f)
        {
            pulse = false;
            rend.material.color = color;
            timer = 0.0f;
        }
    }
    public void startPulse()
    {
        pulse = true;
        pulseDirection = true;
    }


    public void OnMouseDown()
    {
        if(selectable == true)
        {
            if (gameManagerScript.getCurrentTurn() == 0)
            {
                color.r = 256.0f;
                rend.material.color = color;
                selectable = false;
                state = 1;
                gameManagerScript.gamePeiceUpdate(storedX, storedY, storedZ, state);
                gameManagerScript.setcurrentTurn();
            }
            else
            {
                color.g = 256.0f;
                rend.material.color = color;
                selectable = false;
                state = 2;
                gameManagerScript.gamePeiceUpdate(storedX, storedY, storedZ, state);
                gameManagerScript.setcurrentTurn();
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }
    public void displayThis()
    {
        gameObject.SetActive(true);
    }
    public void hideThis()
    {
        if (selectable == true)
        {
            gameObject.SetActive(false);
        }
    }
    void Update()
    {
        if (pulse)
        {
            pulsate();
        }
    }
}
