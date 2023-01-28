using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    [SerializeField] int amount;
    [SerializeField] bool isMultipler;
    [SerializeField] GameObject twinGate;
  
    private void OnTriggerEnter(Collider other)
    {
        int crowd = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerCrowd>()._crowd.Count + 1;
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Crowd"))
        {
            
            if (isMultipler)
            {
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerCrowd>().AddCrowd((amount - 1) * crowd);
            }
            else
            {
                GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerCrowd>().AddCrowd(amount);
            }
            Destroy(gameObject.GetComponent<BoxCollider>());
            Destroy(twinGate.gameObject.GetComponent<BoxCollider>());
        }
    }
}
