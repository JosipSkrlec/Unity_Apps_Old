using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectToUnactiveAfterSeconds : MonoBehaviour
{
    [SerializeField]
    private float Cooldown = 5.0f;
    public float getCooldown() { return this.Cooldown; }
    public void setCooldown(float value) { this.Cooldown = value; }

    float time;
    
    private void Update()
    {
        time += Time.deltaTime;

        if (time >= Cooldown)
        {
            time = 0.0f;
            this.gameObject.SetActive(false);
        }


    }


}
