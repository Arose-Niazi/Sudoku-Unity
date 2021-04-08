using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    public GameObject MainPanel;
    private Button[,] _buttons = new Button[9,9];
    private Text[,] _values = new Text[9, 9];
    
    public Color normalColor;
    public Color highLightButtons;


    private KeyCode[] _keys =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6, KeyCode.Alpha7,
        KeyCode.Alpha8, KeyCode.Alpha9
    };
    
    void Start()
    {
        LoadButtons();
        
        /*Debug.Log("Found all objects!");
        Debug.Log("Selecting First Line.");
        for (int i = 0; i < 9; i++)
        {
            var colors = _buttons[0, i].colors;
            colors.normalColor = highLightButtons;
            _buttons[0,i].colors = colors;
        }
        
        Debug.Log("Disabling Last Box.");
        for (int i = 6; i < 9; i++)
        {
            for (int x = 6; x < 9; x++)
                _buttons[i,x].enabled = false;
        }*/

        FixButtons();
        Sudoku sudoku = new Sudoku(10);
        sudoku.FillValues();
        for (int i = 0; i < 9; i++)
        {
            for (int x = 0; x < 9; x++)
            {
                var value = sudoku.GETValue(i, x);
                if (value == 0)
                {
                    _values[i, x].text = "-"; 
                }
                else
                {
                    _values[i, x].text = $"{sudoku.GETValue(i, x)}";
                    _buttons[i, x].enabled = false;
                }
            }
        }
        
                
        
    }

    private void LoadButtons()
    {
        for (int i = 0; i<9; i++)
        {
            for (int x = 0; x < 9; x++)
            {
                if (i == 0)
                {
                    string toFind = $"0,{x}";
                    _buttons[i,x] = MainPanel.transform.Find(toFind).GetComponent<Button>();
                }
                else
                {
                    string toFind = $"0,{x} ({i})";
                    _buttons[i,x] = GameObject.Find(toFind).GetComponent<Button>();
                }
                _values[i, x] = _buttons[i, x].transform.Find("Text").gameObject.GetComponent<Text>();
            }
        }
    }
    
    private void FixButtons()
    {
        Vector2 btnSize = new Vector2(95, 80);
        foreach (var btn in _buttons)
        {
            btn.GetComponent<RectTransform>().sizeDelta  = btnSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Paused.Displaying || DialogScript.Displaying) return;
        foreach (KeyCode key in _keys)
        {
            if (Input.GetKeyDown(key))
            {
                
            }
        }
    }
}
