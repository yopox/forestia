using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryManager : MonoBehaviour {
    private static GlossaryManager _instance;
    
    public static GlossaryManager Instance {
        get {
            if (_instance == null) _instance = FindObjectOfType<GlossaryManager>();
            return _instance;
        }
    }

    public GameObject glossary;
    public Text category;
    public Text description;
    public Text page;
    private int _pageNb;

    private readonly string[] _categories = new string[] {
        "Amazon Rainforest",
        "Climate Change"
    };

    private readonly string[] _descriptions = new string[] {
        "The Amazon is burning. Around 73,000 km2 of land was burnt in the Amazon rainforest of Brazil in 2019.\n\nAnd they continue into 2020. Soaring deforestation is one of the main causes of these fires. We must fight the causes and protect this precious place. - WWF",
        "The Amazon is at the heart of global climate concerns.\n\nNot only does the destruction of rainforests add to carbon dioxide in the atmosphere, it creates a 'positive feedback loop', where increased deforestation causes a rise in temperatures which in turn can bring about a drying of tropical forests and increase the risk of forest fires. - WWF"
    };
    
    private static readonly int Open = Animator.StringToHash("open");
    private static readonly int Close = Animator.StringToHash("close");

    public void OpenGlossary() {
        glossary.SetActive(true);
        glossary.GetComponent<Animator>().SetBool(Close, false);
        glossary.GetComponent<Animator>().SetBool(Open, true);
    }

    public void CloseGlossary() {
        glossary.GetComponent<Animator>().SetBool(Open, false);
        glossary.GetComponent<Animator>().SetBool(Close, true);
    }

    public void NextPage() {
        Debug.Log($"pageNb : {_pageNb} ; len {_categories.Length}");
        _pageNb = (_pageNb + 1) % _categories.Length;
        UpdateGlossary();
    }

    public void PreviousPage() {
        _pageNb = (_pageNb + _categories.Length - 1) % _categories.Length;
        UpdateGlossary();
    }

    public void UpdateGlossary() {
        category.text = _categories[_pageNb];
        description.text = _descriptions[_pageNb];
        page.text = $"PAGE {_pageNb + 1} / {_categories.Length}";
    }
}