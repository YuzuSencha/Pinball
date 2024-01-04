using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    private const int SmallStarPoints = 5;
    private const int LargeStarPoints = 10;
    private const int SmallCloudPoints = 10;
    private const int LargeCloudPoints = 30;

    private int score = 0;

    private float visiblePosZ = -6.5f;
    private GameObject gameoverText;
    private GameObject scoreboardText;
    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        this.scoreboardText = GameObject.Find("Score");
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ){
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }

    void OnCollisionEnter(Collision collision){
        switch(collision.gameObject.tag){
            default:
                break;
            case "LargeStarTag":
                score += LargeStarPoints;
                break;            
            case "SmallStarTag":
                score += SmallStarPoints;
                break;
            case "LargeCloudTag":
                score += LargeCloudPoints;
                break;
            case "SmallCloudTag":
                score += SmallCloudPoints;
                break;
        }
        this.scoreboardText.GetComponent<Text>().text = score.ToString("D7");

    }
}
