using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour
{
    [SerializeField] GameObject hammer;
    public GameObject p1;
    [SerializeField] TextMeshProUGUI textP1;

    public GameObject p2;
    [SerializeField] TextMeshProUGUI textP2;

    private void Update()
    {
        if (p1 != null)
        {
            float distance = Mathf.RoundToInt(hammer.transform.position.y - p1.transform.position.y);
            //Vector3.Distance(p1.transform.position, hammer.transform.position);

            textP1.text = distance.ToString() + "m";
        }
        if (p2 != null)
        {
            float distance = Mathf.RoundToInt(hammer.transform.position.y - p2.transform.position.y);
            //Vector3.Distance(p2.transform.position, hammer.transform.position);

            textP2.text = distance.ToString() + "m";
        }
    }

    public void SetP1(GameObject player)
    {
        p1 = player;
    }
    public void SetP2(GameObject player)
    {
        p2 = player;
    }
}
