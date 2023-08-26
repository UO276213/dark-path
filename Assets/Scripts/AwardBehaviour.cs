using UnityEngine;

public class AwardBehaviour : MonoBehaviour
{
    public float height = 0.5f;
    public float frequency = 0.015f;

    Vector3 startPosition; //base position

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(startPosition.x,
            startPosition.y + height * Mathf.Sin(Time.frameCount * frequency), startPosition.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            
            GetComponentInParent<GameLogic>().SetState(GameLogic.GameState.Completed);
        }

    }
}