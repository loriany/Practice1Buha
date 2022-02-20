using Practice1Buha.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
