﻿using POP_SF39_2016.model;
using POP_SF39_2016.util;
using POP_SF39_2016_GUI.gui;
using POP_SF39_2016_GUI.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace POP_SF39_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Korisnik logovaniKorisnik { get; set; } = new Korisnik();
        public MainWindow()
        {
            InitializeComponent();
            /***
            List<JedinicaProdaje> lista = Projekat.Instance.JedinicaProdaje.ToList();
            List<int> listaId = lista.Select(predmet => predmet.Id).ToList();
            ObservableCollection<ProdajaNamestaja> lista2 = new ObservableCollection<ProdajaNamestaja>();
            var p1 = new ProdajaNamestaja()
            {
                Id = 1,
                ListaJedinicaProdajeId = listaId,
                Kupac = "pero",
                BrRacuna = "234432",
                DatumProdaje = DateTime.Today,
                UkupnaCena = 515151,
            };
            lista2.Add(p1);
            GenericSerializer.Serialize<ProdajaNamestaja>("prodajenamestaja.xml", lista2);
            ***/
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni?", "Izlazak", MessageBoxButton.YesNo);
            if (poruka == MessageBoxResult.Yes)
            {
                Environment.Exit(0);
            };
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //ObservableCollection<Korisnik> listaKorisnika = Projekat.Instance.Korisnik;
            if (tbKorisnickoIme.Text.Equals("") || passboxSifra.Password.Equals(""))
            {

                MessageBoxResult poruka = MessageBox.Show("Polja ne smeju biti prazna. ", "Upozorenje", MessageBoxButton.OK);
                return;
            }
            foreach(Korisnik korisnik in Projekat.Instance.Korisnik)
            {
                if(korisnik.KorisnickoIme.Equals(tbKorisnickoIme.Text) || korisnik.Lozinka.Equals(passboxSifra.Password))
                {
                    this.Hide();
                    logovaniKorisnik = korisnik;
                    GlavniWindow noviGlavniWindow = new GlavniWindow(logovaniKorisnik);
                    noviGlavniWindow.Show();
                    break;
                }
            }
        }
    }
}
