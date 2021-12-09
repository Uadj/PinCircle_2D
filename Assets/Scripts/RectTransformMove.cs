using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class RectTransformMove : MonoBehaviour
{
    private class EndMoveEvent : UnityEvent { };
    private EndMoveEvent onEndMoveEvent;
    // Start is called before the first frame update
    [SerializeField]
    private float moveTime = 1.0f;
    private RectTransform rectTransform;
    private bool isMoved = false;
    private void Awake()
    {
        onEndMoveEvent = new EndMoveEvent();
        rectTransform = GetComponent<RectTransform>();
    }
    public void MoveTo(UnityAction action, Vector3 position)
    {
        if (!isMoved)
        {
            onEndMoveEvent.AddListener(action);
            StartCoroutine(OnMove(action, position));
        }
    }
    private IEnumerator OnMove(UnityAction action, Vector3 end)
    {
        float current = 0;
        float percent = 0;
        Vector3 start = rectTransform.anchoredPosition;
        isMoved = true;
        while (percent < 1)
        {
            current += Time.deltaTime;
            percent = current / moveTime;

            rectTransform.anchoredPosition = Vector3.Lerp(start, end, percent);

            yield return null;
        }
        isMoved = false;
        onEndMoveEvent.Invoke();
        onEndMoveEvent.RemoveListener(action);
    }

}
