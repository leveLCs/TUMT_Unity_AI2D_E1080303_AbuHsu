using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public static PlayerController instance = null;

    public System.Action OnDamaged;
    public System.Action OnDeath;
    public System.Action OnWin;

    public float hp = 100;
    public float currentHp;

    public float hpValue;

    public int vCount = 0;

    private void Awake()
    {
        instance = this;
        currentHp = hp;
    }

    public void OnPickV()
    {
        vCount++;

        if (vCount == 10)
        {
            OnWin();
        }
    }

    public void OnDamage()
    {
        currentHp -= 10;
        if (OnDamaged != null)
        {
            OnDamaged();
        }

        if (currentHp <= 0)
        {
            if (OnDeath != null)
            {
                OnDeath();
            }
        }

    }


}
