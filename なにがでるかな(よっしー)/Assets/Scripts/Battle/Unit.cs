﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Unit : MonoBehaviour
{
    public int hp=1;
    public int hpmax = 500;
    [SerializeField]public int at = 1200;
    public GameObject DamageText;
    public GameObject DamageEffect;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Ondamage(int damage)
    {
        hp -= damage;
        if (hp <= 0)
        {
            hp = 0;
        }
        Instantiate(DamageText, new Vector3(transform.position.x,transform.position.y-1f, 0), transform.rotation).GetComponent<TextMesh>().text = damage.ToString();

        ParticleSystem ps = Instantiate(
            DamageEffect,
            new Vector3(transform.position.x, transform.position.y, 100), 
            transform.rotation
            ).GetComponent<ParticleSystem>();

        var main = ps.main;
        var trans = ps.transform;
        main.scalingMode = ParticleSystemScalingMode.Hierarchy;
        trans.localScale = new Vector3(10, 10, 10);

        ps.Play();
    }

    public int Magic(int attack)
    {
        int magic = Random.Range(1, 5);
        int ransuu = Random.Range(1, 21);
        float DAMAGE = 0f;

        switch (magic)
        {
            case 1:
                DAMAGE = attack * 1.8f + ransuu;
                break;
            case 2:
                DAMAGE = attack * 1.3f + ransuu;
                break;
            case 3:
                DAMAGE = attack * 0.7f + ransuu;
                break;
            case 4:
                DAMAGE = attack * 0.3f + ransuu;
                break;
        }
        return (int)DAMAGE;
    }
    
}

