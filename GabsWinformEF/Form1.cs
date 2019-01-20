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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<CarType> carTypes = new List<CarType>();

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInitialCars();
            LoadInitialCarTypes();
        }

        private void LoadInitialCars()
        {
            Car car1 = new Car();
            car1.Id = 1;
            car1.Brand = "Toyota";
            car1.Model = "Wigo";
            car1.Type = 1;
            car1.Color = "Red";
            // Binding source is a collection type. It's the same as List.
            bindingSourceCar.Add(car1);

            Car car2 = new Car();
            car2.Id = 2;
            car2.Brand = "Isuzu";
            car2.Model = "Mux";
            car2.Type = 2;
            car2.Color = "Gray";
            bindingSourceCar.Add(car2);
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

        private void btnFirebase_Click(object sender, EventArgs e)
        {
            new Form2Firebase().Show();
        }
    }
}
