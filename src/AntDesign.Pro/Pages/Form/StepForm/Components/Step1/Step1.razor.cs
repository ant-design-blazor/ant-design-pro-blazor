using AntDesign.Pro.Models;
using Microsoft.AspNetCore.Components;

namespace AntDesign.Pro.Pages.Form
{
    public partial class Step1
    {
        private readonly StepFormModel _model = new StepFormModel();

        [CascadingParameter] public StepForm StepForm { get; set; }

        public void OnValidateForm()
        {
            StepForm.Next();
        }
    }
}