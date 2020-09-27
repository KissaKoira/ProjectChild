using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeSettings : MonoBehaviour
{
    public float TimeBetweenAttack;
    public float CriticalRate;
    public float DamageAmount;

    public static string MeleeDamageName;
    public static GameObject MeleeDamageGameObject;

   
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MeleeDamageName == null)
        {
            StopCoroutine(MeleeTimeBetweenDamage(MeleeDamageName));
        }
        else if (MeleeDamageName != null)
        {
            StartCoroutine(MeleeTimeBetweenDamage(MeleeDamageName));
            Debug.Log("We hit" + MeleeDamageName);
        }
        else if (MeleeDamageGameObject != null)
        {
            StartCoroutine(MeleeTimeBetweenDamage(null,MeleeDamageGameObject));
            Debug.Log("We hit" + MeleeDamageGameObject.name);

        }
        else if (MeleeDamageGameObject == null)
        {
            StopCoroutine(MeleeTimeBetweenDamage(null,MeleeDamageGameObject));
        }

    }
    public  IEnumerator MeleeTimeBetweenDamage(string _name = null , GameObject _gameObject = null)
    {
        if (_name != null)
        {
            GameObject.Find(_name).GetComponent<CharacterParent>().meleeHit(DamageAmount, CriticalRate);
        }
        else if (_gameObject != null)
        {
            _gameObject.GetComponent<CharacterParent>().meleeHit(DamageAmount,CriticalRate);
        }
        yield return new WaitForSeconds(TimeBetweenAttack);

    }
    


}
