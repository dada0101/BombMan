using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//分数
public class Score2 : MonoBehaviour
{
    public bool APlayer = false;                    //玩家A是否死亡
    public bool BPlayer = false;                    //玩家B是否死亡
    public GameObject ScoreImage;                   //显示图片
    public Sprite[] ScoreImg;                       //图片数组

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (APlayer == true && BPlayer == false)
        {
            ScoreImage.GetComponent<Image>().sprite = ScoreImg[0];
            //显示隐藏的图片
            ScoreImage.SetActive(true);
        }
            
        if (APlayer == false && BPlayer == true)
        {
            ScoreImage.GetComponent<Image>().sprite = ScoreImg[1];
            ScoreImage.SetActive(true);
        }
            
        if (APlayer == true && BPlayer == true)
        {
            ScoreImage.GetComponent<Image>().sprite = ScoreImg[2];
            ScoreImage.SetActive(true);
        }
            
    }
}
