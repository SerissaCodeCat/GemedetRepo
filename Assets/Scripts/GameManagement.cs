using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagement : MonoBehaviour {
    public GameObject playingPeice;
    private GameObject[,,] board = new GameObject[9,9,9];
    public GameObject Winscreen;
    public GameObject TurnIndicator;
    private float visibleLevels = 10;
    private byte currentTurn;
    private byte mostRecentX = 10;
    private byte mostRecentY = 10;
    private byte mostRecentZ = 10;
    // Use this for initialization
    void Start ()
    {
        TurnIndicator.GetComponent<UnityEngine.UI.Image>().color = Color.red;
        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                for (int k = 0; k < 9; k++)
                {
                    GameObject temp = ((GameObject)Instantiate(playingPeice, new Vector3(i * 1.5f, j * 1.5f, k * 1.5f), Quaternion.identity));
                    board[i, j, k] = temp;
                    GamePeiceInteraction tempScript = (GamePeiceInteraction)board[i, j, k].gameObject.GetComponent(typeof(GamePeiceInteraction));
                    tempScript.setLoc((byte)i, (byte)j, (byte)k);
                    currentTurn = 0;
                }
            }
        }
	}
    public void loadNewBoard()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    public void setcurrentTurn()
    {
        if(currentTurn == 1)
        {
            TurnIndicator.GetComponent<UnityEngine.UI.Image>().color = Color.red;
            currentTurn = 0;
        }
        else
        {
            TurnIndicator.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            currentTurn = 1;
        }
    }
    public void showLastTurn()
    {
        if(mostRecentX != 10)
        {
            GamePeiceInteraction temp = (GamePeiceInteraction)board[mostRecentX, mostRecentY, mostRecentZ].gameObject.GetComponent(typeof(GamePeiceInteraction));
            temp.startPulse();
        }
    }
    public byte getCurrentTurn()
    {
        return currentTurn;
    }
	public void setVisibleLevel(float selection)
    {
        for (int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                for(int k = 0; k < 9; k++)
                {
                    GamePeiceInteraction temp = (GamePeiceInteraction)board[i,j,k].gameObject.GetComponent(typeof(GamePeiceInteraction));
                    if (j != selection-1 && selection != 10)
                    {
                        temp.hideThis();
                    }
                    else
                    {
                        temp.displayThis();
                    }
                }
            }
        }
    }
    public void gamePeiceUpdate(byte x, byte y, byte z, byte state)
    {
        mostRecentX = x;
        mostRecentY = y;
        mostRecentZ = z;
        Debug.Log("x possition:" + x + " y possition:" + y + " z possition:" + z);
        byte currentColour = state;
        byte connectedCount = 1;
        lineCountXNegative(x, y, z, currentColour, ref connectedCount);
        lineCountXPositive(x, y, z, currentColour, ref connectedCount);
        if(connectedCount != 6)
        {
            connectedCount = 1;
            lineCountYNegative(x, y, z, currentColour, ref connectedCount);
            lineCountYPositive(x, y, z, currentColour, ref connectedCount);
            if (connectedCount != 6)
            {
                connectedCount = 1;
                lineCountZNegative(x, y, z, currentColour, ref connectedCount);
                lineCountZPositive(x, y, z, currentColour, ref connectedCount);
                if (connectedCount != 6)
                {
                    connectedCount = 1;
                    lineCountXYNegative(x, y, z, currentColour, ref connectedCount);
                    lineCountXYPositive(x, y, z, currentColour, ref connectedCount);
                    if(connectedCount != 6)
                    {
                        connectedCount = 1;
                        lineCountYXNegative(x, y, z, currentColour, ref connectedCount);
                        lineCountYXPositive(x, y, z, currentColour, ref connectedCount);
                        if(connectedCount !=6 )
                        {
                            connectedCount = 1;
                            lineCountZXNegative(x, y, z, currentColour, ref connectedCount);
                            lineCountZXPositive(x, y, z, currentColour, ref connectedCount);
                            if(connectedCount != 6)
                            {
                                connectedCount = 1;
                                lineCountXZNegative(x, y, z, currentColour, ref connectedCount);
                                lineCountXZPositive(x, y, z, currentColour, ref connectedCount);
                                if (connectedCount != 6)
                                {
                                    connectedCount = 1;
                                    lineCountXYZNegative(x, y, z, currentColour, ref connectedCount);
                                    lineCountXYZPositive(x, y, z, currentColour, ref connectedCount);
                                    if(connectedCount != 6)
                                    {
                                        connectedCount = 1;
                                        lineCountYPositiveXZNegative(x, y, z, currentColour, ref connectedCount);
                                        lineCountXZPositiveYNegative(x, y, z, currentColour, ref connectedCount);
                                        if(connectedCount !=6)
                                        {
                                            connectedCount = 1;
                                            lineCountXYPositiveZNegative(x, y, z, currentColour, ref connectedCount);
                                            lineCountXYNegativeZPositive(x, y, z, currentColour, ref connectedCount);
                                            if(connectedCount !=6)
                                            {
                                                connectedCount = 1;
                                                lineCountXPositiveYZNegative(x, y, z, currentColour, ref connectedCount);
                                                lineCountXNegativeYZPositive(x, y, z, currentColour, ref connectedCount);
                                                if(connectedCount !=6)
                                                {

                                                }
                                                else
                                                {
                                                    Winscreen.SetActive(true);
                                                }

                                            }
                                            else
                                            {
                                                Winscreen.SetActive(true);
                                            }
                                        }
                                        else
                                        {
                                            Winscreen.SetActive(true);
                                        }

                                    }
                                    else
                                    {
                                        Winscreen.SetActive(true);
                                    }
                                }
                                else
                                {
                                    Winscreen.SetActive(true);
                                }
                            }
                            else
                            {
                                Winscreen.SetActive(true);
                            }
                        }
                        else
                        {
                            Winscreen.SetActive(true);
                        }
                    }
                    else
                    {
                        Winscreen.SetActive(true);
                    }

                }
                else
                {
                    Winscreen.SetActive(true);
                }

            }
            else
            {
                Winscreen.SetActive(true);
            }
        }
        else
        {
            Winscreen.SetActive(true);
        }

    }

    private void lineCountXNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXNegative((byte)(x - 1), y, z, state, ref count);
                }
            }
        }
    }

    private void lineCountXPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXPositive((byte)(x + 1), y, z, state, ref count);
                }
            }
        }
    }

    private void lineCountYPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (y + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x, y + 1, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountYPositive(x, (byte)(y + 1), z, state, ref count);
                }
            }
        }
    }

    private void lineCountYNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (y - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x, y - 1, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountYNegative(x, (byte)(y - 1), z, state, ref count);
                }
            }
        }
    }

    private void lineCountZPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x, y , z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountZPositive(x, y, (byte)(z + 1), state, ref count);
                }
            }
        }
    }
    private void lineCountZNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x, y, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountZNegative(x, y, (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXYNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && y -1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y -1, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXYNegative((byte)(x - 1), (byte)(y -1), z, state, ref count);
                }
            }
        }
    }

    private void lineCountXYPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && y + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y + 1, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXYPositive((byte)(x + 1), (byte)(y +1), z, state, ref count);
                }
            }
        }
    }

    private void lineCountYXNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && y - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y - 1, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountYXNegative((byte)(x + 1), (byte)(y - 1), z, state, ref count);
                }
            }
        }
    }

    private void lineCountYXPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && y + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y + 1, z].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountYXPositive((byte)(x - 1), (byte)(y + 1), z, state, ref count);
                }
            }
        }
    }
    private void lineCountXZNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXZNegative((byte)(x - 1), y, (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXZPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y, z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXZPositive((byte)(x + 1), y, (byte)(z + 1), state, ref count);
                }
            }
        }
    }

    private void lineCountZXNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y, z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountZXNegative((byte)(x - 1), y, (byte)(z + 1), state, ref count);
                }
            }
        }
    }

    private void lineCountZXPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountZXPositive((byte)(x + 1), y, (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXYZNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && y - 1 >= 0 && z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y - 1, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXYZNegative((byte)(x - 1), (byte)(y - 1), (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXYZPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && y + 1 <= 8 && z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y + 1, z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXYZPositive((byte)(x + 1), (byte)(y + 1), (byte)(z + 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXZPositiveYNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && y - 1 >= 0 && z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y - 1, z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXZPositiveYNegative((byte)(x + 1), (byte)(y - 1), (byte)(z + 1), state, ref count);
                }
            }
        }
    }

    private void lineCountYPositiveXZNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && y + 1 <= 8 && z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y + 1, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountYPositiveXZNegative((byte)(x - 1), (byte)(y + 1), (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXYPositiveZNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count< 6)
        {
            if (x + 1 <= 8 && y + 1 <= 8 && z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y + 1, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXZPositiveYNegative((byte)(x + 1), (byte)(y + 1), (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXYNegativeZPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && y - 1 >= 0 && z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y - 1, z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountYPositiveXZNegative((byte)(x - 1), (byte)(y - 1), (byte)(z + 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXPositiveYZNegative(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x + 1 <= 8 && y - 1 >= 0 && z - 1 >= 0)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x + 1, y - 1, z - 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXPositiveYZNegative((byte)(x + 1), (byte)(y - 1), (byte)(z - 1), state, ref count);
                }
            }
        }
    }

    private void lineCountXNegativeYZPositive(byte x, byte y, byte z, byte state, ref byte count)
    {
        if (count < 6)
        {
            if (x - 1 >= 0 && y + 1 <= 8 && z + 1 <= 8)
            {
                GamePeiceInteraction temp = (GamePeiceInteraction)board[x - 1, y + 1, z + 1].gameObject.GetComponent(typeof(GamePeiceInteraction));
                if (temp.getState() == state)
                {
                    count++;
                    Debug.Log("connected count = " + count);
                    lineCountXNegativeYZPositive((byte)(x - 1), (byte)(y + 1), (byte)(z + 1), state, ref count);
                }
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
		
	}
}
