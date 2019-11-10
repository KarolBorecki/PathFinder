using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Expanser : MonoBehaviour
{
    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
     
        transform.localScale = new Vector3(1,1,1);

        var width = sr.sprite.bounds.size.x;
        var height = sr.sprite.bounds.size.y;

        float worldScreenHeight = 5 * 2.0f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;


        transform.localScale = new Vector2(worldScreenWidth / width, worldScreenHeight / height);
    }
}
