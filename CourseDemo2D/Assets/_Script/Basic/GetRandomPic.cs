using UnityEngine;
using UnityEngine.UI;

public class GetRandomPic : MonoBehaviour
{
    public Sprite[] images; //存储所有图片的array
    public int[] answers; //存储图片对应的答案
    public Image targetImage;//UI image显示最终随机出来的结果
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void showRandomPic()
    {
        int index = Random.Range(0, images.Length);
        targetImage.sprite = images[index];
    }
}
