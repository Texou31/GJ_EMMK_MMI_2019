using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MentalHealthController : MonoBehaviour
{
    public float fearPoints;
    public float maximumFearPoints;

    public float regenSpeed;
    public float decreaseSpeed;

    public bool invert;

    public FearBar fearBar;
    public EndGameManager endGameManager;

    private PlayersLinkController plc;
    private PauseManager pauseManager;


    // Start is called before the first frame update
    void Start()
    {
        plc = GetComponent<PlayersLinkController>();
        pauseManager = GetComponent<PauseManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!pauseManager.isPaused && !pauseManager.inDialog && !pauseManager.isGameplayPaused)
        {
            UpdateFear(!plc.AreLinked());
            UpdateFearBar();
        }
    }

    private void UpdateFear(bool areScared)
    {
        if (areScared)
        {
            fearPoints += decreaseSpeed * Time.deltaTime;
            if(fearPoints >= maximumFearPoints)
            {
                Debug.Log("GameOver !");
                endGameManager.GameOver();
                fearPoints = maximumFearPoints;
            }
        } else
        {
            fearPoints -= regenSpeed * Time.deltaTime;
            if(fearPoints < 0)
            {
                fearPoints = 0;
            }
        }
    }

    private void UpdateFearBar()
    {
        
        fearBar.NewPercent((invert ? 1 - fearPoints / maximumFearPoints : fearPoints / maximumFearPoints));
    }
}
