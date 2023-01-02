using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    private GridPosition gridPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public GridPosition GetGridPosition()
    {
        return gridPosition;
    }
    
    public Vector3 GetWorldPosition()
    {
        return transform.position;
    }
}
