using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
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
        private string firebaseApiKey = "NYMI0Ko6jsOJRfXh0aGlBEUnd8Z5mwt9iHaeYXV9";
        private string firebaseDatabaseURL = "https://gabsfirebasewinapp.firebaseio.com";

        private IFirebaseClient _firebaseClient;
        private string _firebaseEndpoint = "Cars";
        private List<CarType> carTypes = new List<CarType>();
        private bool insertMode = false;

        public Form2Firebase()
        {
            InitializeComponent();
        }

        private async void Form2Firebase_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            // https://github.com/ziyasal/FireSharp
            IFirebaseConfig config = new FirebaseConfig();
            config.AuthSecret = firebaseApiKey;
            config.BasePath = firebaseDatabaseURL;
            _firebaseClient = new FirebaseClient(config);
            if (_firebaseClient != null)
            {
                MessageBox.Show("Connected to Firebase Realtime Database.");
                GetCarsFromFirebase();
                ListenToFirebase();
            }
            else
                MessageBox.Show("Error connecting to Firebase.");

            LoadInitialCarTypes();
        }

        private async void GetCarsFromFirebase()
        {
            if(_firebaseClient != null)
            {
                FirebaseResponse responseGet = await _firebaseClient.GetAsync(_firebaseEndpoint);
                var result = responseGet.ResultAs<Dictionary<string, Car>>(); 
                if(result != null)
                {
                    try
                    {
                        var cars = result.Select(s => s.Value).ToList(); ; // result.Select(s => s.Value).ToList();
                        //dataGridView1.Rows.Clear();                        
                        //bindingSourceCar.Clear();
                        bindingSourceCar.DataSource = cars;
                        //bindingSourceCar.CurrencyManager.Refresh();

                        //dataGridView1.Rows.Clear();
                        //dataGridView1.DataSource = bindingSourceCar;
                        //dataGridView1.Refresh();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    Car car1 = new Car();
                    car1.Id = 1;
                    car1.Brand = "Toyota";
                    car1.Model = "Wigo";
                    car1.Type = "1";
                    car1.Color = "Red";
                    var responseSet = await _firebaseClient.SetAsync(_firebaseEndpoint + "/c" + car1.Id.ToString(), car1);
                    var res = responseSet.ResultAs<Car>();
                    UpdateNewCarId(res.Id);
                    GetCarsFromFirebase();
                }
            }

        }

        private void LoadInitialCarTypes()
        {
            var carType1 = new CarType();
            carType1.Id = "1";
            carType1.Type = "Hatchback";
            carTypes.Add(carType1);

            var carType2 = new CarType();
            carType2.Id = "2";
            carType2.Type = "SUV";
            carTypes.Add(carType2);

            comboCarType.DataSource = carTypes;
            comboCarType.DisplayMember = "Type";
            comboCarType.ValueMember = "Id";
        }

        private async void UpdateNewCarId(int currentId)
        {
            // Increment Id by 1
            var newCarIdGen = new CarIdGenerator();
            newCarIdGen.Id = currentId + 1;
            await _firebaseClient.SetAsync("_Ids/" + _firebaseEndpoint, newCarIdGen);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            Car newCar = bindingSourceCar.Current as Car;
            if(newCar != null)
            {
                var responseSet = await _firebaseClient.SetAsync(_firebaseEndpoint + "/c" + newCar.Id.ToString(), newCar);
                var result = responseSet.ResultAs<Car>();
                if (result != null)
                {
                    MessageBox.Show("Successfully saved to Firebase.");
                    if (insertMode)
                    {
                        UpdateNewCarId(result.Id);
                        insertMode = false;
                        bindingSourceCar.CancelEdit();
                    }
                }
                else
                    MessageBox.Show("Error saving the data to Firebase.");
            }
        }

        private async void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            var delCar = bindingSourceCar.Current as Car;
            var responseDel = await _firebaseClient.DeleteAsync(_firebaseEndpoint + "/c" + delCar.Id);
            if (responseDel.StatusCode != System.Net.HttpStatusCode.OK)
                MessageBox.Show("Deletion failed.");
        }

        private async void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var responseGet = await _firebaseClient.GetAsync("_Ids/" + _firebaseEndpoint);
            var result = responseGet.ResultAs<CarType>();
            if (result != null)
                txtCarId.Text = result.Id.ToString();
            else
                txtCarId.Text = "1";

            txtCarId.Focus();
            insertMode = true;
        }

        private async void ListenToFirebase()
        {
            EventStreamResponse response = await _firebaseClient.OnAsync(_firebaseEndpoint,
            added: (s, args, d) =>
            {
                bool flag = true; 
                while(flag)
                {
                    var id = args.Path.Split('/')[1];
                    this.Text = $"[{DateTime.Now.ToString("mm:ss:fff tt")}] [{id}] Recieved ADDED updates from Firebase";
                    //var t = Task.Run(
                    //async () =>
                    //{
                    //    var responseSet = await _firebaseClient.GetAsync(_firebaseEndpoint + "/" + id);
                    //    var car = responseSet.ResultAs<Car>();
                    //    bindingSourceCar.Add(car);
                    //});
                    flag = false;
                }

            },
            changed: (s, args, d) =>
            {
                bool flag = true;
                while (flag)
                {
                    var id = args.Path.Split('/')[1];
                    this.Text = $"[{DateTime.Now.ToString("mm:ss:fff tt")}] [{id}] Recieved CHANGED updates from Firebase";
                    var t = Task.Run(
                    async () =>
                    {
                        var responseSet = await _firebaseClient.GetAsync(_firebaseEndpoint + "/" + id);
                        var car = responseSet.ResultAs<Car>();
                        bindingSourceCar.Add(car);
                        dataGridView1.Refresh();
                    });
                    flag = false;
                }
            },
            removed: (s, args, d) =>
            {
                this.Text = $"[{DateTime.Now.ToString("mm:ss:fff tt")}] [{args.Path}] Recieved DELETE updates from Firebase";
                if (args.Path.ToLower().StartsWith("{"))
                    listBoxJson.Items.Add(args.Path);
            });
        }


    }
}
