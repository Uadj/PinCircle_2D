using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotateSpeed = 50;
    [SerializeField]
    private float maxRoateSpeed = 500;
    [SerializeField]
    private StageController stageController;
    [SerializeField]
    private Vector3 rotateAngle = Vector3.forward;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if (!stageController.IsGameStart) return;
        transform.Rotate(rotateAngle * rotateSpeed * Time.deltaTime);
    }
    public void RotateFast()
    {
        rotateSpeed = maxRoateSpeed;
    }
    public void Stop()
    {
        rotateSpeed = 0;
    }
}
