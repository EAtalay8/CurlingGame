using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int pointCount = 0;

    public Image barImage;

    public BallController ballController;

    public CinemachineVirtualCamera vcam1;
    public CinemachineVirtualCamera vcam2;

    public GameObject player;

    public GameObject playPanel;
    public GameObject endPanel;
    public GameObject spaceText;
    public GameObject camText;

    public GameObject ballPrefab;

    public Text scoreText;
    public Text endScoreText;

    public bool readyToSpawn = true;
    public bool endGame;

    public int throwedBallcount = 0;

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

        if (player.GetComponent<Rigidbody>().velocity.z == 0 && player.GetComponent<BallController>().isThrowed)
        {
            SpawnNewBall();
        }

        if (throwedBallcount >= 2)
        {
            endGame = true;
        }

        scoreText.text = pointCount.ToString();
        endScoreText.text = pointCount.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SpawnNewBall()
    {
        player = Instantiate(ballPrefab, new Vector3(0, 0.46f, 0), Quaternion.identity);
        player.GetComponent<BallController>().bar = barImage;
        player.GetComponent<BallController>().bar.fillAmount = 0;
        vcam1.Follow = player.transform;
        readyToSpawn = false;
        throwedBallcount++;
    }
}
