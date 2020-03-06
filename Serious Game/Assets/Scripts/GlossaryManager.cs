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

    private readonly string[] _categories = {
        "Amazon Rainforest",
        "Challenges",
        "Climate Change",
        "Food & Farming",
        "Bio piracy",
        "Eat sustainably",
        "Reduce plastic"
    };

    private readonly string[] _descriptions = {
        "The Amazon is burning. Around 73,000 km2 of land was burnt in the Amazon rainforest of Brazil in 2019.\n\nAnd they continue into 2020. Soaring deforestation is one of the main causes of these fires. We must fight the causes and protect this precious place.\n- WWF",
        "Huge areas of rainforest are destroyed by clearing for farming, timber, roads, hydropower dams, mining, house-building or other development.\n\nThe problem is it’s often seen as more economically worthwhile to cut the forest down than to keep it standing.\n- WWF",
        "The Amazon is at the heart of global climate concerns.\n\nNot only does the destruction of rainforests add to carbon dioxide in the atmosphere, it creates a 'positive feedback loop', where increased deforestation causes a rise in temperatures which in turn can bring about a drying of tropical forests and increase the risk of forest fires. - WWF",
        "Rising global demand for food, especially meat, has led to Brazil becoming the world’s biggest beef exporter, and the second-biggest exporter of soy beans, mainly used for livestock feed.\n\nMore and more forests are being removed to make way for grazing land or soy plantations.\n- WWF",
        "People take plants and animals from the Amazon to sell abroad as pets, food, and medicine. Trade in these animals leads to declines in wild populations, affecting animals already threatened by habitat destruction and pollution.\n\nAccording to Wikipedia, in 2008, it was estimated that the illegal trade in wildlife is worth at least US$5 billion, and may potentially total in excess of US$20 billion annually.\n- rainforestcruises.com",
        "The food we eat causes half of all global deforestation. This is a major driver of climate change and loss of wildlife – with the UK supply chain linked to the extinction of 33 species already.\n\nIt’s time to rethink the way we eat to ensure there's enough space for nature and people to thrive.\n- WWF",
        "Around 8 million tonnes of plastic enter our oceans every year – and by 2050 there could be more plastic in our seas than fish.\n\nOur oceans are a vital defence against climate change as they soak up carbon, but they need to be healthy for that to work.\n- WWF"
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
        page.text = $"PAGE {_pageNb + 1}/{_categories.Length}";
    }
}