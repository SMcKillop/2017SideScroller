using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GM : MonoBehaviour {

    private int _Lives = 3;
    public int points;
    public Text livesValue;
    public Text pointsValue;

    public GameObject gameOverSign;

    public void SetLives(int newValue)
    {
        _Lives = newValue;
        Debug.Log("Lives now equal: " + _Lives);
        livesValue.text = _Lives.ToString();
        if (_Lives == 0)
        {
            DoGameOver();
        }
    }

    void DoGameOver()
    {
        gameOverSign.SetActive(true);
    }

    public int GetLives()
    {
        return _Lives;
    }
}
