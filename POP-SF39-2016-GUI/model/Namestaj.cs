﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF39_2016.model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private double cena;
        private int brKomada;
        private int? tipNamestajaId;
        private bool obrisan;
        private TipNamestaja tipNamestaja;
        public event PropertyChangedEventHandler PropertyChanged;

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }
        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if (tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");
            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        public int BrKomada
        {
            get { return brKomada; }
            set
            {
                brKomada = value;
                OnPropertyChanged("BrKomada");
            }
        }

        public int? TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("TipNamestajaID");
            }
        }

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }
        
        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                Cena = cena,
                Sifra = sifra,
                Obrisan = obrisan,
                TipNamestaja = tipNamestaja,
                TipNamestajaId = tipNamestajaId,
                BrKomada = brKomada
            };
        }

        public override string ToString()
        {
            return $"{Naziv},{Cena},{TipNamestajaId}";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public static Namestaj GetById(int? idProsledjen)
        {
            foreach (Namestaj namestaj in Projekat.Instance.Namestaji)
            {
                if (namestaj.id == idProsledjen)
                    return namestaj;
            }
            return null;
        }

        /***
                OLD
                public int Id { get; set; }

                public string Naziv { get; set; }

                public string Sifra { get; set; }

                public double Cena { get; set; }

                public int BrKomada { get; set; }

                public int? AkcijaId { get; set; }

                public int? TipNamestajaId { get; set; }

                public bool Obrisan { get; set; }
                  ***/
        #region CRUD
        public static ObservableCollection<Namestaj> GetAll()
        {
            var listaNamestaja = new ObservableCollection<Namestaj>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();


                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan=0";
                da.SelectCommand = cmd;
                da.Fill(ds, "Namestaj"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var tn = new Namestaj();
                    tn.Id = (int)row["Id"];
                    tn.TipNamestajaId = (int?)row["TipNamestajaId"];
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Sifra = row["Sifra"].ToString();
                    tn.Cena = double.Parse(row["Cena"].ToString());
                    tn.BrKomada = (int)row["Kolicina"];
                    
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    listaNamestaja.Add(tn);
                }
            }
            return listaNamestaja;
        }
        /***
        public static Namestaj Create(Namestaj tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();


                cmd.CommandText = "INSERT INTO Namestaj(Naziv,Sifra,Obrisan) VALUES (@Naziv,@Obrisan)";
                cmd.CommandText += "Select SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //ExecuteScalar izvrsava upit
            }
            Projekat.Instance.TipoviNamestaja.Add(tn);
            return tn;
        }
        public static void Update(TipNamestaja tn)
        {
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                DataSet ds = new DataSet();


                cmd.CommandText = "UPDATE TipNamestaja SET (Naziv=@Naziv,Obrisan=@Obrisan) WHERE Id = %Id)";
                cmd.CommandText += "Select SCOPE_IDENTITY();";

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

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }
        ***/
        #endregion
    }
}
