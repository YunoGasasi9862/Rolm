using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoGenerator : MonoBehaviour
{
    public static bool isGenerated = false;
    [SerializeField] GameObject Player;
    [SerializeField] float minX, maxX;
    [SerializeField] GameObject Logo;
    private GameObject tempLogo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGenerated)
        {
            float Distance = ReturnGeneratedDistance();
            Vector3 deployDistance = new Vector3(Distance, Player.transform.position.y, Player.transform.position.z);
            tempLogo = Instantiate(Logo, deployDistance, Quaternion.identity);
            isGenerated = true;

        }

        if(pastTheLogo())
        {
            isGenerated = false;
        }
        
    }

    private float ReturnGeneratedDistance()
    {
        float Distance = Random.Range(minX, maxX);
        return Player.transform.position.x + Distance;
    }

    private bool pastTheLogo()
    {
        if(tempLogo.transform.position.x < Player.transform.position.x)
        {
            return true;
        }

        return false;
    }
}
