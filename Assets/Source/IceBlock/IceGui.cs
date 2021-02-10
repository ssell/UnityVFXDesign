using UnityEngine;
using UnityEngine.UI;

public class IceGui : MonoBehaviour
{
    public Slider DensitySlider;
    public Slider SmoothnessSlider;
    public Slider RefractionSlider;
    public Slider FresnelSlider;
    public Slider NormalSlider;

    public MeshRenderer IceSphere;
    public MeshRenderer IceBlock;
    public MoveBackAndForth MovingBlock;

    public Text PauseBlockText;
    private bool BlockPaused;

    void Start()
    {
        
    }

    void Update()
    {
        SetFloat("Vector1_e1937abe3e7a41d6b377f1af91c54151", DensitySlider.value);
        SetFloat("Vector1_0311e63620014763bba40e8faf13490e", SmoothnessSlider.value);
        SetFloat("Vector1_94996075d35c42d8ae184bb174465c53", RefractionSlider.value);
        SetFloat("Vector1_f3493c9e446d487497a6865bdb8ec16f", FresnelSlider.value);
        SetFloat("Vector1_23ce35fcd3124984972a582e7fab116b", NormalSlider.value);
    }

    private void SetFloat(string property, float value)
    {
        IceSphere.material.SetFloat(property, value);
        IceBlock.material.SetFloat(property, value);
    }

    public void OnMovingButtonClick()
    {
        if (BlockPaused)
        {
            PauseBlockText.text = "Pause Cube";
            MovingBlock.Paused = false;
        }
        else
        {
            PauseBlockText.text = "Resume Cube";
            MovingBlock.Paused = true;
        }

        BlockPaused = !BlockPaused;
    }
}
