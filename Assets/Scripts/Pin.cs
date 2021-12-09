using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private GameObject square;
    [SerializeField]
    private float moveTime = 0.2f;
    private StageController stageController;
    public void Setup(StageController stageController)
    {
        this.stageController = stageController;
    }
    public void SetInStuckToTarget()
    {
        StopCoroutine("MoveTo");
        square.SetActive(true);
    }
    public void MoveOneStep(float moveDsitance)
    {
        StartCoroutine("MoveTo", moveDsitance);
    }
    private IEnumerator MoveTo(float moveDistance)
    {
        Vector3 start = transform.position;
        Vector3 end = transform.position + Vector3.up * moveDistance;

        float current = 0;
        float percent = 0;

        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;
            transform.position = Vector3.Lerp(start, end, percent);
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Pin"))
        {
            stageController.GameOver();
        }
    }
}
