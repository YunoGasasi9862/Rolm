using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclableBG : MonoBehaviour
{

    [SerializeField] Transform _BG1;
    [SerializeField] Transform _BG2;
    private RaycastHit2D _hit;
    // Update is called once per frame
    void Update()
    {

        _hit = Physics2D.Raycast(transform.position, transform.right,1f);
        Debug.DrawRay(transform.position, transform.right * 1, Color.red);


        if(_hit.collider!=null && _hit.collider.CompareTag("BG1"))
        {

            float distancePush = (_BG2.position.x - _BG1.position.x)*2;

             _hit.collider.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = -3;
                _BG1.Translate(distancePush, 0, 0);
           
        }

        if (_hit.collider != null && _hit.collider.CompareTag("BG2"))
        {

            float distancePush = (_BG1.position.x - _BG2.position.x) * 2;
            _hit.collider.transform.parent.GetComponent<SpriteRenderer>().sortingOrder = -3;

       

           
                _BG2.Translate(distancePush, 0, 0);
           
        }
    }

   
}
