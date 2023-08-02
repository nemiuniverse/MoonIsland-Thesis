using System.Collections;
using UnityEngine;

public class ShowCard : MonoBehaviour
{
    public GameObject evidence;
    public GameObject image;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            // if left button pressed...
        {
            var clickpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var click2D = new Vector2(clickpos.x, clickpos.y);

            var hit = Physics2D.Raycast(click2D, Vector2.zero);
            if (hit.collider != null)
                if (hit.collider.gameObject.name == "Triangle")
                    Card(image);
        }
    }

    public void Card(GameObject image)
    {
        StartCoroutine(Show(image));
    }

    private IEnumerator Show(GameObject image)
    {
        image.SetActive(true);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                image.SetActive(false);
                yield break;
            }

            yield return null;
        }
    }
}