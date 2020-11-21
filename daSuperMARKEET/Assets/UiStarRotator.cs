using UnityEngine;


public class UiStarRotator : MonoBehaviour
{
    
    [SerializeField] private float speed = 1;
    
    // Start is called before the first frame update
    

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, speed);
    }
}
