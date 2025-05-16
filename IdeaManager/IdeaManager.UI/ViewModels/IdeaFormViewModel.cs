using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Enums;
using IdeaManager.Core.Interfaces;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows;

namespace IdeaManager.UI.ViewModels
{
    public partial class IdeaFormViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private string successMessage;

        private readonly IIdeaService _ideaService;

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(Title))
            {
                ErrorMessage = "Le titre est obligatoire.";
                return;
            }

            var idea = new Idea { Title = Title, Description = Description };

            try
            {
                await _ideaService.SubmitIdeaAsync(idea);

                Title = string.Empty;
                Description = string.Empty;

                SuccessMessage = "Idée ajoutée avec succès !";
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Erreur : {ex.Message}";
            }
        }
    }
 }