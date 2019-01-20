using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GabsWinformEF
{
    public partial class Form2Firebase : Form
    {
        public Form2Firebase()
        {
            InitializeComponent();
        }


        private IFirebaseClient _firebaseClient;
        private string _firebaseEndpoint = "Cars";
        private List<CarType> carTypes = new List<CarType>();


        private void Form2Firebase_Load(object sender, EventArgs e)
        {
            // https://github.com/ziyasal/FireSharp
            IFirebaseConfig config = new FirebaseConfig();
            config.AuthSecret = "NYMI0Ko6jsOJRfXh0aGlBEUnd8Z5mwt9iHaeYXV9";
            config.BasePath = "https://gabsfirebasewinapp.firebaseio.com";
            _firebaseClient = new FirebaseClient(config);
            if (_firebaseClient != null)
                MessageBox.Show("Connected to Firebase Realtime Database.");
            else
                MessageBox.Show("Error connecting to Firebase.");

            GetCarsFromFirebase();
            LoadInitialCarTypes();
        }

        private async void GetCarsFromFirebase()
        {
            if(_firebaseClient != null)
            {
                FirebaseResponse responseGet = await _firebaseClient.GetAsync(_firebaseEndpoint);
                var result = responseGet.ResultAs<List<Car>>(); 
                if(result != null)
                {
                    var cars = result; // result.Select(s => s.Value).ToList();
                    bindingSourceCar.DataSource = cars;
                }
                else
                {
                    Car car1 = new Car();
                    car1.Id = 1;
                    car1.Brand = "Toyota";
                    car1.Model = "Wigo";
                    car1.Type = 1;
                    car1.Color = "Red";
                    SetResponse response = await _firebaseClient.SetAsync(_firebaseEndpoint + "/" + car1.Id.ToString(), car1);
                }
            }

        }

        private void LoadInitialCarTypes()
        {
            var carType1 = new CarType();
            carType1.Id = 1;
            carType1.Type = "Hatchback";
            carTypes.Add(carType1);

            var carType2 = new CarType();
            carType2.Id = 2;
            carType2.Type = "SUV";
            carTypes.Add(carType2);

            comboCarType.DataSource = carTypes;
            comboCarType.DisplayMember = "Type";
            comboCarType.ValueMember = "Id";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save to database...
        }

        private async void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            bindingSourceCar.Add(new Car());

            var responseGet = await _firebaseClient.GetAsync("_Ids" + _firebaseEndpoint);
            if(responseGet != null)
            {
                var result = responseGet.ResultAs<CarType>();
                txtCarId.Text = result.Id.ToString();
            }
            else
                txtCarId.Text = "1";

            txtCarId.Focus();

        }
    }
}
