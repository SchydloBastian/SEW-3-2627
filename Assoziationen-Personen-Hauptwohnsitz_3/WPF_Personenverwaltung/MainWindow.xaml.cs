using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Assoziationen_Personen_Hauptwohnsitz;

namespace Assoziationen_Personen_Hauptwohnsitz
{
    public partial class MainWindow : Window
    {
        private List<Adresse> adressenListe = new List<Adresse>();
        private List<Person> personenListe = new List<Person>();

        public MainWindow()
        {
            InitializeComponent();
            DatenLaden();
        }

        private void DatenLaden()
        {
            Adresse adr1 = new Adresse("Musterstraße", "12a", 1212, "Musterstadt", "Wien");
            Adresse adr2 = new Adresse("Hauptplatz", "5", 4020, "Linz", "Oberösterreich");
            Adresse adr3 = new Adresse("Herrengasse", "10", 8010, "Graz", "Steiermark");

            adressenListe.Add(adr1);
            adressenListe.Add(adr2);
            adressenListe.Add(adr3);

            personenListe.Add(new Person(1, "Max", "Mustermann", "max.mustermann@example.com", new DateTime(1990, 1, 1), adr1));
            personenListe.Add(new Person(2, "Anna", "Musterfrau", "anna.musterfrau@example.com", new DateTime(1995, 5, 12), adr1));
            personenListe.Add(new Person(3, "Lukas", "Huber", "lukas.huber@example.com", new DateTime(2002, 8, 23), adr2));

            lvAdressen.ItemsSource = adressenListe;
        }

        private void lvAdressen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvAdressen.SelectedItem is Adresse ausgewaehlteAdresse)
            {
                lvPersonen.ItemsSource = personenListe
                    .Where(p => p.Hauptwohnsitz == ausgewaehlteAdresse)
                    .ToList();
            }
            else
            {
                lvPersonen.ItemsSource = null;
            }
        }
    }
}