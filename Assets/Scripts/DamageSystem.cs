using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        accHp = 100;
        text.GetComponent<Text>().text = " ";
    }

    private double accHp; 
    private double speed; 
    private double dmg; 

    private int damage762x39 = 22;
    private int damage9mm = 18;
    private int damage556x45 = 21;

    private int speed762x39 = 730;
    private int speed9mm = 360;
    private int speed556x45 = 920;

    private int weight762x39 = 10;
    private int weight9mm = 8;
    private int weight556x45 = 4;

    private int lightAndMediumArmorSpeedTreshold = 470;
    private int heavyArmorSpeedTreshold = 800;

    private double softArmorDamageReduction = 0.8;
    private double hardArmorDamageReduction = 0.65;

    public Transform text;

    // Update is called once per frame
    void Update()
    {
        if (accHp <= 0)
            Destroy(gameObject);
    }

    private void Damage(int damage, Collision col, double speedTreshold, int startingSpeed, double armorReduction, Transform text)
    {
        speed = col.relativeVelocity.magnitude;

        if (speed > speedTreshold)
        {
            dmg = damage * ((speed*speed) / (startingSpeed*startingSpeed));
            text.GetComponent<Text>().text = $"Prędkość pocisku w momencie trafienia: {Math.Round(speed, 3)} m/s \n" +
                $"Zadane obrażenia: {Math.Round(dmg,2)} \n" +
                $"Przebicie pancerza: TAK";
        }
        else
        {
            dmg = (damage * ((speed * speed) / (startingSpeed * startingSpeed)) * armorReduction);
            text.GetComponent<Text>().text = $"Prędkość pocisku w momencie trafienia: {Math.Round(speed,3)} m/s \n" +
                $"Zadane obrażenia: {Math.Round(dmg,2)} \n" +
                $"Przebicie pancerza: Nie \n" +
                $"Obrażenia pochłonięte przez pancerz: {Math.Round(damage * ((speed * speed) / (startingSpeed * startingSpeed)) - dmg,2)}";
        }

        accHp -= dmg;
        Destroy(col.gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Bullet")
        {
            if (gameObject.tag == "EnemyLight")
            {
                if (col.gameObject.name == "9mm(Clone)")
                {
                    Damage(damage9mm, col, lightAndMediumArmorSpeedTreshold, speed9mm, softArmorDamageReduction, text);
                }

                if (col.gameObject.name == "7.62mm(Clone)")
                {
                    Damage(damage762x39, col, lightAndMediumArmorSpeedTreshold, speed762x39, softArmorDamageReduction, text);
                }

                if (col.gameObject.name == "5.56mm(Clone)")
                {
                    Damage(damage556x45, col, lightAndMediumArmorSpeedTreshold, speed556x45, softArmorDamageReduction, text);
                }
            }

            if (gameObject.tag == "EnemyMedium")
            {
                if (col.gameObject.name == "9mm(Clone)")
                {
                    Damage(damage9mm, col, lightAndMediumArmorSpeedTreshold, speed9mm, hardArmorDamageReduction, text);
                }

                if (col.gameObject.name == "7.62mm(Clone)")
                {
                    Damage(damage762x39, col, lightAndMediumArmorSpeedTreshold, speed762x39, hardArmorDamageReduction, text);
                }

                if (col.gameObject.name == "5.56mm(Clone)")
                {
                    Damage(damage556x45, col, lightAndMediumArmorSpeedTreshold, speed556x45, hardArmorDamageReduction, text);
                }
            }

            if (gameObject.tag == "EnemyHeavy")
            {
                if (col.gameObject.name == "9mm(Clone)")
                {
                    Damage(damage9mm, col, heavyArmorSpeedTreshold, speed9mm, hardArmorDamageReduction, text);
                }

                if (col.gameObject.name == "7.62mm(Clone)")
                {
                    Damage(damage762x39, col, heavyArmorSpeedTreshold, speed762x39, hardArmorDamageReduction, text);
                }

                if (col.gameObject.name == "5.56mm(Clone)")
                {
                    Damage(damage556x45, col, heavyArmorSpeedTreshold, speed556x45, hardArmorDamageReduction, text);
                }
            }

            if (gameObject.tag == "Wall")
            {
                if (col.gameObject.name == "9mm(Clone)")
                    Destroy(col.gameObject);

                if (col.gameObject.name == "7.62mm(Clone)")
                    Destroy(col.gameObject);
            }
        }
    }
}
