using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerCrowd : MonoBehaviour
{
   
    [SerializeField] private int startingCrowdSize = 1;

    [SerializeField] private GameObject crowdPrefab;
    [SerializeField] private List<Transform> spawnPoints = new List<Transform>();
    [SerializeField] public  List<GameObject> _crowd = new List<GameObject>();
    
   
   
    [SerializeField] private TMP_Text Score;

  

    private void Start()
    {
        
       
    }
    private void Update()
    {
        Score.text = (_crowd.Count+1).ToString();
        if (Input.GetKeyDown(KeyCode.A)) {
            AddCrowd(1);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            RemoveCrowd();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            setPosition();
        }
        setPosition();
    }


    public  void setPosition()
    {

        for (int i = 0; i < _crowd.Count; i++) {
            if (_crowd[i] == null) {
                _crowd.Remove(_crowd[i]);
                return;
            }
            _crowd[i].transform.position = Vector3.Lerp(_crowd[i].transform.position , spawnPoints[i].position,0.01f);


        }
    }

    public void RemoveCrowd()
    {
       
        var lastCrowd = _crowd[_crowd.Count - 1];
        _crowd.Remove(lastCrowd);
        Destroy(lastCrowd.gameObject);
        setPosition();
    }

    public void AddCrowd(int i)
    {
        for (int x = 0;x<i;x++ ) {
            var lastCrowdIndex = _crowd.Count - 1;
            var position = spawnPoints[lastCrowdIndex + 1].position;
            var crowd = Instantiate(crowdPrefab, position, Quaternion.identity, transform);
            _crowd.Add(crowd);
            setPosition();
        }
        
    }
}