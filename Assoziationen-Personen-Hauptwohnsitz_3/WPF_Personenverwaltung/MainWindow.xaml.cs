using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PersonenLibrary;

namespace WPF_Personenverwaltung
{
    public partial class MainWindow : Window
    {
        private List<Adresse> alleAdressen = new List<Adresse>();
        private List<Person> allePersonen = new List<Person>();

        private const string AdressenDatei = "Adressen.txt";
        private const string PersonenDatei = "Personen.txt";

        public MainWindow()
        {
            InitializeComponent();
            DatenLaden();
            AdressenAnzeigeAktualisieren();
        }

        private void DatenLaden()
        {
            if (File.Exists(AdressenDatei))
            {
                string[] zeilen = File.ReadAllLines(AdressenDatei);

                foreach (string zeile in zeilen)
                {
                    if (zeile != "")
                    {
                        string[] teile = zeile.Split(';');
                        Adresse adr = new Adresse(
                            int.Parse(teile[0]), teile[1],teile[2],
                            int.Parse(teile[3]),teile[4],teile[5],teile[6]
                        );
                        alleAdressen.Add(adr);
                    }
                }
            }

            if (File.Exists(PersonenDatei))
            {
                string[] zeilen = File.ReadAllLines(PersonenDatei);

                foreach (string zeile in zeilen)
                {
                    if (zeile != "")
                    {
                        string[] teile = zeile.Split(';');
                        int adrId = int.Parse(teile[5]);

                        Adresse wohnsitz = null;
                        foreach (Adresse a in alleAdressen)
                        {
                            if (a.Id == adrId)
                            {
                                wohnsitz = a;
                            }
                        }

                        if (wohnsitz != null)
                        {
                            Person p = new Person(
                                int.Parse(teile[0]),teile[1],teile[2],teile[3],
                                DateTime.Parse(teile[4]),
                                wohnsitz
                            );
                            allePersonen.Add(p);
                        }
                    }
                }
            }
            else
            {
                allePersonen.Add(new Person(1, "Berta", "Beispiel", "berta@beispiel.at", new DateTime(1995, 4, 12), alleAdressen[0]));
            }
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            var adrZeilen = alleAdressen.Select(a =>
                $"{a.Id};{a.Strasse};{a.Hausnummer};{a.PLZ};{a.Ort};{a.Bundesland};{a.Land}").ToList();
            File.WriteAllLines(AdressenDatei, adrZeilen);

            var persZeilen = allePersonen.Select(p =>
                $"{p.ID};{p.Vorname};{p.Nachname};{p.Email};{p.Geburtsdatum:yyyy-MM-dd};{p.Hauptwohnsitz.Id}").ToList();
            File.WriteAllLines(PersonenDatei, persZeilen);
        }

        private void AdressenAnzeigeAktualisieren()
        {
            lvAdressen.ItemsSource = null;
            lvAdressen.ItemsSource = alleAdressen;

            cmbZielAdresse.ItemsSource = null;
            cmbZielAdresse.ItemsSource = alleAdressen;

            if (alleAdressen.Count > 0 && lvAdressen.SelectedItem == null)
            {
                lvAdressen.SelectedIndex = 0;
            }
        }

        private void PersonenAnzeigeAktualisieren()
        {
            if (lvAdressen.SelectedItem is Adresse ausgewaehlteAdresse)
            {
                lvPersonen.ItemsSource = allePersonen
                    .Where(p => p.Hauptwohnsitz == ausgewaehlteAdresse)
                    .ToList();
            }
            else
            {
                lvPersonen.ItemsSource = null;
            }
        }

        private void lvAdressen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonenAnzeigeAktualisieren();
        }

        private void BtnAdresseSpeichern_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(txtPLZ.Text, out int plz))
                {
                    MessageBox.Show("Bitte eine gültige Zahl als PLZ eingeben.");
                    return;
                }

                int neueId = alleAdressen.Count > 0 ? alleAdressen.Max(a => a.Id) + 1 : 1;
                Adresse neueAdresse = new Adresse(neueId, txtStrasse.Text.Trim(), "", plz, txtOrt.Text.Trim());

                alleAdressen.Add(neueAdresse);
                AdressenAnzeigeAktualisieren();
                lvAdressen.SelectedItem = neueAdresse;

                txtStrasse.Clear();
                txtPLZ.Clear();
                txtOrt.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
            }
        }

        private void BtnPersonSpeichern_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvAdressen.SelectedItem is Adresse ausgewaehlteAdresse))
            {
                MessageBox.Show("Bitte zuerst links eine Adresse auswählen!");
                return;
            }

            try
            {
                int neueId = allePersonen.Count > 0 ? allePersonen.Max(p => p.ID) + 1 : 1;
                Person neuePerson = new Person(
                    neueId,
                    txtVorname.Text.Trim(),
                    txtNachname.Text.Trim(),
                    "keine@email.at",
                    new DateTime(2000, 1, 1),
                    ausgewaehlteAdresse
                );

                allePersonen.Add(neuePerson);
                PersonenAnzeigeAktualisieren();

                txtVorname.Clear();
                txtNachname.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler");
            }
        }

        private void BtnWohnsitzWechseln_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvPersonen.SelectedItem is Person ausgewaehltePerson))
            {
                MessageBox.Show("Bitte rechts eine Person auswählen.");
                return;
            }

            if (!(cmbZielAdresse.SelectedItem is Adresse zielAdresse))
            {
                MessageBox.Show("Bitte unten eine Zieladresse auswählen.");
                return;
            }

            ausgewaehltePerson.Hauptwohnsitz = zielAdresse;
            PersonenAnzeigeAktualisieren();
        }
        private void BtnAdresseLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvAdressen.SelectedItem is Adresse ausgewaehlteAdresse))
            {
                MessageBox.Show("Bitte links zuerst eine Adresse auswählen.");
                return;
            }

            allePersonen.RemoveAll(p => p.Hauptwohnsitz == ausgewaehlteAdresse);
            alleAdressen.Remove(ausgewaehlteAdresse);

            AdressenAnzeigeAktualisieren();
            PersonenAnzeigeAktualisieren();
        }

        private void BtnPersonLoeschen_Click(object sender, RoutedEventArgs e)
        {
            if (!(lvPersonen.SelectedItem is Person ausgewaehltePerson))
            {
                MessageBox.Show("Bitte rechts zuerst eine Person auswählen.");
                return;
            }

            allePersonen.Remove(ausgewaehltePerson);
            PersonenAnzeigeAktualisieren();
        }
    }
}