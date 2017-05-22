using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Ocean.Model;
using Xamarin.Forms;

namespace Ocean.View
{
    public class PersonEditorViewModel : ObservableObject
    {
		Person _person;
        Country _country;
		ObservableCollection<String> _vacationSpots;
        bool _isvisible;

		public ICommand AddOnItemToVacationSpots => new Command(AddOnItemToVacationSpotsExecute);

		public ICommand ClearToVacationSpots => new Command(ClearToVacationSpotsExecute);

        public ICommand LabelCountry => new Command(LabelCountryExecute);

		public IEnumerable<Country> Countries { get; }

		public Person Person
		{
			get { return _person; }
			set
			{
				_person = value;
				//RaisePropertyChanged();
			}
		}

		public Country Country
		{
			get { return _country; }
			set
			{
				_country = value;
				RaisePropertyChanged(nameof(Country));
			}
		}

        public bool IsVisible
        {
            get { return _isvisible; }
            set
            {
                _isvisible = value;
                RaisePropertyChanged(nameof(IsVisible));

            }
        }


		public ICommand RefreshVacationSpots => new Command(RefreshVacationSpotsExecute);

		public IEnumerable<String> Sexes { get; }

		public IEnumerable<String> States { get; }

		public ObservableCollection<String> VacationSpots
		{
			get { return _vacationSpots; }
			set
			{
				_vacationSpots = value;
				RaisePropertyChanged();
			}
		}

		public PersonEditorViewModel()
		{
			var person = new Person();
			person.LastName = "Shifflett";
			person.CountryId = 5;
			person.State = "NJ";
			person.FirstName = "Karl";
			person.NextVacationSpot = "Alaska";
			person.Sex = Sex.Male;
			this.Person = person;



            this.Country = new Country();
            if (this.Country.Id == 0)
            {
                //LabelCountryExecute();
                this.IsVisible = true;
            } else 
                this.IsVisible = false;

            LabelCountryExecute();

			var list = new List<Country>();
			list.Add(new Country { Abbreviation = "BGR", Id = 1, Name = "Bulgaria" });
			list.Add(new Country { Abbreviation = "JP", Id = 2, Name = "Japan" });
			list.Add(new Country { Abbreviation = "ROU", Id = 3, Name = "Romania" });
			list.Add(new Country { Abbreviation = "RUS", Id = 4, Name = "Russian Federation" });
			list.Add(new Country { Abbreviation = "USA", Id = 5, Name = "United States" });
			this.Countries = list;

			this.Sexes = Enum.GetNames(typeof(Sex));
			this.States = new List<String> { "NC", "NJ", "NY" };
			this.VacationSpots = new ObservableCollection<String>(new List<String> { "Alaska", "Montana", "Wyoming" });
		}

		void AddOnItemToVacationSpotsExecute()
		{
			this.VacationSpots.Add("Hawaii");
		}

		void ClearToVacationSpotsExecute()
		{
			this.VacationSpots.Clear();
		}

		void LabelCountryExecute()
		{
			//Label label = this.PersonEditorView.FindByName
			//this.Country = new Country();
			if (this.Country.Id == 0)
			{
				//LabelCountryExecute();
				this.IsVisible = true;
			}
			else
				this.IsVisible = false;
		}

		void RefreshVacationSpotsExecute()
		{
			// simulates the vacations spots being refreshed from the data base.
			var list = this.VacationSpots.ToList();
			list.Add($"New Spot {DateTime.Now.ToLocalTime()}");
			this.VacationSpots = new ObservableCollection<String>(list);
			this.Person.NextVacationSpot = list.Last();
		}
    }
}
