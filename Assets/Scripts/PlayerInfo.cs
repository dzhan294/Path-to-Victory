using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public static PlayerInfo _instance;

    public float currenHp = 1000;
    public float totalHp = 1000;

    public float currenMp = 300;
    public float totalMp = 300;

    public float attack = 230;
    public float skillAttack = 12;

    private Slider hpSlider;
    private Slider mpSlider;


    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        hpSlider = GameObject.Find("hpBar").GetComponent<Slider>();
        mpSlider = GameObject.Find("mpBar").GetComponent<Slider>();
    }


    void Update()
    {
        hpSlider.value = (float)currenHp / totalHp;
        mpSlider.value = (float)currenMp / totalMp;
        HpAutoRecoveryr();
        MpAutoRecoveryr();

    }

    //Hp-Automatic recovery
    private void HpAutoRecoveryr()
    {
        if (currenHp > 0 && currenHp < totalHp)
        {
            currenHp += Time.deltaTime * 12.8f;
        }
    }

    //Mp-Automatic recovery
    private void MpAutoRecoveryr()
    {
        if (currenHp > 0 && currenMp < totalMp)
        {
            currenMp += Time.deltaTime * 15.8f;
        }
    }
}
