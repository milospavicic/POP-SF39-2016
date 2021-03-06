﻿using POP_SF39_2016.model;
using POP_SF39_2016_GUI.DAO;
using POP_SF39_2016_GUI.model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace POP_SF39_2016_GUI.gui
{
    public partial class AkcijaWindow : MetroWindow
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };
        public ObservableCollection<Namestaj> ListaNamestajaZaDG1 { get; set; } = new ObservableCollection<Namestaj>();
        public ObservableCollection<NaAkciji> ListaNAZaDG2 { get; set; } = new ObservableCollection<NaAkciji>();

        private Akcija akcija;
        private Operacija operacija;
        private int PopustNamestaja { get; set; }

        public AkcijaWindow(Akcija akcija, Operacija operacija)
        {
            InitializeComponent();
            this.akcija = akcija;
            this.operacija = operacija;
            dgNamestaj.AutoGenerateColumns = false;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            PopunjavanjePolja();
        }

        private void PopunjavanjePolja()
        {
            dpPocetniDatum.DataContext = akcija;
            dpKrajnjiDatum.DataContext = akcija;
            tbNaziv.DataContext = akcija;
            tbNaziv.MaxLength = 100;
            ListaNamestajaZaDG1 = NamestajDAO.GetAllNamestajNotOnAction();

            if (operacija == Operacija.IZMENA)
            {
                ListaNAZaDG2 = NaAkcijiDAO.GetAllNAForActionId(akcija.Id);
                dgZaAkciju.IsReadOnly = true;
                dpPocetniDatum.IsHitTestVisible = false;
            }
            dgNamestaj.CanUserSortColumns = false;
            dgNamestaj.CanUserAddRows = false;
            dgNamestaj.CanUserDeleteRows = false;
            dgZaAkciju.CanUserSortColumns = false;
            dgZaAkciju.CanUserAddRows = false;
            dgZaAkciju.CanUserDeleteRows = false;
            dgNamestaj.ItemsSource = ListaNamestajaZaDG1;
            dgZaAkciju.ItemsSource = ListaNAZaDG2;
            if (operacija == Operacija.DODAVANJE)
                this.Title += " - Dodavanje";
            else
                this.Title += " - Izmena";
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            if (ForceValidation() == true)
                return;
            if(dpPocetniDatum.SelectedDate == null || dpKrajnjiDatum.SelectedDate == null)
            {
                ErrorMessagePrint("Datumi moraju biti uneseni.", "Upozorenje");
                return;
            }
            if(ListaNAZaDG2.Count==0)
            {
                ErrorMessagePrint("Akcija mora sadrzati bar jedan namestaj", "Upozorenje");
                return;
            }
            var listaAkcija = Projekat.Instance.Akcija;
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    akcija.Naziv = akcija.Naziv.Trim();
                    var novaAkcija = AkcijaDAO.Create(akcija);
                    foreach (var tempNaZaCreate in ListaNAZaDG2)
                    {
                        tempNaZaCreate.IdAkcije = novaAkcija.Id;
                        NaAkcijiDAO.Create(tempNaZaCreate);
                    }
                    break;
                case Operacija.IZMENA:
                    AkcijaDAO.Update(akcija);
                    var listaNaZaBrisanje = NaAkcijiDAO.GetAllNAForActionId(akcija.Id);
                    foreach (var tempNaZaCreate in ListaNAZaDG2)
                    {
                        bool postoji = false;
                        foreach (var tempN in NaAkcijiDAO.GetAllNAForActionId(akcija.Id))
                        {
                            if (tempNaZaCreate.IdNamestaja == tempN.IdNamestaja)
                            {
                                postoji = true;
                                if (tempNaZaCreate.Popust != tempN.Popust)
                                {
                                    tempN.Popust = tempNaZaCreate.Popust;
                                    NaAkcijiDAO.Update(tempN);
                                }
                                listaNaZaBrisanje.ToList().ForEach(x => { if (x.IdNamestaja == tempNaZaCreate.IdNamestaja) listaNaZaBrisanje.Remove(x); });


                                break;
                            }
                        }
                        if (postoji == false)
                        {
                            tempNaZaCreate.IdAkcije = akcija.Id;
                            NaAkcijiDAO.Create(tempNaZaCreate);
                        }
                    }
                    foreach (var tempNA in listaNaZaBrisanje)
                    {
                        NaAkcijiDAO.Delete(tempNA);
                    }
                    break;
            }

            this.Close();

        }
        private void ZatvoriWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var popustProzor = new PopustWindow();
            popustProzor.ShowDialog();

            if (popustProzor.DialogResult == true)
            {
                var tempNaAkciji = new NaAkciji
                {
                    IdNamestaja = ((Namestaj)dgNamestaj.SelectedItem).Id,
                    Popust = popustProzor.PopustNamestaja,
                };
                ListaNAZaDG2.Add(tempNaAkciji);

                ListaNamestajaZaDG1.Remove((Namestaj)dgNamestaj.SelectedItem);
            }
        }

        private void IzbaciIzAkcije(object sender, RoutedEventArgs e)
        {
            var tempNA = (NaAkciji)dgZaAkciju.SelectedItem;
            ListaNAZaDG2.Remove(tempNA);
            var tempN = NamestajDAO.GetById(tempNA.IdNamestaja);
            if (tempN.Obrisan != true)
                ListaNamestajaZaDG1.Add(tempN);
        }

        private void DatumProvera(object sender, SelectionChangedEventArgs e)
        {
            if (akcija.PocetakAkcije > akcija.KrajAkcije)
            {
                ErrorMessagePrint("Krajnji datum ne moze biti veci od pocetnog. ", "Upozorenje");
                akcija.KrajAkcije = akcija.PocetakAkcije;
                return;
            }
        }
        private bool ForceValidation()
        {
            BindingExpression be = tbNaziv.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
            if (Validation.GetHasError(tbNaziv) == true)
            {
                return true;
            }
            return false;
        }
        private void Indexiranje(object sender, DataGridRowEventArgs e)
        {
            e.Row.Header = (e.Row.GetIndex()).ToString();
        }
        public async void ErrorMessagePrint(string message, string title)
        {
            await this.ShowMessageAsync(title, message);
        }
    }
}
