using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GabsWinformEF.Models;

namespace GabsWinformEF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnMovie1_Click(object sender, EventArgs e)
        {
            var reserve = new MovieReservation();
            reserve.CustomerName = "Customer Name";
            reserve.CustomerContact = "Customer Contact";
            reserve.MovieId = 1;
            reserve.NumberOfSeats = int.Parse(txtMovieSeat1.Text);
            reserve.ScreeningDate = dateTimePicker1.Value;

            // then add/save to database
        }

        private void btnMovie2_Click(object sender, EventArgs e)
        {
            var reserve = new MovieReservation();
            reserve.CustomerName = "Customer Name";
            reserve.CustomerContact = "Customer Contact";
            reserve.MovieId = 2;
            reserve.NumberOfSeats = int.Parse(txtMovieSeat2.Text);
            reserve.ScreeningDate = dateTimePicker1.Value;

            // then add/save to database
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            // int reservedSeats = _db.MovieRese.Where(x =>x.MovieId = 1).Sum(t => t.NumberOfSeats)
            //labelAvailableSeat1.Text = seatCapacity - reservedSeats

            // do the same to other movies
        }
    }
}
