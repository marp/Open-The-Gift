using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Engine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI TekstSzanse;
    [SerializeField] TextMeshProUGUI LevelText;
    [SerializeField] TextMeshProUGUI HealthText;

    [SerializeField] GameObject blockSparklesVFX;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    void Start()
    {
        LevelText.text = SceneManager.GetActiveScene().name.ToString();
       // Debug.Log();
        this.gameObject.transform.GetChild(Random.Range(0, transform.childCount-1)).gameObject.GetComponent<Skrypt>().special = true;
        foreach (Transform child in transform)
        {
            //Destroy(child.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TekstSzanse.text = "Chances: " + (1f/transform.childCount*100).ToString("F2")+"%";
        HealthText.text = "Lifes: " + (FindObjectOfType<GameSession>().lifes).ToString();

        if (FindObjectOfType<GameSession>().lifes <= 0) {
            SceneManager.LoadScene("Game Over");
        }

        MouseSupport();
    }

    private void MouseSupport()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

        if (Input.GetMouseButtonDown(0))
        {
            if (hit.collider != null)
            {

                //Debug.Log(hit.collider.gameObject.name);
                GameObject wykryty = hit.collider.gameObject;
                TriggerSparklesVFX();
                AudioSource audio = wykryty.GetComponent<AudioSource>();
                if (wykryty.GetComponent<Skrypt>().special == true)
                {
                    /*                    foreach (Transform child in transform)
                                        {
                                            Destroy(child.gameObject);
                                        }*/
                    if (SceneManager.GetActiveScene().name == "Level 3")
                    {
                        SceneManager.LoadScene("Win");
                    }
                    else
                    {
                        FindObjectOfType<GameSession>().lifes += 3;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                       
                    }

                }
                else
                {
                    FindObjectOfType<GameSession>().lifes--;
                }
                audio.Play(0);
                Destroy(hit.collider.gameObject, 0.1f);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
            }
        }

        if (hit.collider != null)
        {
            OnMouseEnter();
        }
        else {
            OnMouseExit();
        }
    }
    private void TriggerSparklesVFX()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 mousePos2D = new Vector3(mousePos.x, mousePos.y, -10f);


        GameObject sparkles = Instantiate(blockSparklesVFX, mousePos2D, transform.rotation);
        Destroy(sparkles, 1f);
    }
    public void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    public void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }



}
