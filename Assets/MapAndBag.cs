using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAndBag : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject Map;
    [SerializeField] GameObject Bag;
    private bool _map, _bag;
    private float timer1, timer2;
    public void MapBTN()
    {
        Map.SetActive(true);
        _map = true;
    }

    public void BagBTN()
    {
        Bag.SetActive(true);
        _bag = true;
    

    }

    private void Update()
    {
        if(_map)
        {
            timer1 += Time.deltaTime;
            if(timer1 > 3f)
            {
                Map.SetActive(false);
                _map = false;
            }
        }

        if (_bag)
        {
            timer2 += Time.deltaTime;
            if (timer2 > 3f)
            {
                Bag.SetActive(false);
                _bag = false;
            }
        }
    }
}
