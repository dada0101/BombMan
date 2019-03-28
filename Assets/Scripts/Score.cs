using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public bool APlayer = false;
    public bool BPlayer = false;
    public GameObject ScoreImage;
    public Sprite[] ScoreImg;

	void Update () {
		if(APlayer==true&&BPlayer==false)
        {
            ScoreImage.GetComponent<Image>().sprite = ScoreImg[0];
            ScoreImage.SetActive(true);
        }
        else if(APlayer == false && BPlayer == true)
        {
            ScoreImage.GetComponent<Image>().sprite = ScoreImg[1];
            ScoreImage.SetActive(true);
        }
        else if(APlayer == true && BPlayer == true)
        {
            ScoreImage.GetComponent<Image>().sprite = ScoreImg[2];
            ScoreImage.SetActive(true);
        }
	}
}
