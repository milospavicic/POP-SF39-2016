﻿using POP_SF39_2016.model;
using POP_SF39_2016_GUI.gui;
using System;
using System.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace POP_SF39_2016_GUI
{
    public partial class MainWindow : MetroWindow
    {
        public Korisnik logovaniKorisnik { get; set; } = new Korisnik();
        public MainWindow()
        {
            InitializeComponent();
            tbKorisnickoIme.Focus();
            btnPrijava.IsDefault = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da zelite da izadjete iz programa?", "Izlazak", MessageBoxButton.YesNo);
            if (poruka == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (tbKorisnickoIme.Text.Equals("") || passboxSifra.Password.Equals(""))
            {
                ErrorMessagePrint("Polja ne smeju biti prazna. ", "Upozorenje");
                return;
            }
            foreach(Korisnik korisnik in Projekat.Instance.Korisnici)
            {
                if(korisnik.KorisnickoIme.Equals(tbKorisnickoIme.Text) && korisnik.Lozinka.Equals(passboxSifra.Password))
                {
                    this.Hide();
                    logovaniKorisnik = korisnik;
                    GlavniWindow noviGlavniWindow = new GlavniWindow(logovaniKorisnik);
                    noviGlavniWindow.Show();
                    break;
                }
            }
            ErrorMessagePrint("Korisnik nije pronadjen. ", "Upozorenje");
            return;
        }
        public async void ErrorMessagePrint(string message,string title)
        {
            await this.ShowMessageAsync(title, message);
        }
    }
}
