using Practice1Buha.ViewModels;
using System.Windows.Controls;

namespace Practice1Buha.Views
{
    /// <summary>
    /// Логика взаимодействия для DateInputView.xaml
    /// </summary>
    public partial class DateInputView : UserControl
    {

        private DateInputViewModel _dateInputViewModel;
        public DateInputView()
        {
            InitializeComponent();
            DataContext = _dateInputViewModel = new DateInputViewModel();
        }
    }
}
