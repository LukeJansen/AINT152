using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingularityHandler : MonoBehaviour {

    public Light light;
    public Transform player;
    public Transform[] singularities;

    private float angleModifier;

    private void Update()
    {
        AngleHandle();
    
        for (int i = 0; i < 3; i++)
        {
            Vector3 newRot = new Vector3(singularities[i].eulerAngles.x, singularities[i].eulerAngles.y, singularities[i].eulerAngles.z + 1f);
            singularities[i].eulerAngles = Vector3.Lerp(singularities[i].eulerAngles, newRot, Time.deltaTime * (20 * (i+1)));
        }
    }

    private void AngleHandle()
    {
        if (light.spotAngle >= 90) angleModifier = -0.25f;
        if (light.spotAngle <= 50) angleModifier = 0.25f;

        light.spotAngle += angleModifier;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.SendMessage("TakeDamage", 2);
            player.position = Vector3.Lerp(player.position, new Vector3(1, 7), Time.deltaTime);
        }
    }
}
