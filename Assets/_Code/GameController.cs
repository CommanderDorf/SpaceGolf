using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [SerializeField] private Transform startingPoint;
    [SerializeField] private Ball ball;
    private Hole hole;

    [SerializeField] private CinemachineVirtualCamera ballCamera;

    // EVENTS
    public delegate void StrokeChanged(int strokeCount);
    public static event StrokeChanged OnStrokeChanged;

    private int strokeCount = 0;

    private void OnEnable()
    {
        NewGame();
    }

    private void OnDisable()
    {
        if (hole != null)
        {
            hole.OnHoleReached -= HoleReached;
        }

        if (ball != null)
        {
            ball.OnStrokeEvent += AddStroke;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void NewGame()
    {
        hole = FindObjectOfType<Hole>();

        if (hole != null)
        {
            hole.OnHoleReached += HoleReached;
        }

        GameObject ballGameObject = Instantiate(ball.gameObject, startingPoint.position, Quaternion.identity);
        ball = ballGameObject.GetComponent<Ball>();
        ballCamera.Follow = ball.transform;

        if (ball != null)
        {
            ball.OnStrokeEvent += AddStroke;
        }
    }

    public void AddStroke()
    {
        strokeCount++;

        OnStrokeChanged?.Invoke(strokeCount);
    }

    public void HoleReached()
    {
        Destroy(ball.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
