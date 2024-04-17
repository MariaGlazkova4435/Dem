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
using System.Windows.Shapes;

namespace Dem
{
    /// <summary>
    /// Логика взаимодействия для ZayavkiWindow.xaml
    /// </summary>
    public partial class ZayavkiWindow : Window
    {
        public ZayavkiWindow()
        {
            InitializeComponent();
            btnChange.IsEnabled = false;
            DtZayavki.ItemsSource = zayavkiEntities.GetContext().Zayavki.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CbStatus.SelectedItem != null)
            {
                zayavki.status1 = zayavkiEntities.GetContext().status.Where(x => x.id == st.id).FirstOrDefault();
                zayavkiEntities.GetContext().SaveChanges();
                DtZayavki.Items.Refresh();
            }
            else
                MessageBox.Show("Выберите статус!");
        }
        Zayavki zayavki = new Zayavki();
        private void DtZayavki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DtZayavki.SelectedItems.Count == 0 || DtZayavki.SelectedItems.Count > 1)
            {
                btnChange.IsEnabled = false;
                CbStatus.IsEnabled = false;
            }
            else
            {
                btnChange.IsEnabled = true;
                CbStatus.IsEnabled = true;
                zayavki = DtZayavki.SelectedItem as Zayavki;
                if (zayavki.status == 1)
                    CbStatus.ItemsSource = zayavkiEntities.GetContext().status.Where(x => x.id == 2 || x.id == 4).ToList();
            }
            
        }
        status st = new status();
        private void CbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            st = CbStatus.SelectedItem as status;
        }
    }
}
