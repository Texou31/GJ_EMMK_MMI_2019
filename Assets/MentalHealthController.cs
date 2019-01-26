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

    private PlayersLinkController plc;


    // Start is called before the first frame update
    void Start()
    {
        plc = GetComponent<PlayersLinkController>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateFear(!plc.AreLinked());
        UpdateFearBar();
    }

    private void UpdateFear(bool areScared)
    {
        if (areScared)
        {
            fearPoints += decreaseSpeed * Time.deltaTime;
            if(fearPoints >= maximumFearPoints)
            {
                Debug.Log("GAME OVER !");
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
