using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour {

    private int _Lives = 3;
    private int _Points = 0;

    public Text livesValue;
    public Text pointsValue;
    public GameObject gameOverSign;
    public GameObject youwinSign;

    public void SetLives(int newValue)
    {
        _Lives = newValue;
        Debug.Log("Lives now equal: " + _Lives);
        livesValue.text = _Lives.ToString();
        if (_Lives == 0)
        {
            gameOverSign.SetActive(true);
        }
    }
    public int GetLives()
    {
        return _Lives;
    }

    public void SetPoints(int newValue)
    {
        _Points = newValue;
        Debug.Log("Points are now:" + _Points);
        pointsValue.text = _Points.ToString();

        if (_Points == 45)
        {
            youwinSign.SetActive(true);
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level 2");
        }
    }

    public int GetPoints()
    {
        return _Points;
    }

}
