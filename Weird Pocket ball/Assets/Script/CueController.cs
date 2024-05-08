using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CueController : MonoBehaviour, IEndDragHandler
{

    public Slider forceSlider;
    public GameObject ball;
    public GameObject cue;
    Rigidbody cueRb;
    private void Start()
    {
        cueRb = cue.GetComponent<Rigidbody>();

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag ended");
        float force = forceSlider.value * 50;
        forceSlider.value = 0;

        ball.GetComponent<Rigidbody>().AddForce(cue.transform.forward * force, ForceMode.Impulse);

        cueRb.AddForce(transform.forward * force, ForceMode.Impulse);
        StartCoroutine(CheckVelocity());
    }
    IEnumerator CheckVelocity()
    {
        // �ӵ��� threshold ���Ϸ� ������ ������ �ݺ� �˻�
        while (cueRb.velocity.magnitude > 0.1)
        {
            yield return new WaitForSeconds(0.1f); // 0.1�ʸ��� üũ
        }

        // ���� ���� �� cue ��Ȱ��ȭ
        cue.SetActive(false);
    }
}
