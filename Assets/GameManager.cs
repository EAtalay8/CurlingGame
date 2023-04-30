using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public BallController ballController;

    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;

    public GameObject playPanel;
    public GameObject endPanel;
    public GameObject spaceText;
    public GameObject camText;

    public Text scoreText;
    public Text endScoreText;

    public bool endGame;

    #region
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            vcam2.Priority = 11;
        }
        else if (Input.GetKeyUp(KeyCode.C))
        {
            vcam2.Priority = 9;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }

        if (endGame)
        {
            playPanel.SetActive(false);
            endPanel.SetActive(true);
        }

        scoreText.text = ballController.pointCount.ToString();
        endScoreText.text = ballController.pointCount.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
