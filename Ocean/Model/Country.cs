using System;
namespace Ocean.Model
{
    public class Country :ObservableObject
    {
        private String _abbrevation;
        private Int32 _id;
        private String _name;

        public String Abbreviation
        {
            get
            {
                return _abbrevation;
            }
            set
            {
                _abbrevation = value;
                RaisePropertyChanged();
            }
        }

		public Int32 Id
		{
			get
			{
                return _id;
			}
			set
			{
                _id = value;
				RaisePropertyChanged();
			}
		}

		public String Name
		{
			get
			{
                return _name;
			}
			set
			{
                _name = value;
				RaisePropertyChanged();
			}
		}

		public Country()
		{
		}
    }
}
