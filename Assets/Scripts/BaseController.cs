using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseController : MonoBehaviour
{
    // Referencias p�blicas a los arcos
    public BallMovement ballMovement;
    public GameObject goalText;
    public GameObject playerGoalText;


    private void Update()
    {
        goalText.GetComponent<TextMeshProUGUI>().text = ballMovement.goles.ToString();
        playerGoalText.GetComponent<TextMeshProUGUI>().text = ballMovement.golesRecibidos.ToString();
        Debug.Log(ballMovement.goles);
        Debug.Log(ballMovement.golesRecibidos);
    }

}
