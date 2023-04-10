
using IronOcr;
using Patagames.Ocr;
using Patagames.Ocr.Enums;
using System.Drawing;
using System.Threading.Tasks;
using Tesseract;

namespace OCRImp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        
    }

    public async void OCR()
    {
        var Ocr = new IronTesseract();
        string path = await SelectImage();
        using (var Input = new OcrInput(path))
        {
            // Input.Deskew();  // use if image not straight
            // Input.DeNoise(); // use if image contains digital noise
            var Result = Ocr.Read(Input);
            imageReturn.Text = Result.Text.Replace("\r", "").Replace("\n", " ");
        }
    }

    private void OCR_Click_Clicked(object sender, EventArgs e)
    {
        OCR();
    }
    public async Task<string> SelectImage()
    {
        var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
        {
            Title = "Select a photo"
        });

        if (result != null)
        {
            return result.FullPath;
        }
        return null;
    }
}

