﻿using POP_SF39_2016.model;
using POP_SF39_2016_GUI.gui;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace POP_SF39_2016_GUI.DAO
{
    class TipNamestajaDAO
    {
        public enum SortBy
        {
            Naziv_Opadajuce,
            Naziv_Rastuce,
            Nesortirano
        }
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            try
            {
                var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();


                    cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0";
                    da.SelectCommand = cmd;
                    da.Fill(ds, "TipNamestaja"); //izvrsavanje upita

                    foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                    {
                        var tn = new TipNamestaja();
                        tn.Id = (int)row["Id"];
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamestaja.Add(tn);
                    }
                }
                return tipoviNamestaja;
            }
            catch (TypeInitializationException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri inicijalizaciji tipova namestaja. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch (SqlException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Isteklo je vreme za povezivanje sa bazom. " + ex.Message + "\nPokusajte ponovo pokrenuti program za koji trenutak.", "Upozorenje", MessageBoxButton.OK);
                Environment.Exit(0);
                return null;
            }
            catch
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri citanju iz baze. ", "Upozorenje", MessageBoxButton.OK);
                return null;
            }
        }
        public static TipNamestaja GetById(int Id)
        {
            try
            {
                var tipNamestaja = new TipNamestaja();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("Id", Id);
                    da.SelectCommand = cmd;
                    da.Fill(ds, "TipNamestaja"); //izvrsavanje upita

                    foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                    {
                        tipNamestaja.Id = (int)row["Id"];
                        tipNamestaja.Naziv = row["Naziv"].ToString();
                        tipNamestaja.Obrisan = bool.Parse(row["Obrisan"].ToString());
                    }

                }
                return tipNamestaja;
            }
            catch (TypeInitializationException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri inicijalizaciji tipova namestaja. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch (SqlException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Isteklo je vreme za povezivanje sa bazom. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri citanju iz baze. ", "Upozorenje", MessageBoxButton.OK);
                return null;
            }
        }
        public static TipNamestaja Create(TipNamestaja tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();


                    cmd.CommandText = "INSERT INTO TipNamestaja(Naziv,Obrisan) VALUES (@Naziv,@Obrisan)";
                    cmd.CommandText += "Select SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                    cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                    tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava upit
                }
                Projekat.Instance.TipoviNamestaja.Add(tn);
                return tn;
            }
            catch (TypeInitializationException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri inicijalizaciji tipova namestaja. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch (SqlException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Isteklo je vreme za povezivanje sa bazom. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri citanju iz baze. ", "Upozorenje", MessageBoxButton.OK);
                return null;
            }
        }
        public static void Update(TipNamestaja tn)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    DataSet ds = new DataSet();


                    cmd.CommandText = "UPDATE TipNamestaja SET Naziv=@Naziv,Obrisan=@Obrisan WHERE Id = @Id";
                    cmd.CommandText += " SELECT SCOPE_IDENTITY();";

                    cmd.Parameters.AddWithValue("Id", tn.Id);
                    cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                    cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                    cmd.ExecuteNonQuery();
                }
                foreach (var tipNamestaja in Projekat.Instance.TipoviNamestaja)
                {
                    if (tipNamestaja.Id == tn.Id)
                    {
                        tipNamestaja.Naziv = tn.Naziv;
                        tipNamestaja.Obrisan = tn.Obrisan;
                    }
                }
            }
            catch (TypeInitializationException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri inicijalizaciji tipova namestaja. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return ;
            }
            catch (SqlException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Isteklo je vreme za povezivanje sa bazom. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return ;
            }
            catch
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri citanju iz baze. ", "Upozorenje", MessageBoxButton.OK);
                return ;
            }
        }
        public static void Delete(TipNamestaja tn)
        {
            if (tn != null)
            {
                tn.Obrisan = true;
                Update(tn);
            }
        }
        public static ObservableCollection<TipNamestaja> SearchAndOrSort(GlavniWindow.DoSearch doSearch, string parametar, SortBy sortBy)
        {
            try
            {
                var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();

                    switch (doSearch)
                    {
                        case GlavniWindow.DoSearch.Other:
                            cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0 AND Naziv like @parametar";
                            cmd.Parameters.AddWithValue("parametar", "%" + parametar + "%");
                            break;
                        case GlavniWindow.DoSearch.No:
                            cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan=0";
                            break;
                    }

                    switch (sortBy)
                    {
                        case SortBy.Naziv_Opadajuce:
                            cmd.CommandText += " ORDER BY Naziv DESC";
                            break;
                        case SortBy.Naziv_Rastuce:
                            cmd.CommandText += " ORDER BY Naziv ASC";
                            break;
                    }
                    da.SelectCommand = cmd;
                    da.Fill(ds, "TipNamestaja"); //izvrsavanje upita

                    foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                    {
                        var tn = new TipNamestaja();
                        tn.Id = (int)row["Id"];
                        tn.Naziv = row["Naziv"].ToString();
                        tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                        tipoviNamestaja.Add(tn);
                    }
                }
                return tipoviNamestaja;
            }
            catch (TypeInitializationException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri inicijalizaciji tipova namestaja. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch (SqlException ex)
            {
                MessageBoxResult poruka = MessageBox.Show("Isteklo je vreme za povezivanje sa bazom. " + ex.Message, "Upozorenje", MessageBoxButton.OK);
                return null;
            }
            catch
            {
                MessageBoxResult poruka = MessageBox.Show("Doslo je do greske pri citanju iz baze. ", "Upozorenje", MessageBoxButton.OK);
                return null;
            }
        }
    }
}
