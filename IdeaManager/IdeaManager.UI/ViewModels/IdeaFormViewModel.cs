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
        private readonly IIdeaService _ideaService;

        [ObservableProperty]
        private ObservableCollection<Idea> ideas = new ObservableCollection<Idea>();

        public IdeaFormViewModel(IIdeaService ideaService)
        {
            _ideaService = ideaService;
            LoadAsync();
        }

        public IdeaFormViewModel() { }

        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private DateTime createdAt = DateTime.UtcNow;

        [ObservableProperty]
        private IdeaStatus status;

        [ObservableProperty]
        private int vote;

        [ObservableProperty]
        private string errorMessage;

        [ObservableProperty]
        private string required;

        [RelayCommand]
        private void ValidateTitle(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                required = "Title is required.";
            }
            else
            {
                required = string.Empty;
            }
        }

        [RelayCommand]
        private async Task SubmitAsync()
        {
            try
            {
                ValidateTitle(title);
                if (!string.IsNullOrEmpty(required))
                {
                    errorMessage = required;
                    return;
                }

                var idea = new Idea
                {
                    Title = title,
                    Description = description,
                    CreatedAt = createdAt,
                    Status = status,
                    VotesCount = vote
                };

                await _ideaService.SubmitIdeaAsync(idea);
                errorMessage = string.Empty;
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
        }

        private async Task LoadAsync()
        {
            try
            {
                var Fetchideas = await _ideaService.GetAllIdeasAsync();
                ideas.Clear();

                foreach (var idea in Fetchideas)
                {
                    ideas.Add(idea);
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }
        }

      
    }
}