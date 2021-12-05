using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float RotateSpeed = 90;
    

   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<Obstancle>() !=null)
        {
            Destroy(gameObject);
            return;
        }


        if (this.gameObject.name !="Player")
        {
           
            Destroy(gameObject);
        }

        GameManager.inst.Score();
        

        Destroy(gameObject);
    }

       void Update()
    {
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);
    }


}
