﻿using System;
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

namespace POP_SF39_2016_GUI.gui
{

    public partial class PopustWindow : Window
    {
        private int popustNamestaja;

        public int PopustNamestaja
        {
            get { return popustNamestaja; }
            set { popustNamestaja = value; }
        }

        public PopustWindow()
        {
            InitializeComponent();
            tbUnos.DataContext = PopustNamestaja;
            tbUnos.Focus();
        }
        private void Izadji(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        private void UnetiPopust(object sender, RoutedEventArgs e)
        {
            if (ForceValidation() == true)
                return;
            this.DialogResult = true;
            this.Close();   
        }
        private bool ForceValidation()
        {
            BindingExpression be1 = tbUnos.GetBindingExpression(TextBox.TextProperty);
            be1.UpdateSource();

            if (Validation.GetHasError(tbUnos) == true)
            {
                return true;
            }
            return false;
        }
    }
}
