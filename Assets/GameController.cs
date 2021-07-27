using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject coin;
    private int xPos;
    private int ypos;
    private int coinDrop;
    public int coinnumber;
    
    
    int m_score;
    UImanager m_ui;
    // Start is called before the first frame update
    void Start()
    {
        
        m_ui = FindObjectOfType<UImanager>();
        m_ui.SetScoreText("Score: " + m_score);
        StartCoroutine(CoinDrop());
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int SetScore(int value)
    {
        return value;
    }
    public int getScore()
    {
        return m_score;
    }
    public void ScoreIncrement()
    {
        m_score++;
        m_ui.SetScoreText("Score: " + m_score);
    }
    
    public IEnumerator CoinDrop()
    {
        while (coinDrop < coinnumber)
        {
            xPos = Random.Range(1, 234);
            ypos = Random.Range(20, 22);
            Instantiate(coin, new Vector2(xPos, ypos), Quaternion.identity);
            yield return new WaitForSeconds(0f);
            coinDrop++;
        }
    }

    
}
