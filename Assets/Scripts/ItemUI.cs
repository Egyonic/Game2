using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Text itemText;   //道具名文字显示
    public Text itmeUsingText;   //道具名文字显示
    public static Item currentItem; //当前的物品,需要在玩家控制器那边初始化值
    private Image itemImage;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentItem!= null) {
            itemImage.sprite = currentItem.sprite;  //设置图像
                                                    //根据状态值设置道具的作用对象
            string status = currentItem.status ? "自身" : "环境";
            if (currentItem.name == "回复药水")
                status = currentItem.count.ToString();
            itemText.text = currentItem.name + " " + status;
            if (currentItem.name == "回复药水")
                itmeUsingText.text = "";    //回复药水不需要显示使用状态
            else
                itmeUsingText.text = currentItem.isUsing ? "开" : "关";
            // 恢复药水需要单独设置
        }


    }
}
